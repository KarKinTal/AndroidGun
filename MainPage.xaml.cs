using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Readers;
using AndroidGunFinal.Models;

namespace AndroidGunFinal
{
    public partial class MainPage : ContentPage
    {
        public string magazyn { get; set; } = "magazyn";
        public string sektor = "";
        public string Uwagi = "";
        public MainPage()
        {
            InitializeComponent();

            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.Code128,
                AutoRotate = true,
                Multiple = true
                
            };
            barcodeReader.CameraLocation = ZXing.Net.Maui.CameraLocation.Rear;
        }
        
        public LoginViewModel vm;
        private void barcodeReader_BarcodeDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();
            // DictClass.slownik.Add("key", "value");
            if (first is null) { return; }

            Dispatcher.Dispatch(() =>
            {
                MagazynLbl.Text = first.Value;
                SektorLbl.Text = "Sektor";
                UwagiLbl.Text = "Uwaga";
                
            });
        
        }
    }

}
