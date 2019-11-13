using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace ChuckNorris.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://api.chucknorris.io/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}