using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Entities.Models;
using SEP3_WebServerClient.Models;

namespace ServerCommunication.SocketCommunication
{
    public class SocketClient : ISocketClient
    {
        private SocketClientHandler socketClientHandler;

        public SocketClient()
        {
            CreateClientHandler();
        }

        public void CreateClientHandler()
        {
            
            //TODO: TcpClient --> nye ports for nye clineter
            TcpClient tcpClient = new TcpClient("localhost", 1235);
            socketClientHandler = new SocketClientHandler(tcpClient);
            // observing with "HandelReceivedObject" on action "ReceivedFromServer" 
            socketClientHandler.ReceivedFromServer += HandelReceivedObject;
            Thread t = new Thread(() => socketClientHandler.Run());
            t.Start();
            
        }
        
        public async Task SendToServer(Request request)
        {
            Console.WriteLine($"I am trying to sendToServer via {socketClientHandler}");
            await socketClientHandler.SendObject(request);
        }

        public Task<IList<Spike>> GetFromServer(Request request)
        {
            throw new NotImplementedException();
        }


        private void HandelReceivedObject(Object obj)
        {
            Console.WriteLine("shit got out of hand");
        }
        
        
        
    }
    
}