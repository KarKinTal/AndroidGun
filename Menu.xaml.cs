namespace AndroidGunFinal;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private void clearStack()
    {
        var stack = Shell.Current.Navigation.NavigationStack.ToArray();
        for (int i = stack.Length - 3; i > 0; i--)
        {
            Shell.Current.Navigation.RemovePage(stack[i]);
        }
    }
    private async void GoToWydanie(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Wydanie());
        clearStack();

    }

    private async void GoToPrzyjecie(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        clearStack();

    }
    private async void GoToInfo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EtykietaInfo());
        clearStack();

    }
}