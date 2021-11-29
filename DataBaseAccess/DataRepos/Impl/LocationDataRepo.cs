using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public class LocationDataRepo: IDataRepo<Location>
    {
        
        public Task<Location> Add(Location obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Location> Remove(Location obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Location> Update(Location obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Location>> GetAll(Location obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Location> Get(Location obj)
        {
            throw new System.NotImplementedException();
        }
        
    }
}