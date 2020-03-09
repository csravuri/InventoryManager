using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InventoryManager.Services;
using Xamarin.Forms;
//using XFBarcode.Services;
using ZXing.Mobile;

[assembly: Dependency(typeof(InventoryManager.Droid.Services.QrCodeScanningService))]
namespace InventoryManager.Droid.Services
{
    public class QrCodeScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
                        {
                            TopText = "Scan QR Code",
                            BottomText = "Only QR Code"
                        };

            var scanResults = await scanner.Scan(optionsCustom);

            return scanResults == null ? null :scanResults.Text;

        }
    }
}