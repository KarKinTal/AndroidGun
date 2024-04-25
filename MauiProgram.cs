using AndroidGunFinal.Services;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace AndroidGunFinal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseBarcodeReader();

            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<Wydanie>();

            builder.Services.AddTransient<EtykietaInfo>();

            builder.Services.AddTransient<Menu>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<LoginService>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<Loading>();

            return builder.Build();
        }
    }
}
