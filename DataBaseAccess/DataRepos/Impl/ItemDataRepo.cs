using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public class ItemDataRepo: IDataRepo<Item>
    {
        
        public Task<Item> Add(Item obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> Remove(Item obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> Update(Item obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Item>> GetAll(Item obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> Get(Item obj)
        {
            throw new System.NotImplementedException();
        }
        
    }
}