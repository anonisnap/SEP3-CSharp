using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(User user);
    }
}