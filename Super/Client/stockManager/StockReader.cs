using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using SharedServerInfo;

namespace Client.stockManager
{
    class StockReader
    {

        public static Dictionary<string, IItem> DeserializeItems(string[] itemsPath)
        {
            Dictionary<string, IItem> items = new Dictionary<string, IItem>();
            foreach(string s in itemsPath)
            {
                IItem item = Deserialize(s);
                items.Add(item.Name, item);
            }
            return items;
        }

        private static IItem Deserialize(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Item));
            IItem item;
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                item = (IItem)ser.Deserialize(reader);
            }

            return item;
        }

    }
}
