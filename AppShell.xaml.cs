using System.Reflection;

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

        private ShellContent? _previousShellContent;

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            if (CurrentItem?.CurrentItem?.CurrentItem is not null &&
                _previousShellContent is not null)
            {
                var property = typeof(ShellContent)
                    .GetProperty("ContentCache", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                property!.SetValue(_previousShellContent, null);
            }

            _previousShellContent = CurrentItem?.CurrentItem?.CurrentItem;
        }
    }
}
