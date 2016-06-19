using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(INewParticipantAnnouncer))]
    public interface ICentralService
    {
        [OperationContract]
        List<ChatServiceInfo> Register(string theme, ChatServiceInfo chatInfo);

        [OperationContract]
        string UnRegister(string theme, ChatServiceInfo chatInfo);

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

    // CallBack interface 
    public interface INewParticipantAnnouncer
    {
        [OperationContract(IsOneWay = false)]
        void newAnnounce(ChatServiceInfo newClient);

        [OperationContract(IsOneWay = false)]
        void newDisconnect(ChatServiceInfo leavingClient);
    }
}
