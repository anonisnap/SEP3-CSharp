
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcOrderClient : IOrderDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private OrderService.OrderServiceClient _client;

		public GrpcOrderClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}

		public async Task<Order> RegisterAsync(Order order) {
			// Convert Order to gOrder
			gOrder gOrder = ConvertOrderToGOrder(order);

			// Connect to Service
			Connect( );

			// Send call to Service
			var reply = await _client.RegisterOrderAsync(gOrder);

			// Disconnect from Service
			await Disconnect( );

			// Return Order to User
			return ConvertGOrderToOrder(reply);
		}

		public async Task<bool> RemoveAsync(int id) {
			gOrderId g = new gOrderId { OrderId= id };

			Connect( );

			var reply = await _client.RemoveOrderAsync(g);

			await Disconnect( );

			bool Order = reply.Value;

			return Order;
		}

		public async Task<Order> UpdateAsync(Order o) {
			// Convert Order to gRPC Order
			gOrder g = ConvertOrderToGOrder(o);

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.UpdateOrderAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Order to Order
			Order Order = ConvertGOrderToOrder(reply);

			// Return Order to User
			return Order;
		}

		public async Task<IList<Order>> GetAllAsync( ) {
			// Convert Order to gRPC Order | Here, it is specifically used as an Object Template for later
			gOrder template = new( ) { };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			gOrderList reply = await _client.GetAllOrdersAsync(template);

			// Disconnect from Server
			await Disconnect( );

			// Generate Lists to read from, and fill in
			ICollection<gOrder> gOrders = reply.Orders;
			List<Order> Orders = new( ) { };

			// Loop Through Collection of gOrders
			foreach (var g in gOrders) {
				// Convert each gOrder and add to list of Orders
				Orders.Add(ConvertGOrderToOrder(g));
			}

			// Return Order to User
			return Orders;
		}

		public async Task<Order> GetAsync(int id) {
			// Convert Order to gRPC Order
			gOrderId g = new gOrderId { OrderId = id };

			// Create Connection Point
			Connect( );

			// Send Call Request to Server and store reply
			var reply = await _client.GetOrderAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Order to Order
			Order Order = ConvertGOrderToOrder(reply);

			// Return Order to User
			return Order;
		}

		private void Connect( ) {
			_channel = GrpcChannel.ForAddress(_address);
			_client = new OrderService.OrderServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}

		// Order -> gOrder
		private gOrder ConvertOrderToGOrder(Order o) {
			// Create gOrderEntry list
			List<gOrderEntry> gE = new( );

			// Loop through Order (parameter) Entries and create a gOrderEntry object, to add to gOrderEntry list
			o.OrderEntries.ForEach(entry => gE.Add(ConvertOrderEntryToGOrderEntry(entry)));

			// Create gOrder Object
			gOrder gO = new gOrder { Id = o.Id, OrderNumber = o.OrderNumber, Location = new gLocation { Id = o.Location.Id, Description = o.Location.Description } };

			// Add gOrderEntries to gOrder
			gO.OrderEntries.AddRange(gE);

			return gO;
		}

		private gOrderEntry ConvertOrderEntryToGOrderEntry(OrderEntry e) {
			return new gOrderEntry {
				Id = e.Id,
				OrderId = e.OrderId,
				Item = new gItem {
					Id = e.Item.Id,
					ItemName = e.Item.ItemName,
					Height = e.Item.Height,
					Length = e.Item.Length,
					Width = e.Item.Width,
					Weight = e.Item.Weight
				},
				Amount = e.Amount
			};

		}
		// ~~~~~~~~~~~~~~~~~~~~

		// gOrder -> Order
		private Order ConvertGOrderToOrder(gOrder gO) {
			List<OrderEntry> oE = new( );
			foreach (gOrderEntry e in gO.OrderEntries) {
				oE.Add(ConvertGOrderEntryToOrderEntry(e));
			}
			Order o = new Order { Id = gO.Id, OrderNumber = gO.OrderNumber, Location = new Location { Id = gO.Location.Id, Description = gO.Location.Description } };
			o.OrderEntries.AddRange(oE);
			return o;
		}

		private OrderEntry ConvertGOrderEntryToOrderEntry(gOrderEntry gE) {
			return new OrderEntry {
				Id = gE.Id,
				OrderId = gE.OrderId,
				Item = new Item {
					Id = gE.Item.Id,
					ItemName = gE.Item.ItemName,
					Height = gE.Item.Height,
					Length = gE.Item.Length,
					Width = gE.Item.Width,
					Weight = gE.Item.Weight
				},
				Amount = gE.Amount
			};
		}
		// ~~~~~~~~~~~~~~~~~~~~
	}
}