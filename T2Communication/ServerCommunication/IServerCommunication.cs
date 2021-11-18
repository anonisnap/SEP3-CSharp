using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_WebServerClient.Models;


namespace ServerCommunication
{
    public interface IServerCommunication
    {
        Task SendToServer(Spike spike);

        Task<IList<Spike>> GetFromServer();
    }
}