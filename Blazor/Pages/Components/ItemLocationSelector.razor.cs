using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Components
{
    public partial class ItemLocationSelector
    {
        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool ShowLocationDetail { get; set; }
    
        [Parameter]
        public bool ShowItemDetails { get; set; }
    
        [Parameter]
        public int ItemId { get; set; }

        [Parameter]
        public EventCallback<Inventory> InventoryChange { get; set; }

        [Parameter]
        public EventCallback<int> AmountChange { get; set; }
        
        private IList<Inventory> _inventories;
        private int _amount;
        private int _maxValue;

        string pagingSummaryFormat = "Page {0} of {1}";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            if (ItemId != 0)
            {
                _inventories = await _inventoryHandler.GetAllByItemIdAsync(ItemId);
                return;
            } 
            _inventories = await _inventoryHandler.GetInventoryStockAsync();
        }

        private void OnInventoryChange(object value)
        {
            Inventory inventory = (Inventory) value;
            _maxValue = inventory.Amount;
            InventoryChange.InvokeAsync(inventory);
        }

        private void OnAmountChange(int amount)
        {
            AmountChange.InvokeAsync(amount);
        }
    }
}