using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Server;

namespace Client
{
    class MyCxMsg : MarshalByRefObject, ICxMsg
    {
        public void AcceptMsg(string id, string msg)
        {
            Console.WriteLine("\n\n\n #####################");
            Console.WriteLine("Remetente => " + id);
            Console.WriteLine("Mensagem => " + msg);
            Console.WriteLine("##################### \n\n\n ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCxMsg msb = new MyCxMsg();

            IServer server = (IServer)Activator.GetObject(typeof(IServer), "http://localhost:8888");
            server.Register("Skyish", msb);
            server.SendMsg("Skyish", "Hello World");
        }
    }
}
