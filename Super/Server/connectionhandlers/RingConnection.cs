﻿using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace ConnectionHandlers
{
    class RingConnection : MarshalByRefObject, IRingConnection
    {

        private IRingConnection ringCon;
        private IServer server;

        public RingConnection()
        {
            Console.WriteLine("ParameterLess constructor invoked!");
        }

        public void SetServer(IServer server)
        {
            this.server = server;
        }

        public void Connect(string url)
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(IRingConnection), url);
            ringCon = (IRingConnection)Activator.GetObject(typeof(IRingConnection), url);
        }

        public void Disconect()
        {
            ringCon.Disconect();
        }

        public int GetRemoteStock(string product)
        {
            return ringCon.GetStock(product);
        }

        public int GetStock(string product)
        {
            server.PrintStockManager();

            return server.getStockManagers().First().GetProduct(product).Quantity;
        }
    }
}
