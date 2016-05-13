using Client.stockManager;
using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            string[] itemsPath = new string[] {
                "C:/Users/cristianorosario/Documents/SD/Super/Client/stockManager/items/Leite.xml",
                "C:/Users/cristianorosario/Documents/SD/Super/Client/stockManager/items/Cereais.xml",
                "C:/Users/cristianorosario/Documents/SD/Super/Client/stockManager/items/Carne.xml"
            };

            Dictionary<string, IItem> items = StockReader.DeserializeItems(itemsPath);

            RemotingConfiguration.Configure("Client.exe.config", false);

            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            Console.WriteLine(entries[0].TypeName + " " + entries[0].ObjectType + " " + entries[0].ObjectUrl);
            IServer server = (IServer)Activator.GetObject(entries[0].ObjectType, entries[0].ObjectUrl);

            Client c = new Client(server, items);

            server.PrintStockManager();

            Console.ReadLine();

            server.PrintStockManager();
        }

        private IServer server;
        private IStockManager manager;

        public Client(IServer server, Dictionary<string, IItem> items)
        {
            this.server = server;
            this.manager = new StockManager(items);
            server.Register(manager);
        }

        ~Client()
        {
            server.Unregister(manager);
        }
    }
}
