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
			Request putRequest = new Request(RequestType.PUT, nameof(Item), item);

			await _serverCommunication.SendToServer(putRequest);
			Console.WriteLine("just send to server");
		}

		public async Task<IList<Item>> GetItems( ) {
			//FIXME: Do I like correct and beautiful? - No idea --> arg?
			Request getRequest = new Request(RequestType.GET, nameof(Item), new List<Item>());
			await _serverCommunication.SendToServer(getRequest);
			
			string jsonObject = await _serverCommunication.GetFromServer( );
			return JsonSerializer.Deserialize<List<Item>>(jsonObject);

			//await _serverCommunication.GetItems();
			throw new System.NotImplementedException( );
		}

		public async Task<Item> GetItem(int itemId) {
			//TODO: MAKE ME PLEASE
			//await _serverCommunication.GetItem(itemId);
			Request getRequest = new Request(RequestType.GET, nameof(Item), new Item( ) { Id = itemId });
			await _serverCommunication.SendToServer(getRequest);
			string jsonObject = await _serverCommunication.GetFromServer( );
			return JsonSerializer.Deserialize<Item>(jsonObject);
			//throw new System.NotImplementedException();
		}

		public void Update(string jsonEntity)
		{
			throw new NotImplementedException();
		}
	}
}