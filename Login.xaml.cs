namespace AndroidGunFinal;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    async void MoveToApp(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(), true);
    }
}