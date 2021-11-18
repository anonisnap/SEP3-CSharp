using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_WebServerClient.Models;


namespace ServerCommunication
{
    public interface IServerCommunication
    {
        //TODO: How do we split this well, so it doesn't get bloated?
        //WarehouseItems, Locations, and so on.
        Task SendSpikeToServer(Spike spike);

        Task<IList<Spike>> GetFromServer();
    }
}