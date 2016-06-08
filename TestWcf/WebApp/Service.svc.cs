using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, 
    // svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs 
    // at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string DoWork()
        {
            return "Hello World";
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
