using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients
{
    public class GrpcOrderClient : IOrderDataServerComm
    {
        public Task<Order> RegisterAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> RemoveAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Order>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetAsync(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}