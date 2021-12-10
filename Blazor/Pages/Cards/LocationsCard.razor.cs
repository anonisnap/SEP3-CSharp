using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class LocationsCard
    {
        [Parameter]
        public Inventory Inventory { get; set; }
    
        private IList<Inventory> _itemLocations;


        protected override async Task OnInitializedAsync()
        {
            _itemLocations = await _inventoryHandler.GetAllByItemIdAsync(Inventory.Item.Id);
        }
    }
}