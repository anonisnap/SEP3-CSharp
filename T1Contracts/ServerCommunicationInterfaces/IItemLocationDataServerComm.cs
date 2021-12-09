using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IItemLocationDataServerComm: IServerCommunication<ItemLocation>
    {
        
        public Task<IList<ItemLocation>> GetAllByItemIdAsync(int itemId);
        public Task<IList<ItemLocation>> GetAllByLocationIdAsync(int locationId);
        
        
        
    }
}