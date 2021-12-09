using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Data
{
    public class UserService : IUserService
    {
        public Task<User> ValidateUser(string userName, string Password)
        {
            throw new System.NotImplementedException();
        }
    }
}