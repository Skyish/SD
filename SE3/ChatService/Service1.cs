using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatService.Translator;
using ChatService.CentralService;

namespace ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            //LanguageServiceClient translator = new LanguageServiceClient();

            CentralServiceClient centralCervice = new CentralServiceClient();

            Theme t = new Theme();
            t.theme = "Sports";

            ChatServiceInfo info = new ChatServiceInfo();
            info.URL = "lelelelel";
            info.language = "Congulense";
            string resp = centralCervice.Register(t, info);

            return resp;
        }
    }
}
