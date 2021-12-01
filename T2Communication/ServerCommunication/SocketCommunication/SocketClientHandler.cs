using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_WebServerClient.Models;

namespace ServerCommunication.SocketCommunication
{
    public class SocketClientHandler
    {
        private NetworkStream _stream;
        private TcpClient _tcpClient;

        public Action<string> ReceivedFromServer { get; set; }

        public SocketClientHandler(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _stream = tcpClient.GetStream();
        }


        public void Run()
        {
            while (true)
            {
                Console.WriteLine("im a socket Thread");
                string receiveObject = ReceiveObject().Result;
                ReceivedFromServer?.Invoke(receiveObject);
            }


            _stream.Close();
            _tcpClient.Close();
        }


        public async Task SendObject(object obj)
        {
            Console.WriteLine("SocketClientHandler.SendObject is called");
            //objectAsJSON? 
            string objAsJson = JsonSerializer.Serialize(obj,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            byte[] bytes = Encoding.ASCII.GetBytes(objAsJson);

            _stream.Write(bytes, 0, bytes.Length);
        }

        public async Task<string> ReceiveObject()
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = _stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            return response;
        }
    }
}