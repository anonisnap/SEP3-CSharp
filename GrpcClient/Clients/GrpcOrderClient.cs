
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients
{
    public class GrpcOrderClient : IOrderDataServerComm
    {
        private string _address;
        private GrpcChannel _channel;
        private OrderService _client;
        
        
        public Task<Order> RegisterAsync(Order entity)
        {
            
            throw new System.NotImplementedException();
        }

        public Task<Order> RemoveAsync(int entity)
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

        public Task<Order> GetAsync(int entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Order>> GetAllByOrderIdAsync(Order order)
        {
            throw new System.NotImplementedException();
        }
        
        
        
        
        
        
        
    }
}