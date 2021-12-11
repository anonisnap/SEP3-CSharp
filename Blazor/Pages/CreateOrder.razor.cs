using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ItemLocationSelectorComponent;
using Radzen.Blazor;

namespace Blazor.Pages
{
    public partial class CreateOrder
    {
        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;
        
        private Order _order;
        private OrderEntry _orderEntry;
        
        private List<OrderEntry> _orderEntries;
        private RadzenDataGrid<OrderEntry> _orderEntryGrid;

        private Item _selectedItem;
        
        private int _amount;
        private int _maxValue;
        private string testString;

        protected override async Task OnInitializedAsync()
        {
            _order = new();
            _order.Location = new Location {Description = "Default"};
            _orderEntries = new ();
            _orderEntry = new OrderEntry();
            
        }

        private async Task CreateNewOrder()
        {
            _order.OrderEntries = _orderEntries;
            _order.OrderNumber = 1; // will be overwritten on server
            Order order = await _orderHandler.RegisterAsync(_order);
            _navigationManager.NavigateTo($"/OrderCard/{order}");
        }

        private async Task AddOrderEntry()
        {
            _orderEntry.Item = _selectedItem;
            _orderEntry.Amount = _amount;
            
            if (IsOrderEntryInList(_orderEntry) || !IsItemAndAmountSelected(_orderEntry)) return;
            
            _orderEntries.Add((OrderEntry) _orderEntry.Clone());
            
            await _orderEntryGrid.Reload();
        }
        
        public void InventoryChanged(Inventory inventory)
        {
            _selectedItem = inventory.Item;
        }
        
        public void AmountChanged(int amount)
        {
            _amount = amount;
        }

        private bool IsItemAndAmountSelected(OrderEntry orderEntry)
        {
            return (orderEntry.Item != null && orderEntry.Amount != 0);
        }

        private bool IsOrderEntryInList(OrderEntry orderEntry)
        {
            return _orderEntries.Find(entry => entry.Item?.Id == orderEntry.Item?.Id) != null;
        }
    }
}