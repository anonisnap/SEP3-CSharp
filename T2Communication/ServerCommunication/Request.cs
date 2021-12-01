using System;

namespace ServerCommunication
{
    public class Request
    {
        
        public string Type { get; private set; }
        public string ClassName { get; set; }
        public Object Arg { get; set; }
        
        
        public Request(RequestType type, string className, object arg)
        {
            Type = type.ToString();
            ClassName = className;
            Arg = arg;
        }
    }
}