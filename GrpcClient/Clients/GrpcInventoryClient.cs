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
			gInventory g = GrpcConverter.FromEntity.ToGInventory(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Inventory inventory = GrpcConverter.FromGEntity.ToInventory(reply);

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
			gInventory g = GrpcConverter.FromEntity.ToGInventory(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateInventoryAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Inventory inventory = GrpcConverter.FromGEntity.ToInventory(reply);

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
			List<Inventory> inventories = new( ) { };

			// Loop Through Collection of gInventorys
			foreach (var g in gInventorys) {
				// Convert each gInventory and add to list of Items
				inventories.Add(GrpcConverter.FromGEntity.ToInventory(g));
			}

			// Return Item to User
			return inventories;
		}
		
		public async Task<IList<Inventory>> GetInventoryStockAsync()
		{
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gInventory template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gInventoryList reply = await _client.GetStockInventoryAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gInventory> gInventorys = reply.Inventorys;
			List<Inventory> inventories = new( ) { };

			// Loop Through Collection of gInventorys
			foreach (var g in gInventorys) {
				// Convert each gInventory and add to list of Items
				inventories.Add(GrpcConverter.FromGEntity.ToInventory(g));
			}

			// Return Item to User
			return inventories;
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
			Inventory inventory = GrpcConverter.FromGEntity.ToInventory(reply);

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
				Inventorys.Add(GrpcConverter.FromGEntity.ToInventory(g));
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
				Inventorys.Add(GrpcConverter.FromGEntity.ToInventory(g));
			}
			
			await Disconnect();
			
			return Inventorys;
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
