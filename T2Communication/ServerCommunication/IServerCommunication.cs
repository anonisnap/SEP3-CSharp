using System.Threading.Tasks;


namespace ServerCommunication {
	public interface IServerCommunication {
		//TODO: How do we split this well, so it doesn't get bloated?
		//WarehouseItems, Locations, and so on.

		Task SendToServer(IHandler callingHandler, string action, object obj);
		Task<object> SendToServerReturn(IHandler callingHandler, string action, object obj);
		
		//Task<string> GetFromServer( );
	}
}