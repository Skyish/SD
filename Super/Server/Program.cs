using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using SharedServerInfo;


namespace SharedServerInfo
{

    class Server : MarshalByRefObject, IServer
    {

        Dictionary<string, ICxMsg> mailBoxes = new Dictionary<string, ICxMsg>();

    
        public void Register(string id, ICxMsg mb)
        {
            Console.WriteLine("Register => " + id);
            mailBoxes.Add(id, mb);
        }

        public void Unregister(string id, ICxMsg mb)
        {
            mailBoxes.Remove(id);
        }

        public void SendMsg(string id, string msg)
        {
            foreach(string key in mailBoxes.Keys)
            {
                mailBoxes[key].AcceptMsg(id, msg);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Criar o Canal Http
            HttpChannel ch = new HttpChannel(8888);
            // Registar o canal
            ChannelServices.RegisterChannel(ch, false);
            // Registar o type RemoteAlunoFactory como Server Activated Object (SAO)
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Server),
            "Server.soap",
            WellKnownObjectMode.Singleton);
            // Espera pedidos
            Console.WriteLine("Server: Espera pedidos...Prima Enter para terminar\n");
            Console.ReadLine();
        }
    }
}
