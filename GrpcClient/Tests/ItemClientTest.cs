using ServerCommunication;
using Entities.Models;
using GrpcClient.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrpcClient.Tests {
	[TestClass]
	public class ItemClientTest {
		private IEntityManager<Item> _client;
		private Item _testItem1, _testItem2;

		[TestInitialize()]
		public void Setup( ) {
			_client = new GrpcItemClient("http://localhost:9090");
			_testItem1 = new( ) { Id = 0, ItemName = "The Answer to Life, The Universe, and Everything", Height = 420, Length = 69, Width = 727, Weight = 15 };
			_testItem2 = new( ) { Id = 0, ItemName = "Couch", Height = 74, Length = 84, Width = 35, Weight = 100 };
		}

		[TestCleanup()]
		public async Task TearDown( ) {
			Console.WriteLine($"Removing Item ID : {_testItem1.Id}");
			await _client.RemoveAsync(_testItem1);
			Console.WriteLine($"Removing Item ID : {_testItem2.Id}");
			await _client.RemoveAsync(_testItem2);
		}

		[TestMethod("Register Item")] // Registering an Item | IMPLEMENTED : Register Item -> Check received Item = Input Item
		public async Task RegisterItemAsync( ) {
			var result = await _client.RegisterAsync(_testItem1);

			Console.WriteLine($"Result from Server: {result}");

			_testItem2 = result;
			Assert.IsNotNull(result);
			Assert.IsTrue(_testItem1.Equals(result));
		}

		[TestMethod("Update Item")] // Updating an Item | IMPLEMENTED : Register Item -> Change Weight of Item -> Update Item -> Check Item received = Input Item
		public async Task UpdateItemAsync( ) {
			await _client.RegisterAsync(_testItem1);
			_testItem2.Id = _testItem1.Id;
			var result = await _client.UpdateAsync(_testItem2);

			Assert.IsTrue(_testItem2.Equals(result));
		}

		[TestMethod("Get All Items")] // Getting an Itemlist | IMPLEMENTED : Register Items -> Get Item List -> Check Itemlist contains Input Items
		public async Task GetAllItemsAsync( ) {
			_testItem1 = await _client.RegisterAsync(_testItem1);
			_testItem2 = await _client.RegisterAsync(_testItem2);
			var result = await _client.GetAllAsync( );

			Assert.IsTrue(result.Contains(_testItem1));
			Assert.IsTrue(result.Contains(_testItem2));
		}

		[TestMethod("Get Item")] // Getting a Single Item | IMPLEMENTED : Register Item -> Get Item -> Check Item received = Input Item
		public async Task GetItemAsync( ) {
			await _client.RegisterAsync(_testItem1);
			var result = await _client.GetAsync(_testItem1);

			Assert.IsTrue(_testItem1.Equals(result));
		}

		[TestMethod("Echo Get Item")] // Echoing Item | IMPLEMENTED : Get Item -> Check Item received = Input Item
		public async Task EchoGetItemAsync( ) {
			var result = await _client.GetAsync(_testItem2);

			Assert.IsTrue(_testItem2.Equals(result));
		}

		[TestMethod("Remove Item")] // Removing an Item | IMPLEMENTED : Register Item -> Remove Item -> Check Item received = Input Item
		public async Task RemoveItemAsync( ) {
			await _client.RegisterAsync(_testItem1);
			var result = await _client.RemoveAsync(_testItem1);

			Assert.IsTrue(_testItem1.Equals(result));
		}

	}
}
