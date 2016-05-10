using SharedServerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Client.stockManager
{
    
    public class Item : MarshalByRefObject, IItem
    {
        [XmlElement(Namespace = "items")]
        public string Name
        { get; set; }

        [XmlElement(Namespace = "items")]
        public float Price
        { get; set; }

        [XmlElement(Namespace = "items")]
        public int Quantity
        { get; set; }
    }
}
