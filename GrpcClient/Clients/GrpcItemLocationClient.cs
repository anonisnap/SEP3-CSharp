using Grpc.Net.Client;
using myGrpc;
using ServerCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient.Clients {
	internal class GrpcItemLocationClient : IEntityManager<Entities.Models.ItemLocation> {
		private string _address;
		private GrpcChannel _channel;
		private ItemLocation.ItemLocationClient _client;

		public GrpcItemLocationClient(string address) {
			_address = address;
		}

		private gItemLocation ConvertItemToGItemLocation(Entities.Models.ItemLocation from) {
			gItemLocation to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertItemToGItem(from.Item), Location = ConvertLocationToGLocation(from.Location) };
			return to;
		}

		private Entities.Models.ItemLocation ConvertGItemLocationToItem(gItemLocation from) {
			Entities.Models.ItemLocation to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertGItemToItem(from.Item), Location = ConvertGLocationToLocation(from.Location) };
			return to;
		}
		private gLocation ConvertLocationToGLocation(Entities.Models.Location from) {
			gLocation to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}

		private Entities.Models.Location ConvertGLocationToLocation(gLocation from) {
			Entities.Models.Location to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}
		private gItem ConvertItemToGItem(Entities.Models.Item from) {
			gItem to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}

		private Entities.Models.Item ConvertGItemToItem(gItem from) {
			Entities.Models.Item to = new( ) { Id = from.Id, ItemName = from.ItemName, Height = from.Height, Length = from.Length, Width = from.Width, Weight = from.Weight };
			return to;
		}

		private void Connect( ) {
			Console.WriteLine("+ Connecting to Server");

			_channel = GrpcChannel.ForAddress(_address);
			_client = new ItemLocation.ItemLocationClient(_channel);
		}

		private async Task Disconnect( ) {
			Console.WriteLine("- Disconnecting from Server");

			await _channel.ShutdownAsync( );
			_client = null;
		}

		// IEntityManager Override Methods
		public async Task<Entities.Models.ItemLocation> RegisterAsync(Entities.Models.ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItem(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<Entities.Models.ItemLocation> RemoveAsync(Entities.Models.ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItem(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<Entities.Models.ItemLocation> UpdateAsync(Entities.Models.ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItem(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<IList<Entities.Models.ItemLocation>> GetAllAsync( ) {
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gItemLocation template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gItemLocationList reply = await _client.GetAllItemLocationAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gItemLocation> gItemLocations = reply.ItemLocations;
			List<Entities.Models.ItemLocation> items = new( ) { };

			// Loop Through Collection of gItemLocations
			foreach (var g in gItemLocations) {
				// Convert each gItemLocation and add to list of Items
				items.Add(ConvertGItemLocationToItem(g));
			}

			// Return Item to User
			return items;
		}

		public async Task<Entities.Models.ItemLocation> GetAsync(Entities.Models.ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItem(reply);

			// Return Item to User
			return itemLocation;
		}
	}
}
