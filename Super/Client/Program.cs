using SharedServerInfo;
using System;
using System.Runtime.Remoting;

namespace Client
{
    class MyStockManager : MarshalByRefObject, IStockManager
    {
        public string GetProducts()
        {
            return "I got cocain and weed for sale!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.exe.config", false);

            //ICxMsg msb = new MyCxMsgClient();

            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            Console.WriteLine(entries[0].TypeName + " " + entries[0].ObjectType + " " + entries[0].ObjectUrl);
            IServer server = (IServer)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);
            server.Register(new MyStockManager());
            Console.ReadLine();
            //server.Register("Skyish", msb);
            //server.SendMsg("Skyish", "Hello World");
        }
    }
}
