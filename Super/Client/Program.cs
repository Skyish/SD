using Client.stockManager;
using SharedServerInfo;
using System;
using System.Runtime.Remoting;

namespace Client
{
    class MyStockManager : MarshalByRefObject, IStockManager
    {
        private IItem i;

        public void SetItem(IItem i)
        {
            this.i = i;
        }

        public IItem GetProducts()
        {
            return i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StockReader sr = new StockReader();
            IItem i = sr.DeserializeObject("C:/Users/cristianorosario/Documents/SD/Super/Client/stockManager/items/textItem.xml");

            Console.WriteLine(i.Name);
            Console.WriteLine(i.Price);
            Console.WriteLine(i.Quantity);

            MyStockManager sm = new MyStockManager();
            sm.SetItem(i);

            RemotingConfiguration.Configure("Client.exe.config", false);

            //ICxMsg msb = new MyCxMsgClient();

            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            Console.WriteLine(entries[0].TypeName + " " + entries[0].ObjectType + " " + entries[0].ObjectUrl);
            IServer server = (IServer)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);
            server.Register(sm);

            Console.ReadLine();
            //server.Register("Skyish", msb);
            //server.SendMsg("Skyish", "Hello World");
        }
    }
}
