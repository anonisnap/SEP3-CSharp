using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.DataManipulation
{
    public partial class RegisterItem
    {
        private Item _item;

        protected override async Task OnInitializedAsync()
        {
            _item = new();
        }

        private async Task AddNewItem()
        {
            await _itemsHandler.RegisterAsync(_item);
            //Navigate to specific Item created instead?
            _navigationManager.NavigateTo("/RegisteredItems");
        }
    }
}