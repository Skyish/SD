using System;
using SharedServerInfo;

namespace Client
{
    [Serializable]
    class MyCxMsgClient : ICxMsg
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
            ICxMsg msb = new MyCxMsgClient();

            IServer server = (IServer)Activator.GetObject(typeof(IServer), "http://localhost:8888/Server.soap");
            server.Register("Skyish", msb);
            server.SendMsg("Skyish", "Hello World");
        }
    }
}
