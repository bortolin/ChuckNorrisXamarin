using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChuckNorris.Models;
using Xamarin.Essentials;
using System.Windows.Input;
using ChuckNorris.ViewModels;

namespace ChuckNorris.Views
{

    [DesignTimeVisible(false)]
    public partial class SettingsPage : ContentPage
    {

        public int MaxItemShow { get; set; }


        public Command BackCommand => new Command(async () => {

            Preferences.Set(Constants.Settings_MaxNumFacts, MaxItemShow);
            await Shell.Current.Navigation.PopToRootAsync();

        });

        public SettingsPage()
        {

            InitializeComponent();

            MaxItemShow = Preferences.Get(Constants.Settings_MaxNumFacts, 15);

            BindingContext = this;
        }

    }
}