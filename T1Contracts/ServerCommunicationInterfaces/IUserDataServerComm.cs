using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Contracts.ServerCommunicationInterfaces {
	public interface IUserDataServerComm {
		Task<User> LoginAsync(User user);
		Task Logout(User user);
	}
}
