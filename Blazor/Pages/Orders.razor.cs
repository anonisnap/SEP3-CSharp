using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages
{
    public partial class Orders
    {
        private IList<Order> _orders;

        protected override async Task OnInitializedAsync()
        {
            _orders = await _orderHandler.GetAllAsync();
        }
    }
}