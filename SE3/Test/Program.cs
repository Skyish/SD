using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ServiceReference1;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Service1Client chat = new Service1Client();

            Console.WriteLine(chat.GetData(0));
            
            Console.ReadLine();
        }
    }
}
