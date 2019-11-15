using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChuckNorris.ViewModels;
using ChuckNorris.Models;

namespace ChuckNorris.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var item = args.SelectedItem as NorrisFact;
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"itemdetail?id={item.id}");

            //// Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = e.CurrentSelection;

            if (current.Count == 1)
            {
                var item = e.CurrentSelection.FirstOrDefault() as NorrisFact;
                await Shell.Current.GoToAsync($"itemdetail?id={item.id}");
                //ItemsCollectionView.SelectedItem = null;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
               viewModel.LoadItemsCommand.Execute(null);
        }
    }
}