using Grpc.Net.Client;
using myGrpc;
using Entities.Models;
using ServerCommunication;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcItemClient : IItemDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private myGrpc.Item.ItemClient _client;

		public GrpcItemClient(string address) {
			_address = address;
		}

		private gItem ConvertItemToGItem(Entities.Models.Item from) {
			gItem to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}

		private Entities.Models.Item ConvertGItemToItem(gItem from) {
			Console.WriteLine($"Converting gItem to Item\nId: {from.Id}\nItemName: {from.ItemName}");
			Entities.Models.Item to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}
		private void Connect( ) {
			Console.WriteLine("+ Connecting to Server");

			_channel = GrpcChannel.ForAddress(_address);
			_client = new myGrpc.Item.ItemClient(_channel);
		}

		private async Task Disconnect( ) {
			Console.WriteLine("- Disconnecting from Server");

			await _channel.ShutdownAsync( );
			_client = null;
		}

		// IEntityManager Override Methods
		public async Task<Entities.Models.Item> RegisterAsync(Entities.Models.Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}

		public async Task<Entities.Models.Item> RemoveAsync(Entities.Models.Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}

		public async Task<Entities.Models.Item> UpdateAsync(Entities.Models.Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}

		public async Task<IList<Entities.Models.Item>> GetAllAsync( ) {
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gItem template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gItemList reply = await _client.GetAllItemAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gItem> gItems = reply.Item;
			List<Entities.Models.Item> items = new( ) { };

			// Loop Through Collection of gItems
			foreach(var g in gItems) {
				// Convert each gItem and add to list of Items
				items.Add(ConvertGItemToItem(g));
			}

			// Return Item to User
			return items;
		}

		public async Task<Entities.Models.Item> GetAsync(Entities.Models.Item entity) {
			// Convert Item to gRPC Item
			gItem g = ConvertItemToGItem(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetItemAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.Item item = ConvertGItemToItem(reply);

			// Return Item to User
			return item;
		}
	}
}
