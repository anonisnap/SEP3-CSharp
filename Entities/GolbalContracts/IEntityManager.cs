using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerCommunication
{
    public interface IEntityManager<TEntity>
    {
        Task<TEntity> RegisterAsync(TEntity entity);
        
        Task<bool> RemoveAsync(int entityId);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int entityId);
    }
}