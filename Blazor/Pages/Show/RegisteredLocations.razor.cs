using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.Show
{
    public partial class RegisteredLocations
    {
        private IList<Location> _locations;

        private string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        private bool showPagerSummary = true;
    
        protected override async Task OnInitializedAsync()
        {
            _locations = await _locationsHandler.GetAllAsync();
        }
    }
}