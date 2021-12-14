using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class Trashed
    {
        //TODO: ALT DETTE TRASHED LOGIK SKAL FLYTTES TIL TIER 2!!!!!!! - FØR AFLEVERING! ;))))


        private List<Inventory> _inventories;

        //For Sorting amount:
        private IList<Item> _items;

        //Percentage trashed:
        private IList<int> _percentageTrashed;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            var allStock = await _inventoryHandler.GetAllAsync();
            _inventories =  allStock.Where(inventory => inventory.Location.Description == "Trashed").ToList();
        }
        
        async Task OpenLocationWithItems(Inventory inventory)
        {
            await DialogService.OpenAsync<LocationsCard>($"\nItem Name: {inventory.Item.ItemName}" +
                                                         $"Item Id {inventory.Item.Id}",
                new Dictionary<string, object>() {{"Inventory", inventory}},
                new DialogOptions()
                {
                    Width = "700px", Height = "530px",
                    CloseDialogOnOverlayClick = true, Resizable = true
                });
        }
        
    }
}