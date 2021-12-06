using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
using ServerCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcLocationClient : ILocationDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private myGrpc.Location.LocationClient _client;

		public GrpcLocationClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}

		private gLocation ConvertLocationToGLocation(Entities.Models.Location from) {
			gLocation to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}

		private Entities.Models.Location ConvertGLocationToLocation(gLocation from) {
			Entities.Models.Location to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}
		private void Connect( ) {
			Console.WriteLine("+ Connecting to Server");

			_channel = GrpcChannel.ForAddress(_address);
			_client = new myGrpc.Location.LocationClient(_channel);
		}

		private async Task Disconnect( ) {
			Console.WriteLine("- Disconnecting from Server");

			await _channel.ShutdownAsync( );
			_client = null;
		}

		// IEntityManager Override Methods
		public async Task<Entities.Models.Location> RegisterAsync(Entities.Models.Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Entities.Models.Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}

		public async Task<Entities.Models.Location> RemoveAsync(Entities.Models.Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Entities.Models.Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}

		public async Task<Entities.Models.Location> UpdateAsync(Entities.Models.Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Entities.Models.Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}

		public async Task<IList<Entities.Models.Location>> GetAllAsync( ) {
			// Convert Location to gRPC Location | Here, it is specifically used as an Object Template for later
			gLocation template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gLocationList reply = await _client.GetAllLocationAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gLocation> gLocations = reply.Location;
			List<Entities.Models.Location> Locations = new( ) { };

			// Loop Through Collection of gLocations
			foreach (var g in gLocations) {
				// Convert each gLocation and add to list of Locations
				Locations.Add(ConvertGLocationToLocation(g));
			}

			// Return Location to User
			return Locations;
		}

		public async Task<Entities.Models.Location> GetAsync(Entities.Models.Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Entities.Models.Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}
	}

}
