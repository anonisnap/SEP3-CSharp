using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data {
	public class ItemHandler : IItemHandler {
		//TODO: Jeg mangler i astah ;(
		private IServerCommunication _serverCommunication;

		public ItemHandler(IServerCommunication serverCommunication) {
			_serverCommunication = serverCommunication;
		}

		public async Task RegisterItem(Item item) {
			Console.WriteLine("ItemHandler.RegisterItem");

			await _serverCommunication.SendToServer(this, "put", item);
			Console.WriteLine("just send to server");
		}

		public async Task<IList<Item>> GetItems( ) {
			//FIXME: Do I like correct and beautiful? - No idea --> arg?
			await _serverCommunication.SendToServer(this, "get", null);
			
			//return JsonSerializer.Deserialize<List<Item>>(jsonObject);

			//await _serverCommunication.GetItems();
			throw new System.NotImplementedException( );
		}

		public async Task<Item> GetItem(int itemId) {
			//TODO: MAKE ME PLEASE
			//await _serverCommunication.GetItem(itemId);
			Item templateItem = new Item() { Id = itemId };
			Console.WriteLine($"Template Item Type {templateItem.GetType().Name}");
			await _serverCommunication.SendToServer(this, "get", templateItem);


			return null;
			//return JsonSerializer.Deserialize<Item>(jsonObject);

			//throw new System.NotImplementedException( );
		}

		public void Update(string jsonEntity)
		{
			throw new NotImplementedException();
		}
	}
}