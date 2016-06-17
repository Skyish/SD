using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Test.ServiceReference1;

namespace Test
{
    class Program
    {

        private static readonly string URL = "http://localhost:{0}/ChatService/";

        static void Main(string[] args)
        {

            if(args.Length < 1)
            {
                Console.WriteLine("Must provide client service port");
            }

            WSHttpBinding bind = new WSHttpBinding();

            EndpointAddress epAddress = new EndpointAddress(string.Format(URL, args[0]));

            Service1Client chat = new Service1Client(bind, epAddress);

            Console.WriteLine(chat.GetData(0));
            
            Console.ReadLine();
        }
    }
}
