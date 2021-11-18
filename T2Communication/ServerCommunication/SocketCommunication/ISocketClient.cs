namespace ServerCommunication.SocketCommunication
{
    public interface ISocketClient : IServerCommunication
    {
        void CreateClientHandler();
        
        
    }
}