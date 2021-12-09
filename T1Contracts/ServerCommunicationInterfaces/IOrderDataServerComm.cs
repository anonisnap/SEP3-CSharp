using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IOrderDataServerComm : IServerCommunication<Order>
    {
        public Task<IList<Order>> GetAllByOrderIdAsync(Order order);
    }
}