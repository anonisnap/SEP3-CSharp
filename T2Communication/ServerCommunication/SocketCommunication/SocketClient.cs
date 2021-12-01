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
			//_socketClientHandler.ReceivedFromServer += HandleReceivedObject;
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

		public async Task<object> SendToServerReturn(IHandler callingHandler, string action, object obj) {

			Console.WriteLine("> Creating new socket to send request and receive reply");
			TcpClient tcpClient = new TcpClient("localhost", 1235);
			SocketClientHandler requestReplySocketClientHandler = new SocketClientHandler(tcpClient);

			// Create Request
			Console.WriteLine($"> Generating a {action.ToUpper( )}-request with arg: {obj.GetType( ).Name}");
			Request request = generateRequest(action, obj);

			// Map Handler to Request ID
			Console.WriteLine($"> Attempting to add {callingHandler.GetType( ).Name} to Handler Dictionary");
			_handlerDict.Add(request.Id, callingHandler);

			// Send Request to Server
			Console.WriteLine($"> Contacting Server using {requestReplySocketClientHandler}");
			await requestReplySocketClientHandler.SendObject(request);

			// Wait for Server Reply
			RequestReply serverReply = await WaitForReplyAsync(requestReplySocketClientHandler );

			// Cut connection
			requestReplySocketClientHandler.Kill();

			return serverReply?.Arg;
		}
		
		private async Task<RequestReply> WaitForReplyAsync(SocketClientHandler serverSocket ) {

			Console.WriteLine("> Reply Socket Handler is waiting for Server Reply");
			string jsonObj = await serverSocket.ReceiveObject( );

			RequestReply reply = JsonSerializer.Deserialize<RequestReply>(jsonObj,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return reply;
		}

		private void HandleReceivedObject(string broadcast) {
			// Retrieve Reply
			RequestReply serverReply = JsonSerializer.Deserialize<RequestReply>(broadcast);

			// Get ID from Reply
			int id = serverReply.Id;

			// Find Handler in Map using Id
			_handlerDict.TryGetValue(id, out IHandler handler);

			// Give (Class Type & [?]) Argument to Handler
			Console.WriteLine($"Updating {handler.GetType( ).Name} with {(string) serverReply.Arg}");
			handler.Update((string) serverReply.Arg);

			Console.WriteLine($"\t<!!> Recived {broadcast}");
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