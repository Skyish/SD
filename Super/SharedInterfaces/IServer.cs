using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace SharedServerInfo
{
    public interface IServer
    {
        void Register(IStockManager sm);

        bool Unregister(IStockManager sm);

        void PrintStockManager();

        List<IStockManager> getStockManagers();
    }
    
    public interface IStockManager
    {
        IItem GetProduct(string name, int quantity);

        IItem GetProduct(string name);

        Dictionary<string, IItem> GetProducts();
    }

    public interface IItem
    {
        string Name { get; set; }

        float Price { get; set; }

        int Quantity { get; set; }
    }

    public interface IStockManagerSponsor : ISponsor
    {
        new TimeSpan Renewal(ILease lease);
    }

    public interface IRingConnection
    {
        void SetServer(IServer server);

        void Connect(string url);

        void Disconect();

        int GetStock(string product);

        int GetRemoteStock(string product);
    }
}
