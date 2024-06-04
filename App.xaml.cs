namespace AndroidGunFinal
{
    public partial class App : Application
    {
        public Dictionary<string, string> GlobalDictionary { get;  set; }
        public App()
        {
            InitializeComponent();
            GlobalDictionary = new Dictionary<string, string>();

            MainPage = new AppShell();
        }
    }
}
