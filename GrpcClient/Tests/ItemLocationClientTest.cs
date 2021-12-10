using Entities.Models;
using GrpcClient.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerCommunication;
using System.Threading.Tasks;
using T1Contracts.ServerCommunicationInterfaces;


namespace GrpcClient.Tests {
	[TestClass]
	public class ItemLocationClientTest {
		private GRPCConnStr grpcConnStr = new ();
		private IItemLocationDataServerComm _client;
		private Inventory _testItemLocation1, _testItemLocation2, _testItemLocation3;
		private Item _i1, _i2;
		private Location _l1, _l2;

		[TestInitialize]
		public void Setup( ) {
			_client = new GrpcItemLocationClient(grpcConnStr);
			_i1 = new( ) { Id = 0, ItemName = "The Answer to Life, The Universe, and Everything", Height = 420, Length = 69, Width = 727, Weight = 15 }; 
			_i2 = new( ) { Id = 0, ItemName = "Couch", Height = 74, Length = 84, Width = 35, Weight = 100 };
			_l1 = new( ) { Id = 0, Description = "The Universe" }; 
			_l2 = new( ) { Id = 0, Description = "Under the Couch" };
			var cItem = new GrpcItemClient(grpcConnStr);
			_i1 = cItem.RegisterAsync(_i1).Result;
			_i2 = cItem.RegisterAsync(_i2).Result;
			var cLocation = new GrpcLocationClient(grpcConnStr);
			_l1 = cLocation.RegisterAsync(_l1).Result;
			_l2 = cLocation.RegisterAsync(_l2).Result;

			_testItemLocation1 = new( ) { Id = 0, Amount = 101, Item = _i1, Location = _l1 };
			_testItemLocation2 = new( ) { Id = 0, Amount = 69, Item = _i2, Location = _l2 };
			_testItemLocation3 = new( ) { Id = 0, Amount = 69, Item = _i1, Location = _l2 };
		}

		[TestCleanup]
		public async Task TearDown( ) {
			await _client.RemoveAsync(_testItemLocation1.Id);
			await _client.RemoveAsync(_testItemLocation2.Id);
			await _client.RemoveAsync(_testItemLocation3.Id);
			var cItem = new GrpcItemClient(grpcConnStr);
			await cItem.RemoveAsync(_i1.Id);
			await cItem.RemoveAsync(_i2.Id);
			var cItemLocation = new GrpcLocationClient(grpcConnStr); 
			await cItemLocation.RemoveAsync(_l1.Id);
			await cItemLocation.RemoveAsync(_l2.Id);

		}

		[TestMethod("Register Inventory")] // Registering an Inventory | IMPLEMENTED : Register Inventory -> Check received Inventory = Input Inventory
		public async Task RegisterItemLocationAsync( ) {
			var result = await _client.RegisterAsync(_testItemLocation1);
			_testItemLocation1.Id = result.Id;
			
			Assert.IsNotNull(result);
			System.Console.WriteLine($"Inventory : {_testItemLocation1}\nResult       : {result}");
			Assert.IsTrue(_testItemLocation1.Equals(result));
			Assert.IsFalse(_testItemLocation1.Id == 0 && _testItemLocation2.Id == 0);
		}

		[TestMethod("Update Inventory")] // Updating an Inventory | CHECK : Register Inventory -> Change Weight of Inventory -> Update Inventory -> Check Inventory received = Input Inventory
		public async Task UpdateItemLocationAsync( ) {
			_testItemLocation1 = await _client.RegisterAsync(_testItemLocation1);
			_testItemLocation1.Amount = 5;
			var result = await _client.UpdateAsync(_testItemLocation1);

			System.Console.WriteLine($"Inventory : {_testItemLocation1}\nResult       : {result}");
			Assert.IsTrue(_testItemLocation1.Equals(result));
			Assert.IsFalse(_testItemLocation1.Id == 0 && _testItemLocation2.Id == 0);
		}

		[TestMethod("Get All ItemLocations")] // Getting an ItemLocationlist | CHECK : Register ItemLocations -> Get Inventory List -> Check ItemLocationlist contains Input ItemLocations
		public async Task GetAllItemLocationsAsync( ) {
			_testItemLocation1 = await _client.RegisterAsync(_testItemLocation1);
			_testItemLocation2 = await _client.RegisterAsync(_testItemLocation2);
			var result = await _client.GetAllAsync( );

			Assert.IsTrue(result.Contains(_testItemLocation1));
			Assert.IsTrue(result.Contains(_testItemLocation2));
			Assert.IsFalse(_testItemLocation1.Id == 0 && _testItemLocation2.Id == 0);
		}

		[TestMethod("Get Inventory")] // Getting a Single Inventory | CHECK : Register Inventory -> Get Inventory -> Check Inventory received = Input Inventory
		public async Task GetItemLocationAsync( ) {
			_testItemLocation1 = await _client.RegisterAsync(_testItemLocation1);

			var result = await _client.GetAsync(_testItemLocation1.Id);

			System.Console.WriteLine($"Inventory : {_testItemLocation1}\nResult       : {result}");
			Assert.IsTrue(_testItemLocation1.Equals(result));
			Assert.IsFalse(_testItemLocation1.Id == 0 && _testItemLocation2.Id == 0);
		}

		[TestMethod("Echo Get Inventory")] // Echoing Inventory | CHECK : Get Inventory -> Check Inventory received = Input Inventory
		public async Task EchoGetItemLocationAsync( ) {
			var result = await _client.GetAsync(_testItemLocation2.Id);

			System.Console.WriteLine($"Inventory : {_testItemLocation2}\nResult       : {result}");
			Assert.IsTrue(_testItemLocation2.Equals(result));
		}

		[TestMethod("Remove Inventory")] // Removing an Inventory | CHECK : Register Inventory -> Remove Inventory -> Check Inventory List does not contain Inventory
		public async Task RemoveItemLocationAsync( ) {
			_testItemLocation1 = await _client.RegisterAsync(_testItemLocation1);
			await _client.RemoveAsync(_testItemLocation1.Id);

			var result = await _client.GetAllAsync( );

			Assert.IsFalse(result.Contains(_testItemLocation1));
			Assert.IsFalse(_testItemLocation1.Id == 0 && _testItemLocation2.Id == 0);
		}
		
		[TestMethod("Get ItemLocations by item id")] 
		public async Task GetByItemIdAsync( ) {
			_testItemLocation1 = await _client.RegisterAsync(_testItemLocation1);
			_testItemLocation3 = await _client.RegisterAsync(_testItemLocation3);
			
			var result = await _client.GetAllByItemIdAsync(_testItemLocation1.Id);
			
			Assert.IsTrue(result.Contains(_testItemLocation1));
			Assert.IsTrue(result.Contains(_testItemLocation3));
			Assert.IsTrue(_testItemLocation1.Item.Id == _testItemLocation3.Item.Id );
		}
	}
}

