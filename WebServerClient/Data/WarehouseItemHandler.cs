using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace SEP3_WebServerClient.Data
{
    public class WarehouseItemHandler : IWarehouseItemHandler
    {
        //TODO: Jeg mangler i astah ;(
        private IServerCommunication _serverCommunication;
        
        public WarehouseItemHandler()
        {
            //TODO: What me doing?
        }
        
        public async Task NewWarehouseItem(Item item)
        {
            //TODO: MAKE ME PLEASE
           // await _serverCommunication.SendWarehouseItemToServer(warehouseItem);
           
        }

        public async Task<IList<Item>> GetWarehouseItems()
        {
            //TODO: MAKE ME PLEASE
            throw new System.NotImplementedException();
        }

        public async Task<Item> GetWarehouseItem(int itemId)
        {
            //TODO: MAKE ME PLEASE
            throw new System.NotImplementedException();
        }
    }
}