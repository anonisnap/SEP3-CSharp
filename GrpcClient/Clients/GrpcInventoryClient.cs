using Grpc.Net.Client;
using myGrpc;

using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcInventoryClient : IInventoryDataServerComm {
		
		private string _address;
		private GrpcChannel _channel;
		private InventoryService.InventoryServiceClient _client;

		public GrpcInventoryClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}

		// IEntityManager Override Methods
		public async Task<Inventory> RegisterAsync(Inventory entity) {
			// Convert Item to gRPC Item
			gInventory g = ConvertInventoryToGInventory(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Inventory inventory = ConvertGInventoryToInventory(reply);

			// Return Item to User
			return inventory;
		}

		public async Task<bool> RemoveAsync(int id) {
			// Convert Item to gRPC Item
			gInventoryId g = new gInventoryId {InventoryId = id};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );
			
			return reply.Value;
		}

		public async Task<Inventory> UpdateAsync(Inventory entity) {
			// Convert Item to gRPC Item
			gInventory g = ConvertInventoryToGInventory(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Inventory inventory = ConvertGInventoryToInventory(reply);

			// Return Item to User
			return inventory;
		}

		public async Task<IList<Inventory>> GetAllAsync( ) {
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gInventory template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gInventoryList reply = await _client.GetAllInventoryAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gInventory> gInventorys = reply.Inventorys;
			List<Inventory> items = new( ) { };

			// Loop Through Collection of gInventorys
			foreach (var g in gInventorys) {
				// Convert each gInventory and add to list of Items
				items.Add(ConvertGInventoryToInventory(g));
			}

			// Return Item to User
			return items;
		}

		public async Task<Inventory> GetAsync(int id) {
			// Convert Item to gRPC Item
			gInventoryId g = new gInventoryId {InventoryId = id};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Inventory inventory = ConvertGInventoryToInventory(reply);

			// Return Item to User
			return inventory;
		}

		public async Task<IList<Inventory>> GetAllByItemIdAsync(int itemId)
		{
			List<Inventory> Inventorys = new ();

			gItemId gItemId = new gItemId {ItemId = itemId};
			Connect();

			var reply = await _client.GetByItemIdAsync(gItemId);
			
			ICollection<gInventory> gInventorys = reply.Inventorys;
			// Loop Through Collection of gInventorys
			foreach (var g in gInventorys) {
				// Convert each gInventory and add to list of Items
				Inventorys.Add(ConvertGInventoryToInventory(g));
			}
			
			await Disconnect();
			
			return Inventorys;
		}

		public async Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId)
		{
			List<Inventory> Inventorys = new ();

			gLocationId gLocationId = new gLocationId {LocationId = locationId};
			
			Connect();

			var reply = await _client.GetByLocationIdAsync(gLocationId);
			
			ICollection<gInventory> gInventorys = reply.Inventorys;
			// Loop Through Collection of gInventorys
			foreach (var g in gInventorys) {
				// Convert each gInventory and add to list of Items
				Inventorys.Add(ConvertGInventoryToInventory(g));
			}
			
			await Disconnect();
			
			return Inventorys;
		}


		private gInventory ConvertInventoryToGInventory(Inventory from) {
			gInventory to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertItemToGItem(from.Item), Location = ConvertLocationToGLocation(from.Location) };
			return to;
		}

		private Inventory ConvertGInventoryToInventory(gInventory from) {
			Inventory to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertGItemToItem(from.Item), Location = ConvertGLocationToLocation(from.Location) };
			return to;
		}
		
		private gLocation ConvertLocationToGLocation(Location from) {
			gLocation to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}

		private Location ConvertGLocationToLocation(gLocation from) {
			Location to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}
		private gItem ConvertItemToGItem(Item from) {
			gItem to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}

		private Item ConvertGItemToItem(gItem from) {
			Item to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}

		private void Connect( ) {
			_channel = GrpcChannel.ForAddress(_address);
			_client = new InventoryService.InventoryServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}

		
	}
}
