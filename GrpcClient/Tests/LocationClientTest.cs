using Entities.Models;
using GrpcClient.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerCommunication;
using System.Threading.Tasks;

namespace GrpcClient.Tests {
	[TestClass]
	public class LocationClientTest {
		private IEntityManager<Location> _client;
		private Location _testLocation1, _testLocation2;

		[TestInitialize]
		public void Setup( ) {
			_client = new GrpcLocationClient(new GRPCConnStr());
			_testLocation1 = new ( ) { Id = 0, Description = "The Universe" };
			_testLocation2 = new ( ) { Id = 0, Description = "Under the Couch" };
		}

		[TestCleanup]
		public async Task TearDown( ) {
			await _client.RemoveAsync(_testLocation1);
			await _client.RemoveAsync(_testLocation2);
		}
		[TestMethod] // Registering an Location | IMPLEMENTED : Register Location -> Check received Location = Input Location
		public async Task RegisterLocationAsync( ) {
			var result = await _client.RegisterAsync(_testLocation1);
			Assert.IsNotNull(result);
			Assert.IsTrue(_testLocation1.Equals(result));
		}

		[TestMethod] // Updating an Location | IMPLEMENTED : Register Location -> Change Weight of Location -> Update Location -> Check Location received = Input Location
		public async Task UpdateLocationAsync( ) {
			await _client.RegisterAsync(_testLocation1);
			_testLocation2.Id = _testLocation1.Id;
			var result = await _client.UpdateAsync(_testLocation2);

			Assert.IsTrue(_testLocation2.Equals(result));
		}

		[TestMethod] // Getting an Locationlist | IMPLEMENTED : Register Locations -> Get Location List -> Check Locationlist contains Input Locations
		public async Task GetAllLocationsAsync( ) {
			await _client.RegisterAsync(_testLocation1);
			await _client.RegisterAsync(_testLocation2);
			var result = await _client.GetAllAsync( );

			Assert.IsTrue(result.Contains(_testLocation1));
			Assert.IsTrue(result.Contains(_testLocation2));
		}

		[TestMethod] // Getting a Single Location | IMPLEMENTED : Register Location -> Get Location -> Check Location received = Input Location
		public async Task GetLocationAsync( ) {
			await _client.RegisterAsync(_testLocation1);
			var result = await _client.GetAsync(_testLocation1);

			Assert.IsTrue(_testLocation1.Equals(result));
		}

		[TestMethod] // Echoing Location | IMPLEMENTED : Get Location -> Check Location received = Input Location
		public async Task EchoGetLocationAsync( ) {
			var result = await _client.GetAsync(_testLocation2);

			Assert.IsTrue(_testLocation2.Equals(result));
		}

		[TestMethod] // Removing an Location | IMPLEMENTED : Register Location -> Remove Location -> Check Location received = Input Location
		public async Task RemoveLocationAsync( ) {
			await _client.RegisterAsync(_testLocation1);
			var result = await _client.RemoveAsync(_testLocation1);

			Assert.IsTrue(_testLocation1.Equals(result));
		}

	}
}
