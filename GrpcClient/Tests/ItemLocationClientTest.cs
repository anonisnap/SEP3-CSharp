using Entities.Models;
using GrpcClient.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerCommunication;
using System.Threading.Tasks;


namespace GrpcClient.Tests {
	[TestClass]
	public class ItemLocationClientTest {
		private string _url = "http://localhost:9090";
		private IEntityManager<ItemLocation> _client;
		private ItemLocation _testItemLocation1, _testItemLocation2;
		private Item _i1, _i2;
		private Location _l1, _l2;

		[TestInitialize]
		public void Setup( ) {
			_client = new GrpcItemLocationClient(_url);
			_i1 = new( ) { Id = 0, ItemName = "The Answer to Life, The Universe, and Everything", Height = 420, Length = 69, Width = 727, Weight = 15 }; 
			_i2 = new( ) { Id = 0, ItemName = "Couch", Height = 74, Length = 84, Width = 35, Weight = 100 };
			_l1 = new( ) { Id = 0, Description = "The Universe" }; 
			_l2 = new( ) { Id = 0, Description = "Under the Couch" };
			var cItem = new GrpcItemClient(_url);
			_i1 = cItem.RegisterAsync(_i1).Result;
			_i2 = cItem.RegisterAsync(_i2).Result;
			var cLocation = new GrpcLocationClient(_url);
			_l1 = cLocation.RegisterAsync(_l1).Result;
			_l2 = cLocation.RegisterAsync(_l2).Result;

			_testItemLocation1 = new( ) { Id = 0, Amount = 101, Item = _i1, Location = _l1 };
			_testItemLocation2 = new( ) { Id = 0, Amount = 69, Item = _i2, Location = _l2 };
		}

		[TestCleanup]
		public async Task TearDown( ) {
			var cItem = new GrpcItemClient(_url);
			await cItem.RemoveAsync(_i1);
			await cItem.RemoveAsync(_i2 );
			var cLocation = new GrpcLocationClient(_url); 
			await cLocation.RemoveAsync(_l1);
			await cLocation.RemoveAsync(_l2);

			await _client.RemoveAsync(_testItemLocation1);
			await _client.RemoveAsync(_testItemLocation2);
		}

		[TestMethod] // Registering an ItemLocation | IMPLEMENTED : Register ItemLocation -> Check received ItemLocation = Input ItemLocation
		public async Task RegisterItemLocationAsync( ) {
			var result = await _client.RegisterAsync(_testItemLocation1);
			Assert.IsNotNull(result);
			Assert.IsTrue(_testItemLocation1.Equals(result));
		}

		[TestMethod] // Updating an ItemLocation | IMPLEMENTED : Register ItemLocation -> Change Weight of ItemLocation -> Update ItemLocation -> Check ItemLocation received = Input ItemLocation
		public async Task UpdateItemLocationAsync( ) {
			await _client.RegisterAsync(_testItemLocation1);
			_testItemLocation2.Id = _testItemLocation1.Id;
			var result = await _client.UpdateAsync(_testItemLocation2);

			Assert.IsTrue(_testItemLocation2.Equals(result));
		}

		[TestMethod] // Getting an ItemLocationlist | IMPLEMENTED : Register ItemLocations -> Get ItemLocation List -> Check ItemLocationlist contains Input ItemLocations
		public async Task GetAllItemLocationsAsync( ) {
			var x = await _client.RegisterAsync(_testItemLocation1);
			var y = await _client.RegisterAsync(_testItemLocation2);
			var result = await _client.GetAllAsync( );

			

			Assert.IsTrue(result.Contains(x));
			Assert.IsTrue(result.Contains(y));
		}

		[TestMethod] // Getting a Single ItemLocation | IMPLEMENTED : Register ItemLocation -> Get ItemLocation -> Check ItemLocation received = Input ItemLocation
		public async Task GetItemLocationAsync( ) {
			await _client.RegisterAsync(_testItemLocation1);
			var result = await _client.GetAsync(_testItemLocation1);

			Assert.IsTrue(_testItemLocation1.Equals(result));
		}

		[TestMethod] // Echoing ItemLocation | IMPLEMENTED : Get ItemLocation -> Check ItemLocation received = Input ItemLocation
		public async Task EchoGetItemLocationAsync( ) {
			var result = await _client.GetAsync(_testItemLocation2);

			Assert.IsTrue(_testItemLocation2.Equals(result));
		}

		[TestMethod] // Removing an ItemLocation | IMPLEMENTED : Register ItemLocation -> Remove ItemLocation -> Check ItemLocation received = Input ItemLocation
		public async Task RemoveItemLocationAsync( ) {
			await _client.RegisterAsync(_testItemLocation1);
			var result = await _client.RemoveAsync(_testItemLocation1);

			Assert.IsTrue(_testItemLocation1.Equals(result));
		}

	}
}

