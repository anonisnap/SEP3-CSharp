using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace T1Contracts.ServerCommunicationInterfaces {
	public interface IOrderDataServerComm : IServerCommunication<Order> {
		Task<bool> ProcessOrder(Order order, List<Inventory> pickInventories);
	}
}