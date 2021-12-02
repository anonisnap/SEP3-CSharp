using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
	public class LocationHandler : ILocationHandler
	{
		private IServerCommunication _serverCommunication;

		public LocationHandler(IServerCommunication serverCommunication)
		{
			_serverCommunication = serverCommunication;
		}
		public async Task CreateLocation(Location location)
		{
			await _serverCommunication.SendToServerReturn(this,"put",location);
		}

		public async Task<IList<Location>> GetLocations()
		{
			JsonElement jsonObject = (JsonElement) await _serverCommunication.SendToServerReturn(this, "getall", new Location());
			
			return JsonSerializer.Deserialize<List<Location>>(jsonObject.ToString(), 
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
			 
		}

		public Task<Location> GetLocation(int locationId)
		{
			throw new System.NotImplementedException();
		}

		public void Update(string jsonEntity)
		{
			throw new System.NotImplementedException();
		}
	}
}