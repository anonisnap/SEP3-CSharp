using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class ItemsCard
    {
        private IList<Inventory> _itemLocations;

        [Parameter]
        public Inventory Inventory { set; get; }

        protected override async Task OnInitializedAsync()
        {
            _itemLocations = await _inventoryHandler.GetAllByLocationIdAsync(Inventory.Location.Id);
        }
    }
}