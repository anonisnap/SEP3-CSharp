using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IInventoryDataServerComm: IServerCommunication<Inventory>
    {
        
        public Task<IList<Inventory>> GetAllByItemIdAsync(int itemId);
        public Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId);

        public Task<IList<Inventory>> GetInventoryStockAsync();

    }
}