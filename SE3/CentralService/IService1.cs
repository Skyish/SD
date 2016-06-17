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
        string Register(Theme theme, ChatServiceInfo chatInfo);

        [OperationContract]
        void UnRegister(Theme theme, ChatServiceInfo chatInfo);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CentralService.ContractType".
    [DataContract]
    public class Theme
    {
        [DataMember]
        public string theme
        {
            get;
            set;
        }
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
