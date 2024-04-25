namespace AndroidGunFinal;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    async void MoveToApp(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(Wydanie)}");
    }
}