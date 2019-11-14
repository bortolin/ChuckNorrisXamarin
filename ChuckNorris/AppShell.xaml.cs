using System;
using System.Collections.Generic;
using System.Windows.Input;
using ChuckNorris.Views;
using Xamarin.Forms;

namespace ChuckNorris
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        //public Command OpenSettingsCommand => new Command(() => Navigation.PushModalAsync(new NavigationPage(new SettingsPage())));
        public Command OpenSettingsCommand => new Command(() => { Shell.Current.GoToAsync("prova"); Shell.Current.FlyoutIsPresented = false; });

        public AppShell()
        {
            InitializeComponent();
            
            BindingContext = this;

            Routing.RegisterRoute("prova", typeof(SettingsPage));

        }
    }
}
