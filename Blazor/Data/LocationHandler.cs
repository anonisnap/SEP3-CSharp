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
			//Request putRequest = new(RequestType.PUT, nameof(Location), location);
			//await _serverCommunication.SendToServer(putRequest);
			throw new System.NotImplementedException( );
		}
	}
}