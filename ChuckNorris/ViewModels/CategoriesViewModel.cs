using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ChuckNorris.Models;
using ChuckNorris.Views;

namespace ChuckNorris.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CategoriesViewModel()
        {
            Title = "Caregories";
            Items = new ObservableCollection<string>();
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
                var items = await RestService.GetCategories();
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