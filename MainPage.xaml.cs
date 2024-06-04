using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Readers;
using AndroidGunFinal.Models;
using Newtonsoft.Json;
using AndroidGunFinal.Services;
using System.Net.Http.Headers;
using Org.Apache.Http.Protocol;
using System.Text;

namespace AndroidGunFinal
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();

            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.Code128,
                AutoRotate = true,
                Multiple = true
                
            };
            barcodeReader.CameraLocation = ZXing.Net.Maui.CameraLocation.Rear;
        }
        public void search(object sender, System.EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:8080/");
            // Tutaj są dane ze słownika dla zalogowania
            var userLogin = ((App)Application.Current).GlobalDictionary["userLogin"];
            // Odwołanie do słownika globalnie aby dodać income 
            var globalDict = ((App)Application.Current).GlobalDictionary;

            dynamic userLoginJson = JsonConvert.DeserializeObject(userLogin);
            string token = userLoginJson["token"];
            int warehouseId = userLoginJson["warehouseId"];
            if (userLoginJson["storno"] == null)
            {
                userLoginJson["storno"] = 0;
            }
            int storno = userLoginJson["storno"].ToObject<int>();

            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Klasa income jest w miarę prosta zobacz na plik jak działa. 1,1 to sektor X,Y 

            IncomeDTO dto = new IncomeDTO(SearchFor.Text, warehouseId, storno,1,1);
            
            var jsonIncome = System.Text.Json.JsonSerializer.Serialize(dto);
            var contentIncome = new StringContent(jsonIncome, Encoding.UTF8, "application/json");

            var responseIncome = client.PostAsync("api/income", contentIncome).Result;
            var responseContentIncome = responseIncome.Content.ReadAsStringAsync().Result;

            dynamic responseJson = JsonConvert.DeserializeObject(responseContentIncome);

            if (responseIncome.IsSuccessStatusCode)
            {
                var responseContent = responseIncome.Content.ReadAsStringAsync().Result;
                dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                globalDict["income"] = responseContentIncome;
                // Automatyczne przeniesienie do etykieta info. 
                // Żeby się odwołać do danych z globalDict spójrz na przykład w tym pliku odnośnie userLogin
                Navigation.PushAsync(new EtykietaInfo());

            }
            else
            {
                Console.WriteLine("Błąd");
            }
            
        }
        private void barcodeReader_BarcodeDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();
            SearchFor.Text = first.ToString();
        }
    }

}
