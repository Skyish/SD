using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.SD;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceClient sc = new ServiceClient();
            string s = sc.DoWork();
            Console.WriteLine(sc.Add(4, 5));
            Console.WriteLine(sc.Sub(4, 5));
            Console.WriteLine(s);
        }
    }
}
