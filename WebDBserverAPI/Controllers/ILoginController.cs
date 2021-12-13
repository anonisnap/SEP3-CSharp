using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface ILoginController
    {
        Task<ActionResult<User>> Login(User userInfo);
    }
}