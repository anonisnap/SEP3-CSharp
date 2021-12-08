using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages
{
    public partial class CreateOrder
    {
        private Order _order;
            
            protected override async Task OnInitializedAsync()
            {
                _order = new();
            }
        
            private async Task CreateNewOrder()
            {
                await _orderHandler.RegisterAsync(_order);
                _navigationManager.NavigateTo("/Orders");
            }
    }
}