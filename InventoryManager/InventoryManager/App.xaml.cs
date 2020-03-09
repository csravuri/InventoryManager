using System;
using System.Collections.Generic;
using InventoryManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InventoryManager
{
    public partial class App : Application
    {
        public List<string> scannedCodes = new List<string>();

        private string _QrCodeFormatKey = "QRCodeFormat";
        private string _QrCodeSeperatorKey = "QRCodeSeperator";
        private string _OrderByKey = "OrderBy";

        public string QrCodeFormat
        {
            get
            {
                if(Properties.ContainsKey(_QrCodeFormatKey))
                {
                    return Properties[_QrCodeFormatKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[_QrCodeFormatKey] = value;
            }
        }

        public string QRCodeSeperator
        {
            get
            {
                if (Properties.ContainsKey(_QrCodeSeperatorKey))
                {
                    return Properties[_QrCodeSeperatorKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[_QrCodeSeperatorKey] = value;
            }
        }

        public string OrderBy
        {
            get
            {
                if (Properties.ContainsKey(_OrderByKey))
                {
                    return Properties[_OrderByKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[_OrderByKey] = value;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
