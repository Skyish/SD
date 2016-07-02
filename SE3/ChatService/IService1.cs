using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatService
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string username, string message);

    }
    
}
