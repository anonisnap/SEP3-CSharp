using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.DataManipulation
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
        }

        private async Task Save()
        {
            await _inventoryHandler.RegisterAsync(_inventory);
            
            _navigationManager.NavigateTo("/Items");
        }

        void OnChange(object value, string name)
        {
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
                }
            }
            Dispose();
        }
        
        public void Dispose()
        {
            _dialogService.OnClose -= CloseConfirmAdd;
        }
        
        private void SetUpDialogBox()
        {
            _dialogService.Confirm("Are you sure you want to add this item?",
                "Save", new ConfirmOptions() {OkButtonText = "Yes", CancelButtonText = "No"});
            
            _dialogService.OnClose += CloseConfirmAdd;
        }
    }
}