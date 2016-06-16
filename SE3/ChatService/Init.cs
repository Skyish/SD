using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    class Init
    {

        static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Console.WriteLine("Must provide a port");
                return;
            }

            Uri address = new Uri(string.Format("http://localhost:{0}/ChatService/", args[0]));

            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1), address))
            {
                serviceHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "");

                ServiceMetadataBehavior smb = (ServiceMetadataBehavior)serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

                if(smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    serviceHost.Description.Behaviors.Add(smb);
                }

                serviceHost.Open();

                Console.WriteLine("Service is running!");
                Console.ReadLine();
                

            }
        }
 
    }
}
