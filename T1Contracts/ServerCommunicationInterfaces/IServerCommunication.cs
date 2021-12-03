using System.Collections.Generic;
using System.Threading.Tasks;
using ServerCommunication;

namespace T1Contracts.ServerCommunicationInterfaces
{
    public interface IServerCommunication<TEntity>: IEntityManager<TEntity>
    {
      
    }
}