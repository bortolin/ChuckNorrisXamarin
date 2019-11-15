using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChuckNorris.Models;
using Xamarin.Essentials;

namespace ChuckNorris.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<NorrisFact> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Facts";
            Items = new ObservableCollection<NorrisFact>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var maxitems = Preferences.Get(Constants.Settings_MaxNumFacts, 15);
                var items = await RestService.GetRandomFacts(maxitems);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}