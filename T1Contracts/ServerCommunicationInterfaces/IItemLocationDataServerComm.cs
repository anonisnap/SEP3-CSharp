using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IItemLocationDataServerComm: IServerCommunication<ItemLocation>
    {
        
        public Task<IList<ItemLocation>> GetAllByItemIdAsync(ItemLocation itemLocation);
        public Task<IList<ItemLocation>> GetAllByLocationIdAsync(ItemLocation itemLocation);
        
        
        
    }
}