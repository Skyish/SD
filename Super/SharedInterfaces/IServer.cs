using System;
using System.Collections.Generic;

namespace SharedServerInfo
{
    public interface IServer
    {
        void Register(IStockManager sm);

        void Unregister(IStockManager sm);

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
}
