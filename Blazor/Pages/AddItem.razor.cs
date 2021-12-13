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

        private Inventory _inventory;

        string pagingSummaryFormat = "Page {0} of {1}";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _items = await _itemsHandler.GetAllAsync();
            _locations = await _locationsHandler.GetAllAsync();
            _inventory = new();
            
            DialogService.OnClose += CloseConfirmAdd;
        }

        private async Task Save()
        {
            
            await _inventoryHandler.RegisterAsync(_inventory);
            
            Console.WriteLine($"Printing Location: /n {_inventory}");

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

                _inventory.Item = item;
            }
            else if (name.Equals("Location"))
            {
                Location location = (Location) value;
                _inventory.Location = location;
            }
        }

        private async void CloseConfirmAdd(dynamic result)
        {
            if (result != null) // if the user hits the x near the top right null is returned
            {
                // result is false if the user clicks no
                if ((bool) result)
                {
                    await Save();
                    DialogService.OnClose -= CloseConfirmAdd;
                }
            }
        }
    }
}