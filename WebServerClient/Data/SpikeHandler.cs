using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_WebServerClient.Models;
using ServerCommunication;

namespace SEP3_WebServerClient.Data
{
    public class SpikeHandler : ISpikeHandler
    {
        private IServerCommunication _serverCommunication;

        public SpikeHandler()
        {
            //TODO: what i do then?
            //den kan jo ikke oprette en instans af IserverCommunication da det er et interface
            //ServerCommunication = new();
        }
        
        public async Task NewSpike(Spike newSpike)
        {
            await _serverCommunication.SendSpikeToServer(newSpike);
        }

        public async Task<IList<Spike>> GetSpikes()
        {
            return await _serverCommunication.GetFromServer();
        }
    }
}