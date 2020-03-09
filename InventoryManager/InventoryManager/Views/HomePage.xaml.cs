using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        App app = Application.Current as App;

        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnScan(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    // give vibration and beep sound
                    if (!modeSwitch.IsToggled)
                    {
                        txtScannedCode.Text = result;
                    }
                    else
                    {
                        app.scannedCodes.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private async void OnQRCodeFormatScan(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    // give vibration and beep sound
                    txtQRCodeFormat.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private void OnQRCodeFormatScanCompleted(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtQRCodeFormat.Text))
            {
                app.QrCodeFormat = txtQRCodeFormat.Text;

                LoadOrderByPicker();

            }
        }

        private void OnQRCodeSeperatorCompleted(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQRCodeSeperator.Text))
            {
                app.QRCodeSeperator = txtQRCodeSeperator.Text;

                LoadOrderByPicker();

                
            }
        }

        private void LoadOrderByPicker()
        {
            orderByPicker.Items.Clear();
            app.OrderBy = null;
            if (!string.IsNullOrWhiteSpace(txtQRCodeSeperator.Text) && txtQRCodeFormat.Text.Contains(txtQRCodeSeperator.Text))
            {                
                orderByPicker.ItemsSource = txtQRCodeFormat.Text.Split(new string[] { txtQRCodeSeperator.Text }, StringSplitOptions.None);
            }

        }

        private void OrderByPickerSelected(object sender, EventArgs e)
        {
            app.OrderBy = orderByPicker.SelectedItem.ToString();
        }
    }
}