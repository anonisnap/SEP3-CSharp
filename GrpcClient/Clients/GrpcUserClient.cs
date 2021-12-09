using Entities.Models;
using Grpc.Net.Client;
using myGrpc;
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

		public async Task<User> LoginAsync(User user) {
			Connect( );
			UserDetails details = await _client.loginAsync(GetUserDetails(user) );
			await Disconnect( );
			return GetUser(details);
		}

		public async Task Logout(User user) {
			Connect( );
			_ = await _client.logoutAsync(GetUserDetails(user));
			await Disconnect( );
		}

		private UserDetails GetUserDetails(User user) {
			return new( ) { Username = user.Username, Password = user.Password, Role = user.Role, SecurityLevel = user.SecurityLevel };
		}
		private User GetUser(UserDetails details) {
			return new( ) { Username = details.Username, Password = details.Password, Role = details.Role, SecurityLevel = details.SecurityLevel };
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
