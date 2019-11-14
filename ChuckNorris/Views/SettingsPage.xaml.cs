using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChuckNorris.Models;
using Xamarin.Essentials;

namespace ChuckNorris.Views
{

    [DesignTimeVisible(false)]
    public partial class SettingsPage : ContentPage
    {
        public int MaxItemShow { get; set; }

        public SettingsPage()
        {

            InitializeComponent();

            MaxItemShow = Preferences.Get(Constants.Settings_MaxNumFacts, 15);

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {           
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}