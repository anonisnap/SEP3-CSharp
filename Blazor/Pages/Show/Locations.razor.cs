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
        private IList<Location> _locations;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _locations = await _locationHandler.GetAllAsync();

            DialogService.OnOpen += Open;
            DialogService.OnClose += Close;
        }

        async Task OpenItemWithLocations(Location location)
        {
            await DialogService.OpenAsync<ItemsCard>($"Location: {location.Description}",
                new Dictionary<string, object>() {{"LocationId", location.Id}},
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