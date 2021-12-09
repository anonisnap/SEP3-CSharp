using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos
{
    public interface IUserDataRepo
    {
        Task<User> ValidateUser(string userName, string Password);

    }
}