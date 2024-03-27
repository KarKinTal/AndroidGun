using Camera.MAUI;
using ZXing;
using ZXing.Net.Maui;

namespace MauiApp2{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.Code128,
                AutoRotate = true,
                Multiple = true
            };
            
        }
        private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();

            if (first is null)
                return;

            Dispatcher.DispatchAsync(async () =>
            {
                await DisplayAlert("Barcode Detected", first.Value, "OK");
            });
        }
        
    }
}