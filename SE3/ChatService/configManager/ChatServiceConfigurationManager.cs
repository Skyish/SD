using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.configManager
{
    class ChatServiceHostManager
    {

        private readonly ServiceHost serviceHost;
        public string URL
        {
            get;
        }

        public ChatServiceHostManager(string port)
        {
            this.URL = string.Format("http://localhost:{0}/ChatService/", port);

            Uri address = new Uri(URL);

            serviceHost = new ServiceHost(typeof(ChatServiceClient), address);

            serviceHost.AddServiceEndpoint(typeof(IChatService), new WSHttpBinding(), "");

            ServiceMetadataBehavior smb = (ServiceMetadataBehavior)serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

            if (smb == null)
            {
                smb = new ServiceMetadataBehavior();

                smb.HttpGetEnabled = true;

                serviceHost.Description.Behaviors.Add(smb);
            }
        }


        public void OpenService()
        {
            if (serviceHost.State == CommunicationState.Opened || serviceHost.State == CommunicationState.Opening) return;
            serviceHost.Open();
        }

        public void CloseService()
        {
            if (serviceHost.State == CommunicationState.Closed || serviceHost.State == CommunicationState.Closing) return;
            serviceHost.Close();
        }
    }
}
