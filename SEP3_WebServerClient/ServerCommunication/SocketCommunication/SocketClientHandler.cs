
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SEP3_WebServerClient.Models;

namespace ServerCommunication.SocketCommunication
{
    public class SocketClientHandler
    {
        private NetworkStream _stream;
        private TcpClient _tcpClient;
        public SocketClientHandler(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _stream = tcpClient.GetStream();
        }

        public void Run()
        {
            //SpikeTest
            //TODO: Send og Receive shall be loooped,
            //so they continue at the same time until closed - SBT
            Spike spike = new Spike {SpikeName = "SnorSnor"};
            SendObject(spike);
            ReceiveObject(spike);
            
            _stream.Close();
            _tcpClient.Close();
        }
        public void SendObject(Object obj)
        {

            //objectAsJSON? 
            string spikeAsJSON = JsonSerializer.Serialize(obj);
            byte[] bytes = Encoding.ASCII.GetBytes(spikeAsJSON);
            
            _stream.Write(bytes, 0 ,bytes.Length);
            
            Console.Read();
        }

        public void ReceiveObject(Object obj)
        {
            byte[] fromServer = new byte[1024];
            int bytesRead = _stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
        }
    }
}