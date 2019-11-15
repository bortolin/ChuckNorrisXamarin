using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChuckNorris.Services;
using ChuckNorris.Views;

namespace ChuckNorris
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockRestService>();

            MainPage = new AppShell();
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
