using System;
using System.Collections.Generic;
using System.Windows.Input;
using ChuckNorris.ViewModels;
using ChuckNorris.Views;
using Xamarin.Forms;

namespace ChuckNorris
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        //public Command OpenSettingsCommand => new Command(() => Navigation.PushModalAsync(new SettingsPage()));
        public Command OpenSettingsCommand => new Command(() => { Shell.Current.GoToAsync("settings"); Shell.Current.FlyoutIsPresented = false; });

        public AppShell()
        {
            InitializeComponent();
            
            BindingContext = this;

            Routing.RegisterRoute("settings", typeof(SettingsPage));
            Routing.RegisterRoute("itemdetail", typeof(ItemDetailPage));

            MessagingCenter.Subscribe<AboutViewModel>(this, "NotConnected", (r) => DisplayAlert("Info", "Need connection to internet", "OK"));
        }
    }
}
