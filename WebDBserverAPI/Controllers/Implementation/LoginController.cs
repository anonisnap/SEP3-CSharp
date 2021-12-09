using System;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private IUserDataRepo _userDataRepo;


        public LoginController(IUserDataRepo userDataRepo)
        {
            _userDataRepo = userDataRepo;
        }

        [HttpPost]
        public async Task<ActionResult<User>> ValidateUser([FromBody] User userInfo)
        {
            try
            {
                User user = await _userDataRepo.ValidateUser(userInfo.Username,userInfo.Password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}