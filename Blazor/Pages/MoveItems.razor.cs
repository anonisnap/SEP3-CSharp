using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class MoveItems
    {
        private IList<Location> _locations;
        private IList<ItemLocation> _itemLocations;

        private ItemLocation _newItemLocation;
        private ItemLocation _oldItemLocation;

        private int _amount;
        private int _maxValue;

        string pagingSummaryFormat = "Page {0} of {1}";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _itemLocations = await _itemLocationHandler.GetAllAsync();
            _locations = await _locationsHandler.GetAllAsync();

            Console.WriteLine("count of itemlocations : " + _itemLocations.Count);

            _newItemLocation = new();
            _oldItemLocation = new();

            DialogService.OnOpen += Open;
            DialogService.OnClose += CloseConfirmAdd;
        }

        private async Task Save()
        {
            //hack slash amount
            _newItemLocation.Amount = _amount;

            await _itemLocationHandler.UpdateAsync(_newItemLocation);
            _navigationManager.NavigateTo("/Items");
        }
        
        private void OnChange(object value, string name)
        {
            
            if (name.Equals("ItemLocation"))
            {
                _oldItemLocation = (ItemLocation) value;
                _maxValue = _oldItemLocation.Amount;
                Console.WriteLine($"+++ OldItemLocation.Id - {_oldItemLocation.Id}");
                Console.WriteLine($"-Printing Item from Item Location: {_oldItemLocation.Item}");
                Console.WriteLine($"-Printing Amount from Item Location: {_oldItemLocation.Amount}");
                _newItemLocation.Item = _oldItemLocation.Item;
                _newItemLocation.Amount = _oldItemLocation.Amount;
                _newItemLocation.Id = _oldItemLocation.Id;

                Console.WriteLine($"++++ NewItemLocation.Id - {_newItemLocation.Id}");
            }
            else if (name.Equals("amount"))
            {
                _amount = (int) value;
            }
        }

        private void CloseConfirmAdd(dynamic result)
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

        private void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            Console.WriteLine("Dialog opened");
        }
    }
}