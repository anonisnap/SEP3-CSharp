using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.Overview
{
    public partial class RegisteredItems
    {
        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;
        
        private IList<Item> _registeredItems;

        protected override async Task OnInitializedAsync()
        {
            _registeredItems = await _itemsHandler.GetAllAsync();
        }
    }
}