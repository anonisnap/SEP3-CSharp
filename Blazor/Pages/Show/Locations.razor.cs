using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.Show
{
    public partial class Locations
    {
        private IList<Inventory> _inventories;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _inventories = await _inventoryHandler.GetAllAsync();

            DialogService.OnOpen += Open;
            DialogService.OnClose += Close;
        }

        async Task OpenItemWithLocations(Inventory inventory)
        {
            await DialogService.OpenAsync<ItemsCard>($"Location: {inventory.Location.Description}",
                new Dictionary<string, object>() {{"Inventory", inventory}},
                new DialogOptions()
                {
                    Width = "1000px", Height = "530px",
                    CloseDialogOnOverlayClick = true, Resizable = true
                });
        }

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            Console.WriteLine("Dialog Opened");
        }

        void Close(dynamic result)
        {
            Console.WriteLine("Dialog closed");
        }
    }
}