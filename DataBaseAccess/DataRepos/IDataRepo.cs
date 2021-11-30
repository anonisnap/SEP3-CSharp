using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
	public interface IDataRepo<Entity, Key>
	{
		Task AddAsync(Entity obj);

		Task<Entity> RemoveAsync(Key id);

		Task UpdateAsync(Key id, Entity obj);

		Task<IList<Entity>> GetAllAsync();

		Task<Entity> GetAsync(Key obj);

	}
}