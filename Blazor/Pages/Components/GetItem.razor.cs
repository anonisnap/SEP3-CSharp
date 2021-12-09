using System;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.Components
{
    public partial class GetItem
    {
        public Item currentlyShownItem;
        public int searchItemid;

        protected override async Task OnInitializedAsync()
        {
            currentlyShownItem = new Item();
        }

        public async void GetItemAsync()
        {
            Console.WriteLine($"Attempting to retrieve item id: {searchItemid}");
            currentlyShownItem = await _itemHandler.GetAsync(searchItemid);
        }
    }
}