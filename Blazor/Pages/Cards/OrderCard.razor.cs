using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Blazor.Pages.Cards
{
    public partial class OrderCard
    {
        
        
        private List<Inventory> _pickInventories;

        private Inventory _selectedInventory;
        private int _amount;

        [Parameter] public Order Order { set; get; }

        protected override async Task OnInitializedAsync()
        {
            _pickInventories = new List<Inventory>();
        }


        private async Task ProcessOrder()
        {
            
            bool processed = await _orderHandler.ProcessOrder(Order, _pickInventories);
            
            if (processed)
            {
                _notificationService
                    .Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Success, Summary = "Order completed!",
                        Detail = "The order was processed with success", Duration = 5000
                    });
            }
        }
        
        private void InventoryChanged(Inventory inventory)
        {
            _selectedInventory = inventory;
        }

        private void AmountChanged(int amount)
        {
            _amount = amount;
        }
        
        
        private void OnPick(OrderEntry entry)
        {
            if (entry.Amount != _amount)
            {
                _notificationService
                    .Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error, Summary = "Incorrect amount",
                        Detail = "The picked amount does not correspond to the ordered amount", Duration = 5000
                    });
                entry.IsPicked = false;
                return;
            }

            Inventory pickInventory =
                new Inventory
                {
                    Amount = _amount, Id = _selectedInventory.Id,
                    Item = _selectedInventory.Item, Location = _selectedInventory.Location
                };

            
            AddPickInventory(pickInventory);
        }


        private void AddPickInventory(Inventory pInventory)
        {
            if (IsInventoryInList(pInventory))
            {
                _notificationService
                    .Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Warning, Summary = "Already added",
                        Detail = "The item is already picked", Duration = 5000
                    });
                return;
            }

           
            _pickInventories.Add(pInventory);
            _notificationService
                .Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success, Summary = "Item picked!",
                    Detail = "The item is set as picked", Duration = 5000
                });
            _selectedInventory = null;
            _amount = 0;
        }

        private bool IsInventoryInList(Inventory pInventory)
        {
            return _pickInventories.Find(inventory => inventory.Equals(pInventory)) != null;
        }
    }
}