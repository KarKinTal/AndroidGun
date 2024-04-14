﻿using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Readers;

namespace AndroidGunFinal
{
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
            barcodeReader.CameraLocation = ZXing.Net.Maui.CameraLocation.Rear;
        }
        private void barcodeReader_BarcodeDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();
            if (first != null) { return; }
            Dispatcher.DispatchAsync(async () => {
            await DisplayAlert("Barcode detected", first.Value, "Ok");
            });
        }


    }

}
