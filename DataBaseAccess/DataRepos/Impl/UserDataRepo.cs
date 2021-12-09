using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public class UserDataRepo : IUserDataRepo
    {
        private List<User> users;

        private WarehouseDbContext _warehouseDbContext;

        public UserDataRepo(WarehouseDbContext dbContext)
        {
            _warehouseDbContext = dbContext;
            
            users = _warehouseDbContext.Users.ToList();
        }
        
        public async Task<User> ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            
            return first;
        }
    }
}