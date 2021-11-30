using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
	public interface IDataRepo<T>
	{
		Task AddAsync(T obj);

		Task<T> RemoveAsync(object id);

		Task UpdateAsync(object id, T obj);

		Task<IList<T>> GetAllAsync();

		Task<T> GetAsync(object obj);

	}
}