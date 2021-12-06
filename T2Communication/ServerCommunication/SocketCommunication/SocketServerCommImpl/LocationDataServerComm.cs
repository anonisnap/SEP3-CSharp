using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using T1Contracts.ServerCommunicationInterfaces;

namespace ServerCommunication
{
    public class LocationDataServerComm: ILocationDataServerComm
    {
        private IServerCommunication _serverCommunication;

        
        public LocationDataServerComm(IServerCommunication serverCommunication)
        {
            _serverCommunication = serverCommunication;
        }

        public async Task<Location> RegisterAsync(Location location)
        {
            return (Location) await _serverCommunication.SendToServerReturn("put", location);
        }

        public Task<Location> RemoveAsync(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Location> UpdateAsync(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Location>> GetAllAsync()
        {
            JsonElement jsonObject =
                (JsonElement) await _serverCommunication.SendToServerReturn("getall", new Location());

            return JsonSerializer.Deserialize<List<Location>>(jsonObject.ToString(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public Task<Location> GetAsync(Location location)
        {
            throw new System.NotImplementedException();
        }
    }
}