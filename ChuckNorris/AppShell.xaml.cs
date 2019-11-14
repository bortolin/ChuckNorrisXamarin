using System;
using System.Collections.Generic;
using System.Windows.Input;
using ChuckNorris.Views;
using Xamarin.Forms;

namespace ChuckNorris
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        public Command OpenSettingsCommand => new Command(() => Navigation.PushModalAsync(new SettingsPage()));

        public AppShell()
        {
            InitializeComponent();
            
            BindingContext = this;

        }
    }
}
