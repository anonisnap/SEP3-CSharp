
using System;
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
			gOrder gOrder = GrpcConverter.FromEntity.ToGOrder(order);

			// Connect to Service
			Connect( );

			// Send call to Service
			var reply = await _client.RegisterOrderAsync(gOrder);
			Console.WriteLine(reply);
			
			// Disconnect from Service
			await Disconnect( );

			// Return Order to User
			return GrpcConverter.FromGEntity.ToOrder(reply);
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
			gOrder g = GrpcConverter.FromEntity.ToGOrder(o);

			// Create Connection Point
			Connect( );
			
			// Send Call Request to Server and store reply
			var reply = await _client.UpdateOrderAsync(g);

			// Disconnect from Server
			await Disconnect( );

			// Convert returned gRPC Order to Order
			Order Order = GrpcConverter.FromGEntity.ToOrder(reply);

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
				Orders.Add(GrpcConverter.FromGEntity.ToOrder(g));
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
			Order Order = GrpcConverter.FromGEntity.ToOrder(reply);

			// Return Order to User
			return Order;
		}

		public async Task<bool> ProcessOrder(Order order, List<Inventory> pickInventories)
		{
			gOrderProcess gOrderProcess = GrpcConverter.FromEntity.ToGOrderProcess(order, pickInventories);
			
			//connection point
			Connect( );
			var replay = await _client.ProcessOrderAsync(gOrderProcess);
			
			// Disconnect from Server
			await Disconnect( );
			return replay.Value;
		}

		private void Connect( ) {
			_channel = GrpcChannel.ForAddress(_address);
			_client = new OrderService.OrderServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}
		
	}
}