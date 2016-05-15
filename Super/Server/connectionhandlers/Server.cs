using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionHandlers
{
    class Server : MarshalByRefObject, IServer
    {
        private List<IStockManager> sm = new List<IStockManager>();

        public List<IStockManager> getStockManagers()
        {
            return sm;
        }

        public void PrintStockManager()
        {
            Console.WriteLine("################################################");
            foreach (IStockManager manager in sm)
            {
                foreach (string key in manager.GetProducts().Keys)
                    Console.WriteLine(key);
            }
            Console.WriteLine("################################################");
        }

        public void Register(IStockManager sm)
        {
            this.sm.Add(sm);
        }

        public bool Unregister(IStockManager sm)
        {
            if (this.sm.Contains(sm))
            {
                this.sm.Remove(sm);
                return true;
            }
            return false;
        }
    }
}
