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

		public async Task SendToServer(Request request) {
			Console.WriteLine($"I am trying to sendToServer via {socketClientHandler}");
			await socketClientHandler.SendObject(request);
		}

		public async Task<string> GetFromServer( ) {
			while (_jsonObject == null) {
				Console.WriteLine($"Waiting for _jsonObject to not be null\n\t> {_jsonObject}");
				Thread.Sleep(500);
			}
			string tmp = _jsonObject;
			_jsonObject = null;
			return tmp;

			//throw new NotImplementedException( );
		}


		private void HandleReceivedObject(string obj) {
			_jsonObject = obj;
			Console.WriteLine($"Recived {obj}");
		}
	}
}