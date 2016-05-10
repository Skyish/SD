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

        public IItem DeserializeObject(string fileName)
        {
            Console.WriteLine("reading file => " + fileName);

            XmlSerializer ser = new XmlSerializer(typeof(Item));

            IItem i;

            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                i = (IItem)ser.Deserialize(reader);
            }

            return i;
        }

    }
}
