using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace ServerCommunication
{
    public class ItemDataServerComm: IItemDataServerComm
    {
        
        private IServerCommunication _serverCommunication;


        public ItemDataServerComm(IServerCommunication serverCommunication)
        {
            _serverCommunication = serverCommunication;
        }

        public async Task<Item> RegisterAsync(Item item)
        {
            Console.WriteLine("ItemHandler.RegisterItem");
            Console.WriteLine("just send to server");
            return (Item) await _serverCommunication.SendToServerReturn("put", item);
        }

        public Task<Item> RemoveAsync(Item entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> UpdateAsync(Item entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Item>> GetAllAsync()
        {
            //FIXME: Do I like correct and beautiful? - No idea --> arg?
            JsonElement jsonObject = (JsonElement) await _serverCommunication.SendToServerReturn( "getall", new Item());
			
            return JsonSerializer.Deserialize<List<Item>>(jsonObject.ToString(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }

        public async Task<Item> GetAsync(Item entity)
        {
            //TODO: MAKE ME PLEASE
			
            Console.WriteLine($"Template Item Type {entity.GetType().Name}");
			
            JsonElement itemJson =  (JsonElement) await _serverCommunication.SendToServerReturn("get", entity);
			
            Item item = JsonSerializer.Deserialize<Item>( itemJson.ToString(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
			
            Console.WriteLine($"> item handler resived {item.Id} {item.GetType()} ");

            return item;
        }
        
    }
}