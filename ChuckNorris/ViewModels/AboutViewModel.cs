using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChuckNorris.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => {

                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    Device.OpenUri(new Uri("https://api.chucknorris.io/"));
                }
                else
                {
                    MessagingCenter.Send(this, "NotConnected");
                }
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}