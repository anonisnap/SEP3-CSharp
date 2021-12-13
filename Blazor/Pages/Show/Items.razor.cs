using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages.Show


{
    public partial class Items
    {
        private IList<Item> _items;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _items = await _ItemHandler.GetAllAsync();

            DialogService.OnOpen += Open;
            DialogService.OnClose += Close;
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