using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChuckNorris.Models;
using ChuckNorris.ViewModels;

namespace ChuckNorris.Views
{
    
    [QueryProperty("ItemId", "id")]
    public partial class ItemDetailPage : ContentPage
    {
        public string ItemId { set
            {
                BindingContext = new ItemDetailViewModel(value);
            }
        }

        public ItemDetailPage()
        {
            InitializeComponent();
        }
    }
}