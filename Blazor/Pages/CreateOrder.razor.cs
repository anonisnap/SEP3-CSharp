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
        private RadzenDataGrid<OrderEntry> orderEntryGrid;
        
        private int _amount;
        private int _maxValue;
        private string testString;

        protected override async Task OnInitializedAsync()
        {
            _order = new();
            _orderEntries = new ();
            _orderEntry = new OrderEntry();
            
        }

        private async Task CreateNewOrder()
        {
            
            //await _orderHandler.RegisterAsync(_order);
            //_navigationManager.NavigateTo("/Orders");
        }

        private async Task AddOrderEntry()
        {
           
            if (IsOrderEntryInList(_orderEntry) || !IsItemAndAmountSelected(_orderEntry)) return;
            
            _orderEntries.Add((OrderEntry) _orderEntry.Clone());
            Console.WriteLine("Added to list");
            _orderEntry = new ();
            
            await orderEntryGrid.Reload();
        }
        
        public async void InventoryChanged(Inventory inventory)
        {
            Console.WriteLine("Inventory changed ");
            _orderEntry.Item = inventory.Item;
        }
        
        public async void AmountChanged(int amount)
        {
            Console.WriteLine("Amount changed " + amount);
            _orderEntry.Amount = amount;
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