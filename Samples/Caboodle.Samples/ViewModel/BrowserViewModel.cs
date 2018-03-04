using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

using Microsoft.Caboodle;

namespace Caboodle.Samples.ViewModel
{
    public class BrowserViewModel : BaseViewModel
    {
        private Browser browser;
        private string uri = $"https://xamarin.com";
        private string browser_status;

        public ICommand OpenUriCommand { get; }

        public string BrowserStatus
        {
            get => browser_status;
            set => SetProperty(ref browser_status, value);
        }

        public BrowserViewModel()
        {
            BrowserType = "External";

            browser = new Browser();

            OpenUriCommand = new Command(async () =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                try
                {
                    await Browser.OpenAsync(uri);
                }
                catch (Exception e)
                {
                    browser_status = $"Unable to open Uri {e.Message}";
                    System.Diagnostics.Debug.WriteLine(browser_status);
                }
                finally
                {
                    IsBusy = false;
                }
            });

            return;
        }

        public string Uri
        {
            get => uri;
            set
            {
                uri = value;
                OnPropertyChanged();
            }
        }

        private string browser_type;
        public string BrowserType
        {
            get => browser_type;
            set
            {
                browser_type = value;
                if (browser_type == "Safari")
                {
                    Browser.AlwaysUseExternal = false;
                }
                else
                {
                    Browser.AlwaysUseExternal = true;
                }

                OnPropertyChanged();
            }
        }
    }
}
