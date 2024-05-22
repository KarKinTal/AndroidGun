
using System.Text;
using AndroidGunFinal.Services;
using Newtonsoft.Json;
namespace AndroidGunFinal;

public partial class Login : ContentPage
{
    HttpClient client = new HttpClient();

    public Login()
	{
        InitializeComponent();
        client.BaseAddress = new Uri("http://localhost:8080/");
    }


    public string DoLogin()
    {
        try
        {
            var login = new LoginClass(PasswordTxtIn.Text, loginTxtIn.Text);
            string jsonData = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response =  client.PostAsync("api/auth/login", content);
            var jsonRespone =  response.Result;

            if (jsonRespone.IsSuccessStatusCode)
            {
                PasswordTxtIn.Text = "test";
                loginTxtIn.Text = "test";
                return jsonRespone.StatusCode.ToString();
            }
            else
            {
                PasswordTxtIn.Text = "Błąd";
                loginTxtIn.Text = "Błąd";
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
        await Task.Run(DoLogin);
        
         Navigation.PushAsync(new MainPage());

    }
}