using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Pages.Overview
{
    public partial class RegisteredItems
    {
        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;
        
        private IList<Item> _registeredItems;

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - Before Async");

            _registeredItems = await _itemsHandler.GetAllAsync();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - After Async");

            foreach (var item in _registeredItems)
            {
                Console.WriteLine(item?.ItemName);
            }
        }
    }
}