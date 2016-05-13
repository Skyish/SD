using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;


namespace Server
{
    class Server : MarshalByRefObject, IServer
    {

        public Server()
        {
            Console.WriteLine("Server inited");
        }

        ~Server()
        {
            Console.WriteLine("Server destroyed");
        }

        private List<IStockManager> sm = new List<IStockManager>();

        public List<IStockManager> getStockManagers()
        {
            return sm;
        }

        public void PrintStockManager()
        {
            Console.WriteLine("Trying to print objects");
            foreach (IStockManager manager in sm)
            {
                foreach(string key in manager.GetProducts().Keys)
                Console.WriteLine(key);
            }
            Console.WriteLine("################################################");
        }

        public void Register(IStockManager sm)
        {
            this.sm.Add(sm);
        }

        public void Unregister(IStockManager sm)
        {
            Console.WriteLine("Going to unregister");
            Console.WriteLine(this.sm.Contains(sm));
            this.sm.Remove(sm);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //configurar channel em código!

            RemotingConfiguration.Configure("Server.exe.config", false);
            
            // Espera pedidos
            Console.WriteLine("Server: Espera pedidos...Prima Enter para terminar\n");
            Console.ReadLine();
        }
    }
}
