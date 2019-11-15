using System;

using ChuckNorris.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChuckNorris.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public string ItemId { get; set; }

        public Command OpenFactLink => new Command(async () => await Launcher.OpenAsync(new Uri($"https://api.chucknorris.io/jokes/{ItemId}")));

        public ItemDetailViewModel(string itemId)
        {
            ItemId = itemId;
        }
    }
}
