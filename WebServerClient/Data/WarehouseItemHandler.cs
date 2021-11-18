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
        
        public async Task NewWarehouseItem(WarehouseItem warehouseItem)
        {
            //TODO: MAKE ME PLEASE
           // await _serverCommunication.SendWarehouseItemToServer(warehouseItem);
           
        }

        public async Task<IList<WarehouseItem>> GetWarehouseItems()
        {
            //TODO: MAKE ME PLEASE
            throw new System.NotImplementedException();
        }

        public async Task<WarehouseItem> GetWarehouseItem(int itemId)
        {
            //TODO: MAKE ME PLEASE
            throw new System.NotImplementedException();
        }
    }
}