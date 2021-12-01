using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerCommunication.SocketCommunication {
	public class SocketClientHandler {
		private NetworkStream _stream;
		private TcpClient _tcpClient;

		public Action<string> ReceivedFromServer { get; set; }

		public SocketClientHandler(TcpClient tcpClient) {
			_tcpClient = tcpClient;
			_stream = tcpClient.GetStream( );
		}


		public void Run( ) {
			try {
				// Loop until Connection has been lost
				while (true) {
					Console.WriteLine("> A socket has been set up for listening");
					string receiveObject = ReceiveObject( ).Result;
					Console.WriteLine("> Running thread SocketClientHandler received an object");
					ReceivedFromServer?.Invoke(receiveObject);
				}
			} catch (Exception) {
				_stream.Dispose( );
				_tcpClient.Close( );
			}
		}


		public async Task SendObject(object obj) {
			Console.WriteLine("SocketClientHandler.SendObject is called");
			//objectAsJSON?
			string objAsJson = JsonSerializer.Serialize(obj,
				new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
			byte[ ] bytes = Encoding.ASCII.GetBytes(objAsJson);

			_stream.Write(bytes, 0, bytes.Length);
		}

		public async Task<string> ReceiveObject( ) {
			byte[ ] fromServer = new byte[1024];
			int bytesRead = _stream.Read(fromServer, 0, fromServer.Length);
			string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
			return response;
		}

		public void Kill( ) {
			_stream.Close( );
		}
	}
}