using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.Overview


{
    public partial class Items
    {
        private IList<Item> _items;
        
        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _items = new List<Item>();
            
            List<Inventory> inventories = await _inventoryHandler.GetInventoryStockAsync() as List<Inventory>;
            inventories?.ForEach(inventory => {if (!_items.Contains(inventory.Item)) _items.Add(inventory.Item);});
        }

        async Task OpenLocationWithItems(Item item)
        {
            
            await DialogService.OpenAsync<LocationsCard>($"\nItem Name: {item.ItemName}" +
                                                         $"Item Id {item.Id}",
                new Dictionary<string, object>() {{"ItemId", item.Id}},
                new DialogOptions()
                {
                    Width = "700px", Height = "530px",
                    CloseDialogOnOverlayClick = true, Resizable = true
                });
        }
    }
}