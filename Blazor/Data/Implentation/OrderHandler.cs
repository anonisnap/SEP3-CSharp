using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace Blazor.Data
{
    public class OrderHandler : IOrderHandler
    {
        private IOrderDataServerComm _orderDataServerComm;

        public OrderHandler(IOrderDataServerComm orderDataServerComm)
        {
            _orderDataServerComm = orderDataServerComm;
        }

        public async Task<Order> RegisterAsync(Order order)
        {
            return await _orderDataServerComm.RegisterAsync(order);
        }

        public Task<Order> RemoveAsync(int order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _orderDataServerComm.GetAllAsync();
        }

        public Task<Order> GetAsync(int order)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Order>> GetAllByOrderIdAsync(Order order)
        {
            return await _orderDataServerComm.GetAllByOrderIdAsync(order);
        }
        
    }
}