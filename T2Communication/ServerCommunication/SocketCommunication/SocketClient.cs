using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


namespace ServerCommunication.SocketCommunication {
	public class SocketClient : ISocketClient {
		private SocketClientHandler socketClientHandler;
		string _jsonObject;

		public SocketClient( ) {
			Console.WriteLine("Creating a SocketClient");
			CreateClientHandler( );
		}

		public void CreateClientHandler( ) {

			//TODO: TcpClient --> nye ports for nye clienter
			TcpClient tcpClient = new TcpClient("localhost", 1235);
			socketClientHandler = new SocketClientHandler(tcpClient);
			// observing with "HandelReceivedObject" on action "ReceivedFromServer" 
			socketClientHandler.ReceivedFromServer += HandleReceivedObject;
			Thread t = new Thread(( ) => socketClientHandler.Run( ));
			t.Start( );

		}

		public async Task SendToServer(string action, object obj) {
			// Create Request
			Request request = generateRequest(action, obj);
			// Map Handler to Request ID

			// Send Request to Server

			Console.WriteLine($"I am trying to sendToServer via {socketClientHandler}");
			await socketClientHandler.SendObject(request);
		}

		// Deprecated? Should  this be removed?
		//public async Task<string> GetFromServer( ) {
		//	while (_jsonObject == null) {
		//		Console.WriteLine($"Waiting for _jsonObject to not be null\n\t> {_jsonObject}");
		//		Thread.Sleep(500);
		//	}
		//	string tmp = _jsonObject;
		//	_jsonObject = null;
		//	return tmp;

		//	//throw new NotImplementedException( );
		//}


		private void HandleReceivedObject(string obj) {
			// Retrieve Reply

			// Get ID from Reply

			// Find Handler in Map using Id

			// Give (Class Type & [?]) Argument to Handler



			_jsonObject = obj;
			Console.WriteLine($"Recived {obj}");
		}

		private Request generateRequest(string action, object obj) {
			int requestId = new Random( ).Next( );
			RequestType type = Enum.TryParse<RequestType>(action, true, out);
			Request req = new Request(type, requestId, nameof(obj),obj );

			return req;
		}
	}
}