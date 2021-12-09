using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class AddItem
    {
        private IList<Item> _items;
        private IList<Location> _locations;

        private ItemLocation _itemLocation;

        string pagingSummaryFormat = "Page {0} of {1}";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _items = await _itemsHandler.GetAllAsync();
            _locations = await _locationsHandler.GetAllAsync();
            _itemLocation = new();

            DialogService.OnOpen += Open;
            DialogService.OnClose += CloseConfirmAdd;
        }

        private async Task Save()
        {
            await _itemLocationHandler.RegisterAsync(_itemLocation);

            Console.WriteLine($"Printing Location: /n {_itemLocation}");

            _navigationManager.NavigateTo("/Items");
        }

        void OnChange(object value, string name)
        {
            Console.WriteLine($"value is: {value}");
            Console.WriteLine($"name is: {name}");
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>) value) : value;

            Console.WriteLine($"{name} value changed to {str}");

            if (name.Equals("Item"))
            {
                Item item = (Item) value;

                _itemLocation.Item = item;
            }
            else if (name.Equals("Location"))
            {
                Location location = (Location) value;
                _itemLocation.Location = location;
            }
        }

        void CloseConfirmAdd(dynamic result)
        {
            if (result != null) // if the user hits the x near the top right null is returned
            {
                // result is false if the user clicks no
                if ((bool) result) Save();
            }
        }

        public void Dispose()
        {
            DialogService.OnOpen -= Open;
            DialogService.OnClose -= CloseConfirmAdd;
        }

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            Console.WriteLine("Dialog opened");
        }

        void Close(dynamic result)
        {
            Console.WriteLine($"Dialog closed {result}");
        }
    }
}