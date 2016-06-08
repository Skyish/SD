using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Lifetime;

namespace Client.stockManager
{
    class StockManagerSponsor : IStockManagerSponsor
    {
        private DateTime lastRenewal;

        public StockManagerSponsor()
        {
            lastRenewal = DateTime.Now;
        }

        public TimeSpan Renewal(ILease lease)
        {
            lastRenewal = DateTime.Now;
            return TimeSpan.FromSeconds(10);
        }
    }
}
