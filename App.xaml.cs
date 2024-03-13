//using AndroidGun.Services;
//using AndroidGun.UI;
namespace AndroidGun
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
