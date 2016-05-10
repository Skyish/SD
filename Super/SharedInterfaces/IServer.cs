using System;

namespace SharedServerInfo
{
    public interface IServer
    {
        void Register(IStockManager sm);
    }
    
    public interface IStockManager
    {
        string GetProducts();
    }
}
