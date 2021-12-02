using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
	public interface IDataRepo<Entity>
	{
		Task<Entity> AddAsync(Entity obj);

		Task<Entity> RemoveAsync(int id);

		Task<Entity> UpdateAsync(Entity obj);

		Task<IList<Entity>> GetAllAsync();

		Task<Entity> GetAsync(int id);

	}
}