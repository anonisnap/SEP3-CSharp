using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public class ItemHandler : IItemHandler
    {
        //TODO: Jeg mangler i astah ;(
        private IServerCommunication _serverCommunication;
        
        public ItemHandler()
        {
            //TODO: What me doing?
        }
        
        public async Task RegisterItem(Item item)
        {
            //TODO: MAKE ME PLEASE
           //await _serverCommunication.SendObject(item);
           
        }

        public async Task<IList<Item>> GetItems()
        {
            //TODO: MAKE ME PLEASE
            //await _serverCommunication.GetItems();
            throw new System.NotImplementedException();
        }

        public async Task<Item> GetItem(int itemId)
        {
            //TODO: MAKE ME PLEASE
            //await _serverCommunication.GetItem(itemId);
            throw new System.NotImplementedException();
        }
    }
}