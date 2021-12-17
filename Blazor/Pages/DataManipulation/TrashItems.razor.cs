using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.DataManipulation
{
    public partial class TrashItems
    {
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

            _newInventory = new();
            _oldInventory = new();
        }

        private async Task Trash()
        {
            SetLocation();
            _newInventory.Amount = _amount;
            await _inventoryHandler.UpdateAsync(_newInventory);
            _navigationManager.NavigateTo("/Trashed");
        }

        private void SetLocation()
        {
            _newInventory.Location = new Location();
            _newInventory.Location.Id = 1;
            _newInventory.Location.Description = "Trashed";
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
            else if (name.Equals("amount"))
            {
                _amount = (int) value;
            }
        }

        private async void CloseConfirmTrash(dynamic result)
        {
            if (result != null) // if the user hits the x near the top right null is returned
            {
                // result is false if the user clicks no
                if ((bool) result) await Trash();
            }
            Dispose();
        }
        
        private void Dispose()
        {
            _dialogService.OnClose -= CloseConfirmTrash;
        }
        
        private void SetUpDialogBox()
        {
            _dialogService.Confirm("Are you sure you want to remove?",
                "Save", new ConfirmOptions() {OkButtonText = "Yes", CancelButtonText = "No"});
            
            _dialogService.OnClose += CloseConfirmTrash;
        }
    }
}