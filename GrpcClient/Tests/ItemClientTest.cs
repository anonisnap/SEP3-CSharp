using Entities.Models;
using GrpcClient.Clients;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Tests {
	
	[TestClass]
	public class ItemClientTest {
		private IItemDataServerComm _client;
		private Item _testItem1, _testItem2;

		[TestInitialize( )]
		public void Setup( ) {
			_client = new GrpcItemClient(new GRPCConnStr());
			_testItem1 = new( ) { Id = 0, ItemName = "The Answer to Life, The Universe, and Everything", Height = 420, Length = 69, Width = 727, Weight = 15 };
			_testItem2 = new( ) { Id = 0, ItemName = "Couch", Height = 74, Length = 84, Width = 35, Weight = 100 };
		}

		[TestCleanup( )]
		public async Task TearDown( ) {
			Console.WriteLine($"Removing Item ID : {_testItem1.Id}");
			await _client.RemoveAsync(_testItem1.Id);
			Console.WriteLine($"Removing Item ID : {_testItem2.Id}");
			await _client.RemoveAsync(_testItem2.Id);
			await _client.RemoveAsync(_testItem2.Id);
		}

		[TestMethod("Register Item")] // Registering an Item | IMPLEMENTED : Register Item -> Check received Item = Input Item
		public async Task RegisterItemAsync( ) {
			var result = await _client.RegisterAsync(_testItem1);
			_testItem1.Id = result.Id;

			Assert.IsNotNull(result);
			System.Console.WriteLine($"Item Id : {_testItem1.Id}\nResult Id   : {result.Id}");
			Assert.IsTrue(_testItem1.Equals(result));
			Assert.IsFalse(_testItem1.Id == 0 && _testItem2.Id == 0);
		}

		[TestMethod("Update Item")] // Updating an Item | IMPLEMENTED : Register Item -> Change Weight of Item -> Update Item -> Check Item received = Input Item
		public async Task UpdateItemAsync( ) {
			_testItem1 = await _client.RegisterAsync(_testItem1);
			System.Console.WriteLine($"Returned Item : {_testItem1}");
			_testItem1.ItemName = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var result = await _client.UpdateAsync(_testItem1);

			System.Console.WriteLine($"Item Id : {_testItem1.Id}\nResult Id   : {result.Id}");
			Assert.IsTrue(_testItem1.Equals(result));
			Assert.IsFalse(_testItem1.Id == 0 && _testItem2.Id == 0);
		}

		[TestMethod("Get All Items")] // Getting an Itemlist | IMPLEMENTED : Register Items -> Get Item List -> Check Itemlist contains Input Items
		public async Task GetAllItemsAsync( ) {
			_testItem1 = await _client.RegisterAsync(_testItem1);
			System.Console.WriteLine($"{_testItem1} has been registered");
			_testItem2 = await _client.RegisterAsync(_testItem2);
			System.Console.WriteLine($"{_testItem2} has been registered");
			var result = await _client.GetAllAsync( );

			Assert.IsTrue(result.Contains(_testItem1));
			Assert.IsTrue(result.Contains(_testItem2));
			Assert.IsFalse(_testItem1.Id == 0 && _testItem2.Id == 0);
		}

		[TestMethod("Get Item")] // Getting a Single Item | IMPLEMENTED : Register Item -> Get Item -> Check Item received = Input Item
		public async Task GetItemAsync( ) {
			_testItem1 = await _client.RegisterAsync(_testItem1);
			var result = await _client.GetAsync(_testItem1.Id);

			System.Console.WriteLine($"Item Id : {_testItem1.Id}\nResult Id   : {result.Id}");
			Assert.IsTrue(_testItem1.Equals(result));
			Assert.IsFalse(_testItem1.Id == 0 && _testItem2.Id == 0);
		}

		[TestMethod("Echo Get Item")] // Echoing Item | IMPLEMENTED : Get Item -> Check Item received = Input Item
		public async Task EchoGetItemAsync( ) {
			var result = await _client.GetAsync(_testItem2.Id);

			Assert.IsTrue(_testItem2.Equals(result));
		}

		[TestMethod("Remove Item")] // Removing an Item | IMPLEMENTED : Register Item -> Remove Item -> Check Item List does not contain Item
		public async Task RemoveItemAsync( ) {
			_testItem1 = await _client.RegisterAsync(_testItem1);
			await _client.RemoveAsync(_testItem1.Id);

			var result = await _client.GetAllAsync( );

			Assert.IsFalse(result.Contains(_testItem1));
			Assert.IsFalse(_testItem1.Id == 0 && _testItem2.Id == 0);
		}
	}
}
