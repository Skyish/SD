using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace Client.stockManager
{
    class StockManager : MarshalByRefObject, IStockManager
    {

        private Dictionary<string, IItem> items;

        public StockManager(Dictionary<string, IItem> items)
        {
            this.items = items;
        }

        public IItem GetProduct(string name)
        {
            return items[name];
        }

        public IItem GetProduct(string name, int quantity)
        {
            if (items[name] == null || items[name].Quantity < quantity)
                return null;

            items[name].Quantity -= quantity;
            IItem i = new Item();
            i.Name = name;
            i.Price = items[name].Price;
            i.Quantity = quantity;
            return i;
        }

        public Dictionary<string, IItem> GetProducts()
        {
            return items;
        }

        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            lease.Register(new StockManagerSponsor());
            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.InitialLeaseTime = TimeSpan.FromSeconds(20);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(5);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(10);
            }
            return lease;

        }
    }
}
