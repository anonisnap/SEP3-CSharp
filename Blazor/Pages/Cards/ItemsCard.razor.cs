using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class ItemsCard
    {
        private IList<ItemLocation> _itemLocations;

        [Parameter]
        public ItemLocation itemLocation { set; get; }

        protected override async Task OnInitializedAsync()
        {
            _itemLocations = await _itemLocationHandler.GetAllByLocationIdAsync(itemLocation);
        }
    }
}