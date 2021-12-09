using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1Contracts.ServerCommunicationInterfaces;

namespace GrpcClient.Clients {
	public class GrpcUserClient : IUserDataServerComm {
		private string _address;
		private GrpcChannel _channel;
		private UserService.UserServiceClient _client;

		public GrpcUserClient(GRPCConnStr address) {
			_address = address.GrpcAddress;
		}
		
		public Task<User> LoginAsync(User user) {
			throw new NotImplementedException( );
		}

		public Task Logout(User user) {
			throw new NotImplementedException( );
		}

		private void Connect( ) {
			_channel = GrpcChannel.ForAddress(_address);
			_client = new UserService.UserServiceClient(_channel);
		}

		private async Task Disconnect( ) {
			await _channel.ShutdownAsync( );
			_client = null;
		}
	}
}
