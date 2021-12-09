using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class Orders
    {
        private IList<Order> _orders;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            //_orders = await _orderHandler.GetAllAsync();

            DialogService.OnOpen += Open;
            DialogService.OnClose += Close;
        }

        async Task OpenLocationWithItems(Order order)
        {
            await DialogService.OpenAsync<LocationsCard>($"\nOrder number: {order.OrderNumber}",
                new Dictionary<string, object>() {{"Order", order}},
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