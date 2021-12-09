using Grpc.Net.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using myGrpc;
using T1Contracts.ServerCommunicationInterfaces;
using Item = Entities.Models.Item;

namespace GrpcClient.Clients {
	public class GrpcItemClient : IItemDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private ItemService.ItemServiceClient _client;

		public GrpcItemClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}
		
		// IEntityManager Override Methods
		public async Task<Item> RegisterAsync(Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterItemAsync(g);
			
			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Item item = ConvertGItemToItem(reply);
		
			// Return Item to User
			return item;
		}

		public async Task<Item> RemoveAsync(int id) {
			// Convert Item to gRPC Item
			gItemId g = new gItemId {ItemId = id};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}

		public async Task<Item> UpdateAsync(Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}

		public async Task<IList<Item>> GetAllAsync( ) {
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gItem template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gItemList reply = await _client.GetAllItemsAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gItem> gItems = reply.Item;
			List<Item> items = new( ) { };

			// Loop Through Collection of gItems
			foreach(var g in gItems) {
				// Convert each gItem and add to list of Items
				items.Add(ConvertGItemToItem(g));
			}

			// Return Item to User
			return items;
		}

		public async Task<Item> GetAsync(int id) {
			// Convert Item to gRPC Item
			gItemId g = new gItemId {ItemId = id};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
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
			_client = new ItemService.ItemServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}
		
	}
}
