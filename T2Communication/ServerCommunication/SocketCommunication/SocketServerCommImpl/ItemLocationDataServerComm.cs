using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace ServerCommunication
{
    public class ItemLocationDataServerComm: IItemLocationDataServerComm
    {
        
        private IServerCommunication _serverCommunication;

        public ItemLocationDataServerComm(IServerCommunication serverCommunication)
        {
            _serverCommunication = serverCommunication;
        }
        
        public async Task<ItemLocation> RegisterAsync(ItemLocation itemLocation)
        {
            Console.WriteLine("ItemLocationHandler.AddItemLocation");
            
            Console.WriteLine("just send to server please");
            
            JsonElement jsonElement = (JsonElement) await _serverCommunication.SendToServerReturn("put", itemLocation);

            return JsonSerializer.Deserialize<ItemLocation>(jsonElement.ToString(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public Task<ItemLocation> RemoveAsync(ItemLocation itemLocation)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemLocation> UpdateAsync(ItemLocation itemLocation)
        {
            Console.WriteLine("ItemLocationHandler.UpdateItemLocation");
            Console.WriteLine("just send to server please");
            JsonElement jsonElement =  (JsonElement) await _serverCommunication.SendToServerReturn("post", itemLocation);
            
            return JsonSerializer.Deserialize<ItemLocation>(jsonElement.ToString(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task<IList<ItemLocation>> GetAllAsync()
        {
            JsonElement jsonElement =  (JsonElement) await _serverCommunication.SendToServerReturn( "getall", new ItemLocation());
			
            return JsonSerializer.Deserialize<List<ItemLocation>>(jsonElement.ToString(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }

        public Task<ItemLocation> GetAsync(ItemLocation itemLocation)
        {
            throw new NotImplementedException();
        }
    }
}