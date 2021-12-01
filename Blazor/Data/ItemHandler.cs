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

			await _serverCommunication.SendToServerReturn(this, "put", item);
			
			Console.WriteLine("just send to server");
		}

		public async Task<IList<Item>> GetItems( ) {
			
			//FIXME: Do I like correct and beautiful? - No idea --> arg?
			JsonElement jsonObject = (JsonElement) await _serverCommunication.SendToServerReturn(this, "getall", new Item());
			
			return JsonSerializer.Deserialize<List<Item>>(jsonObject.ToString(), 
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
			
		}

		public async Task<Item> GetItem(int itemId) {
			//TODO: MAKE ME PLEASE
			//await _serverCommunication.GetItem(itemId);
			Item templateItem = new Item() { Id = itemId };
			Console.WriteLine($"Template Item Type {templateItem.GetType().Name}");
			
			JsonElement itemJson =  (JsonElement) await _serverCommunication.SendToServerReturn(this, "get", templateItem);
			
			Item item = JsonSerializer.Deserialize<Item>( itemJson.ToString(), 
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
			
			Console.WriteLine($"> item handler resived {item.Id} {item.GetType()} ");

			return item;
			
		}

		public void Update(string jsonEntity)
		{
			throw new NotImplementedException();
		}
	}
}