using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Pages.Cards;
using Entities.Models;
using Radzen;

namespace Blazor.Pages
{
    public partial class Trashed
    {
        //TODO: ALT DETTE TRASHED LOGIK SKAL FLYTTES TIL TIER 2!!!!!!! - FØR AFLEVERING! ;))))


        private IList<Inventory> _inventories;

        //For Sorting amount:
        private IList<Item> _items;

        //Percentage trashed:
        private IList<int> _percentageTrashed;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPagerSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _inventories = await _inventoryHandler.GetAllByLocationIdAsync(1);
            DialogService.OnOpen += Open;
            DialogService.OnClose += Close;
        }


        /*
              private IList<Inventory> _itemLocationsTrashed;
    
         
        
        private void SortTrashed()
        {
            _itemLocationsTrashed = new List<Inventory>();
            foreach (var itemLocation in _inventories)
            {
                if (itemLocation.Location.Id == 1)
                {
                    _itemLocationsTrashed.Add(itemLocation);
                }
            }
            SortTrashedItems();
        }
    
        private void SortTrashedItems()
        {
            _items = new List<Item>();
            foreach (var itemLocation in _itemLocationsTrashed)
            {
                _items.Add(itemLocation.Item);
            }
    
        //Printout to see _items
            foreach (var item in _items)
            {
                Console.WriteLine("---------- LIST OF ITEMS ---------");
                Console.WriteLine(item);
            }
            
            PercentageTrashed();
        }
    
        
        private void PercentageTrashed()
        {
            Console.WriteLine("+++++++++++++ PercentageTrashed Started! ++++++++++++++++");
            List<TrashHelper> trashHelper_Trashed = new();
            List<TrashHelper> trashHelper_Total = new();
    
            foreach (var item in _items)
            {
                TrashHelper trashHelper = new();
                trashHelper.ItemId = item.Id;
                trashHelper_Total.Add(trashHelper);
                //New shit print to help
                foreach (var y in trashHelper_Total)
                {
                    Console.WriteLine($"-----------trashHelper_Total List + In Loop----------\n Item Id: {y.ItemId}\n" +
                                      $"Amount: {y.Amount}");
                }
                trashHelper_Trashed.Add(trashHelper);
                Console.WriteLine($"$$$$$$$$$$$$$$$$ TRASH ITEM ADDED $$$$$$$$$$ + {item}");
                Console.WriteLine(trashHelper.ItemId + ", " + trashHelper.Amount);
            }
    
        //ugly printout
            foreach (var x in trashHelper_Total)
            {
                Console.WriteLine("Ugly printout x: " + x.ItemId);
            }
            
            //Få total amount af items
            foreach (var itemLocation in _inventories)
            {
                foreach (var trashHelp in trashHelper_Total)
                {
                    if (itemLocation.Item.Id == trashHelp.ItemId)
                    {
                        trashHelp.Amount += itemLocation.Amount;
                        Console.WriteLine($"Item Id: {trashHelp.ItemId}" +
                                          $" \nCurrent Amount: {trashHelp.Amount}");
                    }
                }
            }
    */
        /*
            //Divider med trashed items
            foreach (var inventory in _itemLocationsTrashed)
            {
                inventory.Amount
            }
            #1#
            
            //*100
        }
        */


        async Task OpenLocationWithItems(Inventory inventory)
        {
            await DialogService.OpenAsync<LocationsCard>($"\nItem Name: {inventory.Item.ItemName}" +
                                                         $"Item Id {inventory.Item.Id}",
                new Dictionary<string, object>() {{"Inventory", inventory}},
                new DialogOptions()
                {
                    Width = "700px", Height = "530px",
                    CloseDialogOnOverlayClick = true, Resizable = true
                });
        }

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            Console.WriteLine("Dialog Opened");
        }

        void Close(dynamic result)
        {
            Console.WriteLine("Dialog closed");
        }
    }
}