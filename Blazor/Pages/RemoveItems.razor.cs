using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class RemoveItems
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

            Console.WriteLine("count of itemlocations : " + _inventories.Count);

            _newInventory = new();
            _oldInventory = new();

            DialogService.OnOpen += Open;
            DialogService.OnClose += CloseConfirmTrash;
        }

        private async Task Trash()
        {
            SetLocation();
            _newInventory.Amount = _amount;
            await _inventoryHandler.UpdateAsync(_newInventory);
            _navigationManager.NavigateTo("/Items");
        }

        private void SetLocation()
        {
            _newInventory.Location = new Location();
            _newInventory.Location.Id = 1;
            _newInventory.Location.Description = "Trashed";
            Console.WriteLine(_newInventory);
        }

        private void OnChange(object value, string name)
        {
            Console.WriteLine($"value is: {value}");
            Console.WriteLine($"name is: {name}");

            if (name.Equals("Inventory"))
            {
                Console.WriteLine("-------------------------Inventory---------------------------");
                _oldInventory = (Inventory) value;
                _maxValue = _oldInventory.Amount;
                Console.WriteLine($"+++ OldItemLocation.Id - {_oldInventory.Id}");
                Console.WriteLine($"-Printing Item from Item Location: {_oldInventory.Item}");
                Console.WriteLine($"-Printing Amount from Item Location: {_oldInventory.Amount}");
                _newInventory.Item = _oldInventory.Item;
                _newInventory.Amount = _oldInventory.Amount;
                _newInventory.Id = _oldInventory.Id;

                Console.WriteLine($"++++ NewItemLocation.Id - {_newInventory.Id}");
            }
            else if (name.Equals("amount"))
            {
                Console.WriteLine("-------------------Amount----------------------------");
                _amount = (int) value;
            }
        }

        private void CloseConfirmTrash(dynamic result)
        {
            if (result != null) // if the user hits the x near the top right null is returned
            {
                // result is false if the user clicks no
                if ((bool) result) Trash();
            }
        }

        public void Dispose()
        {
            DialogService.OnOpen -= Open;
            DialogService.OnClose -= CloseConfirmTrash;
        }

        private void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            Console.WriteLine("Dialog opened");
        }
    }
}