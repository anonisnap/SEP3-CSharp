using Entities.Models;
using System.Threading.Tasks;

namespace T1Contracts.ServerCommunicationInterfaces {
	public interface IUserDataServerComm {
		Task<User> LoginAsync(User user);
		//Future Implementation
		//Task Logout(User user);
	}
}
