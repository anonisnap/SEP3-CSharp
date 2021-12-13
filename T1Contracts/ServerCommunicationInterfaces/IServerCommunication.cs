using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.GlobalContracts;
using ServerCommunication;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IServerCommunication<TEntity>: IEntityManager<TEntity>
    {
      
    }
}