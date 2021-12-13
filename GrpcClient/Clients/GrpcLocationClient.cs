using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
using System.Collections.Generic;
using System.Threading.Tasks;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcLocationClient : ILocationDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private LocationService.LocationServiceClient _client;

		public GrpcLocationClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}

		private gLocation ConvertLocationToGLocation(Location from) {
			gLocation to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}

		private Location ConvertGLocationToLocation(gLocation from) {
			Location to = new( ) { Id = from.Id, Description = from.Description };
			return to;
		}
		private void Connect( ) {
			_channel = GrpcChannel.ForAddress(_address);
			_client = new LocationService.LocationServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}

		// IEntityManager Override Methods
		public async Task<Location> RegisterAsync(Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RegisterLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}

		public async Task<bool> RemoveAsync(int locationId) {
			// Convert Location to gRPC Location
			gLocationId g = new gLocationId {LocationId = locationId};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.RemoveLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );
			
			
			return reply.Value;
		}

		public async Task<Location> UpdateAsync(Location entity) {
			// Convert Location to gRPC Location
			gLocation g = ConvertLocationToGLocation(entity);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}

		public async Task<IList<Location>> GetAllAsync( ) {
			// Convert Location to gRPC Location | Here, it is specifically used as an Object Template for later
			gLocation template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gLocationList reply = await _client.GetAllLocationsAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gLocation> gLocations = reply.Location;
			List<Location> Locations = new( ) { };

			// Loop Through Collection of gLocations
			foreach (var g in gLocations) {
				// Convert each gLocation and add to list of Locations
				Locations.Add(ConvertGLocationToLocation(g));
			}

			// Return Location to User
			return Locations;
		}

		public async Task<Location> GetAsync(int locationId) {
			// Convert Location to gRPC Location
			gLocationId g = new gLocationId {LocationId = locationId};

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetLocationAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Location to Location
			Location Location = ConvertGLocationToLocation(reply);

			// Return Location to User
			return Location;
		}
	}

}
