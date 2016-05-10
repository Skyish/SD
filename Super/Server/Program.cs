using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;


namespace Server
{
    class Server : MarshalByRefObject, IServer
    {

        //Dictionary<string, ICxMsg> mailBoxes = new Dictionary<string, ICxMsg>();

        public void Register(IStockManager sm)
        {

            Console.WriteLine(sm.GetProducts().Name);
            Console.WriteLine(sm.GetProducts().Price);
            Console.WriteLine(sm.GetProducts().Quantity);
            Console.WriteLine("Hello world seems I'm getting a stock manager!");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            
            // Espera pedidos
            Console.WriteLine("Server: Espera pedidos...Prima Enter para terminar\n");
            Console.ReadLine();
        }
    }
}
