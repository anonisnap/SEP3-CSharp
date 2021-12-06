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
			_testLocation1 = new( ) { Id = 0, Description = "ThereIsNoWayThisCanBeADuplicateStringYouTwat" };
			_testLocation2 = new( ) { Id = 0, Description = "Under the Couch" };
		}

		[TestCleanup]
		public async Task TearDown( ) {
			System.Console.WriteLine($"Removing {_testLocation1.Id}");
			await _client.RemoveAsync(_testLocation1);
			System.Console.WriteLine($"Removing {_testLocation2.Id}");
			await _client.RemoveAsync(_testLocation2);
		}

		[TestMethod("Register Location")] // Registering an Location | IMPLEMENTED : Register Location -> Check received Location = Input Location
		public async Task RegisterLocationAsync( ) {
			var result = await _client.RegisterAsync(_testLocation1);
			System.Console.WriteLine($"Location Id : {_testLocation1.Id}\nResult Id : {result.Id}");
			_testLocation1.Id = result.Id;
			Assert.IsNotNull(result);
			Assert.IsTrue(_testLocation1.Equals(result));
		}

		[TestMethod("Update Location")] // Updating an Location | IMPLEMENTED : Register Location -> Change Weight of Location -> Update Location -> Check Location received = Input Location
		public async Task UpdateLocationAsync( ) {
			_testLocation1 = await _client.RegisterAsync(_testLocation1);
			_testLocation2.Id = _testLocation1.Id;
			var result = await _client.UpdateAsync(_testLocation2);

			Assert.IsTrue(_testLocation2.Equals(result));
		}

		[TestMethod("Get All Locations")] // Getting an Locationlist | IMPLEMENTED : Register Locations -> Get Location List -> Check Locationlist contains Input Locations
		public async Task GetAllLocationsAsync( ) {
			_testLocation1 = await _client.RegisterAsync(_testLocation1);
			System.Console.WriteLine($"{_testLocation1} has been registered");
			_testLocation2 = await _client.RegisterAsync(_testLocation2);
			System.Console.WriteLine($"{_testLocation2} has been registered");
			var result = await _client.GetAllAsync( );

			Assert.IsTrue(result.Contains(_testLocation1));
			Assert.IsTrue(result.Contains(_testLocation2));
		}

		[TestMethod("Get Location")] // Getting a Single Location | IMPLEMENTED : Register Location -> Get Location -> Check Location received = Input Location
		public async Task GetLocationAsync( ) {
			_testLocation1 = await _client.RegisterAsync(_testLocation1);
			var result = await _client.GetAsync(_testLocation1);

			Assert.IsTrue(_testLocation1.Equals(result));
		}

		[TestMethod("Echo Get Location")] // Echoing Location | IMPLEMENTED : Get Location -> Check Location received = Input Location
		public async Task EchoGetLocationAsync( ) {
			var result = await _client.GetAsync(_testLocation2);

			Assert.IsTrue(_testLocation2.Equals(result));
		}

		[TestMethod("Remove Location")] // Removing an Location | IMPLEMENTED : Register Location -> Remove Location -> Check Location List does not contain Location
		public async Task RemoveLocationAsync( ) {
			_testLocation1 = await _client.RegisterAsync(_testLocation1);
			await _client.RemoveAsync(_testLocation1);

			var result = await _client.GetAllAsync( );

			Assert.IsFalse(result.Contains(_testLocation1));
		}

	}
}
