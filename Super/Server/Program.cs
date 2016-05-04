using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;


namespace Server
{

    class Server : MarshalByRefObject, IServer
    {

        Dictionary<string, ICxMsg> mailBoxes = new Dictionary<string, ICxMsg>();

    
        public void Register(string id, ICxMsg mb)
        {
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
            
        }
    }
}
