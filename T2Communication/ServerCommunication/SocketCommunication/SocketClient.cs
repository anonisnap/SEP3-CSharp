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
        public SocketClientHandler SocketClientHandler;

        public void CreateClientHandler()
        {
            while (true)
            {
                //TODO: TcpClient --> nye ports for nye clineter
                TcpClient tcpClient = new TcpClient("localhost", 1235);
                SocketClientHandler socketClientHandler = new SocketClientHandler(tcpClient);
                Thread t = new Thread(() => socketClientHandler.Run());
                t.Start();
            }
        }

        public Task RegisterItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task SendSpikeToServer(Spike spike)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Spike>> GetFromServer()
        {
            throw new NotImplementedException();
        }
    }
}