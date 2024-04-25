using AndroidGunFinal.Services;

namespace AndroidGunFinal;

public partial class Loading : ContentPage
{
	private readonly LoginService _loginService;
	public Loading(LoginService loginService)
	{
		InitializeComponent();
		_loginService = loginService;
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		if(await _loginService.IsAuthenicatedAsync())
		{
			Shell.Current.GoToAsync($"{nameof(MainPage)}");
		}
		else
		{
			Shell.Current.GoToAsync($"{nameof(Login)}");
		}
    }
}