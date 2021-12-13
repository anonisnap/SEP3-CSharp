using System.Collections.Generic;
using Entities.Models;
using myGrpc;

namespace GrpcClient.Clients
{
    public class GrpcConverter
    {

        public static class FromGEntity
        {
            
            public static Inventory ToInventory(gInventory from) {
                Inventory to = new( ) { Id = from.Id, Amount = from.Amount, Item = ToItem(from.Item), Location = ToLocation(from.Location) };
                return to;
            }

            public static Location ToLocation(gLocation from) {
                Location to = new( ) { Id = from.Id, Description = from.Description };
                return to;
            }

            public static Item ToItem(gItem from) {
                Item to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
                return to;
            }
            
            public static Order ToOrder(gOrder gO) {
	            List<OrderEntry> oE = new( );
	            foreach (gOrderEntry e in gO.OrderEntries) {
		            oE.Add(ToOrderEntry(e));
	            }
	            Order o = new Order { Id = gO.Id, OrderNumber = gO.OrderNumber, Location = new Location { Id = gO.Location.Id, Description = gO.Location.Description } };
	            o.OrderEntries = oE;
	            return o;
            }
            public static OrderEntry ToOrderEntry(gOrderEntry gE) {
	            return new OrderEntry {
		            Id = gE.Id,
		            OrderId = gE.OrderId,
		            IsPicked = gE.IsPicked,
		            Item = new Item {
			            Id = gE.Item.Id,
			            ItemName = gE.Item.ItemName,
			            Height = gE.Item.Height,
			            Length = gE.Item.Length,
			            Width = gE.Item.Width,
			            Weight = gE.Item.Weight
		            },
		            Amount = gE.Amount
	            };
            }

        }


        public static class FromEntity
        {
            
            public static gLocation ToGLocation(Location from) {
                gLocation to = new( ) { Id = from.Id, Description = from.Description };
                return to;
            }
            
            public static gInventory ToGInventory(Inventory from) {
                gInventory to = new( ) { Id = from.Id, Amount = from.Amount, Item = ToGItem(from.Item), Location = ToGLocation(from.Location) };
                return to;
            }
            
            public static gItem ToGItem(Item from) {
                gItem to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
                return to;
            }
            
            public static gOrder ToGOrder(Order o) {
	            // Create gOrderEntry list
	            List<gOrderEntry> gE = new( );
        
	            // Loop through Order (parameter) Entries and create a gOrderEntry object, to add to gOrderEntry list
	            o.OrderEntries.ForEach(entry => gE.Add(ToGOrderEntry(entry)));
        
	            // Create gOrder Object
	            gOrder gO = new gOrder { Id = o.Id, OrderNumber = o.OrderNumber, Location = new gLocation { Id = o.Location.Id, Description = o.Location.Description } };
        
	            // Add gOrderEntries to gOrder
	            gO.OrderEntries.AddRange(gE);
        
	            return gO;
            }

            public static gOrderEntry ToGOrderEntry(OrderEntry e) {
	            return new gOrderEntry {
		            Id = e.Id,
		            OrderId = e.OrderId,
		            IsPicked = e.IsPicked,
		            Item = new gItem {
			            Id = e.Item.Id,
			            ItemName = e.Item.ItemName,
			            Height = e.Item.Height,
			            Length = e.Item.Length,
			            Width = e.Item.Width,
			            Weight = e.Item.Weight
		            },
		            Amount = e.Amount
	            };
        
            }
            
            public static gInventoryList ToGInventoryList(List<Inventory> inventories)
            {
	            
	            gInventoryList gInventoryList = new gInventoryList();
			
	            inventories
		            .ForEach(inventory => gInventoryList.Inventorys
			            .Add(ToGInventory(inventory)));
	            return gInventoryList;
            }

            public static gOrderProcess ToGOrderProcess(Order order, List<Inventory> pickInventories)
            {
	            gOrderProcess gOrderProcess = new gOrderProcess();
	            gOrderProcess.Order = ToGOrder(order);
	            gOrderProcess.PickInventories = ToGInventoryList(pickInventories);
	            return gOrderProcess;
            }
            
        }
        
    }
}