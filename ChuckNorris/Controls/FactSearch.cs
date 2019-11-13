using System;
using ChuckNorris.Services;
using Xamarin.Forms;

namespace ChuckNorris.Controls
{
    public class FactSearchHandler : SearchHandler
    {
        public IRestService RestService => DependencyService.Get<IRestService>();

        public FactSearchHandler()
        {

        }

        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue) || newValue.Length < 3)
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = await RestService.QueryFacts(newValue);
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
            //await (App.Current.MainPage as Xamarin.Forms.Shell).GoToAsync($"monkeydetails?name={((Animal)item).Name}");
        }
    }
}
