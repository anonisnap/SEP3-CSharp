using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class OrderCard
    {
        private IList<Order> _orders;
        
        [Parameter]
        public Order Order { set; get; }
        protected override async Task OnInitializedAsync()
        {
            //_orders = await _orderHandler.

        }

        private void OnChange(object value, string name)
        {
            //do something 
        }
    }
}