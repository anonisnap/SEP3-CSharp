using System;
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

        public void Update(string jsonEntity)
        {
            throw new NotImplementedException();
        }
    }
}