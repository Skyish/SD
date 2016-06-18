using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICentralService
    {

        //Dictionary<Theme, List<>>

        [OperationContract]
        List<ChatServiceInfo> Register(string theme, ChatServiceInfo chatInfo);

        [OperationContract]
        string UnRegister(string theme, ChatServiceInfo chatInfo);


        // TODO: Add your service operations here
    }

    [DataContract]
    public class ChatServiceInfo
    {

        [DataMember]
        public string URL;

        [DataMember]
        public string language;

        public override bool Equals(object obj)
        {
            ChatServiceInfo csi = (ChatServiceInfo) obj;
            return csi.URL == this.URL && csi.language == this.language;
        }
    }
}
