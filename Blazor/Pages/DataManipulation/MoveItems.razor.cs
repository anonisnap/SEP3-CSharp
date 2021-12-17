using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.DataManipulation
{
    public partial class MoveItems
    {
        private IList<Location> _locations;
        private IList<Inventory> _inventories;

        private Inventory _newInventory;
        private Inventory _oldInventory;

        private int _amount;
        private int _maxValue;

        string pagingSummaryFormat = "Page {0} of {1}";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _inventories = await _inventoryHandler.GetAllAsync();
            _locations = await _locationsHandler.GetAllAsync();

            _newInventory = new();
            _oldInventory = new();
        }
        
        private async Task Save()
        {
            _newInventory.Amount = _amount;
            await _inventoryHandler.UpdateAsync(_newInventory);
            _navigationManager.NavigateTo("/Items");
        }
        
        private void OnChange(object value, string name)
        {
            if (name.Equals("Inventory"))
            {
                _oldInventory = (Inventory) value;
                _maxValue = _oldInventory.Amount;
                _newInventory.Item = _oldInventory.Item;
                _newInventory.Amount = _oldInventory.Amount;
                _newInventory.Id = _oldInventory.Id;

            }
            else if (name.Equals("Location"))
            {
                Location location = (Location) value;
                _newInventory.Location = location;
            }
            else if (name.Equals("amount"))
            {
                _amount = (int) value;
            }
        }

        private async void CloseConfirmAdd(dynamic result)
        {
            if (result != null) // if the user hits the x near the top right null is returned
            {
                // result is false if the user clicks no
                if (result)
                {
                    await Save();
                }
            }
            Dispose();
        }
        
        private void Dispose()
        {
            _dialogService.OnClose -= CloseConfirmAdd;
        }
        
        private void SetUpDialogBox()
        {
            _dialogService.Confirm("Are you sure you want to move this item?",
                "Save", new ConfirmOptions() {OkButtonText = "Yes", CancelButtonText = "No"});
            
            _dialogService.OnClose += CloseConfirmAdd;
        }
        
    }
}