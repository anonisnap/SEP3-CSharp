using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class LocationsCard
    {
        [Parameter] public int ItemId { get; set; }

        private IList<Inventory> _inventories;

        protected override async Task OnInitializedAsync()
        {
            _inventories = await _inventoryHandler.GetAllByItemIdAsync(ItemId);
        }
    }
}