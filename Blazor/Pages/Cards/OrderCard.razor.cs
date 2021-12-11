using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages.Cards
{
    public partial class OrderCard
    {

        private Inventory _selectedInventory;
        private int _amount;
        
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
        
        
        public void InventoryChanged(Inventory inventory)
        {
            _selectedInventory = inventory;
        }
        
        public void AmountChanged(int amount)
        {
            _amount = amount;
        }
    }
}