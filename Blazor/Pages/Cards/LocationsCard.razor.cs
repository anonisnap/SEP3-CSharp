using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class LocationsCard
    {
        [Parameter]
        public ItemLocation itemLocation { get; set; }
    
        private IList<ItemLocation> _itemLocations;


        protected override async Task OnInitializedAsync()
        {
            _itemLocations = await _itemLocationHandler.GetAllByItemIdAsync(itemLocation);
        }
    }
}