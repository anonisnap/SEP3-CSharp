using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace Blazor.Data
{
    public class UserService : IUserService
    {
        private IUserDataServerComm _userDataServerComm;

        public UserService(IUserDataServerComm userDataServerComm)
        {
            _userDataServerComm = userDataServerComm;
        }
        
        public Task<User> ValidateUser(User user)
        {
            return _userDataServerComm.LoginAsync(user);
        }
    }
}