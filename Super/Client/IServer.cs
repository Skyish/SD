using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    namespace Server
    {
        interface IServer
        {
            void Register(string id, ICxMsg mb);

            void Unregister(string id, ICxMsg mb);

            void SendMsg(string id, string msg);
        }

        interface ICxMsg
        {
            void AcceptMsg(string id, string msg);
        }
    }
}
