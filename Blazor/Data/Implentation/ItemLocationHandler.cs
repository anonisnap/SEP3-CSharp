using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public class ItemLocationHandler : IItemLocationHandler
    {
        private IServerCommunication _serverCommunication;

        public ItemLocationHandler(IServerCommunication serverCommunication)
        {
            _serverCommunication = serverCommunication;
        }
        
        public async Task AddItemLocation(ItemLocation itemLocation)
        {
            Console.WriteLine("ItemLocationHandler.AddItemLocation");

            await _serverCommunication.SendToServerReturn(this, "put", itemLocation);
            
            Console.WriteLine("just send to server please");
        }

        public async Task<IList<ItemLocation>> GetItemLocations()
        {
            JsonElement jsonObject = (JsonElement) await _serverCommunication.SendToServerReturn(this, "getall", new ItemLocation());
			
            return JsonSerializer.Deserialize<List<ItemLocation>>(jsonObject.ToString(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }


        public void Update(string jsonEntity)
        {
            throw new NotImplementedException();
        }
    }
}