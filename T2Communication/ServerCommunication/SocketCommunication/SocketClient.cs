using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCommunication.SocketCommunication {
	public class SocketClient : ISocketClient {
		private SocketClientHandler _socketClientHandler;
		private Dictionary<int, IHandler> _handlerDict; // Dictionary<string, object> [?]
		private string _jsonObject;

		public SocketClient( ) {
			Console.WriteLine("Creating a SocketClient");

			_handlerDict = new Dictionary<int, IHandler>( );

			CreateClientHandler( );
		}

		public void CreateClientHandler( ) {

			//TODO: TcpClient --> nye ports for nye clienter
			TcpClient tcpClient = new TcpClient("localhost", 1235);
			_socketClientHandler = new SocketClientHandler(tcpClient);
			// observing with "HandelReceivedObject" on action "ReceivedFromServer" 
			_socketClientHandler.ReceivedFromServer += HandleReceivedObject;
			Thread t = new Thread(( ) => _socketClientHandler.Run( ));
			t.Start( );

		}

		public async Task SendToServer(IHandler callingHandler, string action, object obj) {
			// Create Request
			Console.WriteLine($"> Generating a {action.ToUpper( )}-request with arg: {obj.GetType( ).Name}");
			Request request = generateRequest(action, obj);

			// Map Handler to Request ID
			Console.WriteLine($"> Attempting to add {callingHandler.GetType( ).Name} to Handler Dictionary");
			_handlerDict.Add(request.Id, callingHandler);

			// Send Request to Server
			Console.WriteLine($"> Contacting Server using {_socketClientHandler}");
			await _socketClientHandler.SendObject(request);
		}

		private void HandleReceivedObject(string obj) {
			// Retrieve Reply
			RequestReply serverReply = JsonSerializer.Deserialize<RequestReply>(obj);

			// Get ID from Reply
			int id = serverReply.Id;

			// Find Handler in Map using Id
			_handlerDict.TryGetValue(id, out IHandler handler);

			// Give (Class Type & [?]) Argument to Handler
			Console.WriteLine($"Updating {handler.GetType( ).Name} with {(string) serverReply.Arg}");
			handler.Update((string) serverReply.Arg);

			_jsonObject = obj;
			Console.WriteLine($"\t<!!> Recived {obj}");
		}

		private Request generateRequest(string action, object obj) {
			int requestId = new Random( ).Next( );
			RequestType type;
			Enum.TryParse<RequestType>(action, true, out type);
			Request req = new Request(type, requestId, obj.GetType( ).Name, obj);

			return req;
		}
	}
}