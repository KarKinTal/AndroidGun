
using System.Text;
using AndroidGunFinal.Services;
using Newtonsoft.Json;
namespace AndroidGunFinal;


public partial class Login : ContentPage
{
    public Login() {
        InitializeComponent();
    }

    public string DoLogin()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/");
        var globalDict = ((App)Application.Current).GlobalDictionary;
        try
        {
            var login = new LoginClass("","");
            string jsonData = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response =  client.PostAsync("api/auth/login", content).Result;
            var jsonRespone =  response;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                globalDict["userLogin"] = responseContent;
                return jsonRespone.StatusCode.ToString();
            }
            else
            {
               
                return jsonRespone.StatusCode.ToString();

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    public async void MoveToApp(System.Object sender, System.EventArgs e)
    {

        var statusCode = await Task.Run(DoLogin);
        if (statusCode == "OK") {
            ZalogujBtn.Text = "Zalogowano pomyślnie";
            await Navigation.PushAsync(new MainPage());

        }
        else
        {
            ZalogujBtn.Text = "Błąd Logowania";
        }

        SemanticScreenReader.Announce(ZalogujBtn.Text);

    }

}