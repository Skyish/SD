using System;

namespace SharedServerInfo
{
    public interface IServer
    {
        void Register(IStockManager sm);
    }
    
    public interface IStockManager
    {
        void SetItem(IItem i);

        IItem GetProducts();
    }

    public interface IItem
    {
        string Name { get; set; }

        float Price { get; set; }

        int Quantity { get; set; }
    }
}
