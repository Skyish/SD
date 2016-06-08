using SharedServerInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

namespace ConnectionHandlers
{
    class Program
    {


        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);

            var serverProvider = new BinaryServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full };
            var clientProvider = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = args[0];

            HttpChannel channel = new HttpChannel(props, clientProvider, serverProvider);
            ChannelServices.RegisterChannel(channel, false);

            Console.WriteLine(args.Length);


            IServer server = (IServer)Activator.GetObject(typeof(IServer), "http://localhost:" + args[0] + "/Server.soap");
            IRingConnection rc = (IRingConnection) Activator.GetObject(typeof (IRingConnection), "http://localhost:" + args[0] + "/IRingConnection.soap");
            rc.SetServer(server);

            if (args.Length > 1)
            {
                rc.Connect(args[1]);
            }

            Dictionary<string, Action<string>> commands = new Dictionary<string, Action<string>>();
            commands.Add("connect", (s)=> {
                rc.Connect(s);
            });

            commands.Add("getStock", (s) =>
            {
                Console.WriteLine(rc.GetStock(s));
            });

            commands.Add("getRemoteStock", (s) =>
            {
                Console.WriteLine(rc.GetRemoteStock(s));
            });

            string com;
            while ((com = Console.ReadLine()) != "quit")
            {
                if (!string.IsNullOrWhiteSpace(com))
                {
                    string[] vals = com.Split(' ');

                    if (vals.Length >= 2 && commands.ContainsKey(vals[0]))
                    {
                        commands[vals[0]](vals[1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command");
                    }

                }
            }
            
        }
    }
}
