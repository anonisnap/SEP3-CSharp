using System;

namespace ServerCommunication
{
    public class Request
    {
        public int Id { get; set; }
        public string Type { get; private set; }
        public string ClassName { get; set; }
        public Object Arg { get; set; }
        
        
        public Request(RequestType type, int id, string className, object arg)
        {
            Id = id;
            Type = type.ToString();
            ClassName = className;
            Arg = arg;
        }
    }
}