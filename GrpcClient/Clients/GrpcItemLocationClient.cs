using Grpc.Net.Client;
using myGrpc;
using ServerCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1Contracts.ServerCommunicationInterfaces;
using ItemLocation = Entities.Models.ItemLocation;

namespace GrpcClient.Clients {
	public class GrpcItemLocationClient : IItemLocationDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private myGrpc.ItemLocation.ItemLocationClient _client;

		public GrpcItemLocationClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}

		// IEntityManager Override Methods
		public async Task<Entities.Models.ItemLocation> RegisterAsync(ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemLocationToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItemLocation(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<Entities.Models.ItemLocation> RemoveAsync(ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemLocationToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItemLocation(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<Entities.Models.ItemLocation> UpdateAsync(Entities.Models.ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemLocationToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			Entities.Models.ItemLocation itemLocation = ConvertGItemLocationToItemLocation(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<IList<ItemLocation>> GetAllAsync( ) {
			// Convert Item to gRPC Item | Here, it is specifically used as an Object Template for later
			gItemLocation template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gItemLocationList reply = await _client.GetAllItemLocationsAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gItemLocation> gItemLocations = reply.ItemLocations;
			List<ItemLocation> items = new( ) { };

			// Loop Through Collection of gItemLocations
			foreach (var g in gItemLocations) {
				// Convert each gItemLocation and add to list of Items
				items.Add(ConvertGItemLocationToItemLocation(g));
			}

			// Return Item to User
			return items;
		}

		public async Task<ItemLocation> GetAsync(ItemLocation entity) {
			// Convert Item to gRPC Item
			gItemLocation g = ConvertItemLocationToGItemLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetItemLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Item to Item
			ItemLocation itemLocation = ConvertGItemLocationToItemLocation(reply);

			// Return Item to User
			return itemLocation;
		}

		public async Task<IList<ItemLocation>> GetAllByItemIdAsync(ItemLocation itemLocation)
		{
			List<ItemLocation> itemLocations = new ();
			
			gItemLocation gItemLocation = ConvertItemLocationToGItemLocation(itemLocation);
			
			Connect();

			var reply = await _client.GetByItemIdAsync(gItemLocation);
			
			ICollection<gItemLocation> gItemLocations = reply.ItemLocations;
			// Loop Through Collection of gItemLocations
			foreach (var g in gItemLocations) {
				// Convert each gItemLocation and add to list of Items
				itemLocations.Add(ConvertGItemLocationToItemLocation(g));
			}
			
			await Disconnect();
			
			return itemLocations;
		}

		public async Task<IList<ItemLocation>> GetAllByLocationIdAsync(ItemLocation itemLocation)
		{
			List<ItemLocation> itemLocations = new ();
			
			gItemLocation gItemLocation = ConvertItemLocationToGItemLocation(itemLocation);
			
			Connect();

			var reply = await _client.GetByLocationIdAsync(gItemLocation);
			
			ICollection<gItemLocation> gItemLocations = reply.ItemLocations;
			// Loop Through Collection of gItemLocations
			foreach (var g in gItemLocations) {
				// Convert each gItemLocation and add to list of Items
				itemLocations.Add(ConvertGItemLocationToItemLocation(g));
			}
			
			await Disconnect();
			
			return itemLocations;
		}


		private gItemLocation ConvertItemLocationToGItemLocation(Entities.Models.ItemLocation from) {
			gItemLocation to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertItemToGItem(from.Item), Location = ConvertLocationToGLocation(from.Location) };
			return to;
		}

		private Entities.Models.ItemLocation ConvertGItemLocationToItemLocation(gItemLocation from) {
			ItemLocation to = new( ) { Id = from.Id, Amount = from.Amount, Item = ConvertGItemToItem(from.Item), Location = ConvertGLocationToLocation(from.Location) };
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
			_channel = GrpcChannel.ForAddress(_address);
			_client = new myGrpc.ItemLocation.ItemLocationClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}

		
	}
}
