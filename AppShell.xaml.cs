namespace AndroidGunFinal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Wydanie), typeof(Wydanie));
        }
        private async void GoToMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());
        }
    }
}
