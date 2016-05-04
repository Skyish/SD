using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServerInfo
{
    public interface IServer
    {
        void Register(string id, ICxMsg mb);

        void Unregister(string id, ICxMsg mb);

        void SendMsg(string id, string msg);
    }

    public interface ICxMsg
    {
        void AcceptMsg(string id, string msg);
    }
}
