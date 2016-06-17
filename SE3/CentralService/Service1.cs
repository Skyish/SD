using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CentralService : ICentralService
    {
        public string Register(Theme theme, ChatServiceInfo chatInfo)
        {
            
            return "Gotcha! " + theme.theme + " || " + chatInfo.language + " || " + chatInfo.URL;
        }

        public void UnRegister(Theme theme, ChatServiceInfo chatInfo)
        {
            throw new NotImplementedException();
        }
    }
}
