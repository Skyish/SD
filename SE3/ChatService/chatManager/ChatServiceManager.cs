using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService.CentralService;
using ChatService.centralServiceManager;

namespace ChatService.chatManager
{
    class ChatServiceManager
    {

        private readonly string theme;
        private readonly ChatServiceInfo info;
        private readonly CentralServiceManager centralService;

        public ChatServiceManager(string theme, string language, string URL)
        {
            this.theme = theme;

            this.info = new ChatServiceInfo();
            info.URL = URL;
            info.language = language;

            this.centralService = new CentralServiceManager(info);
        }

        public ChatServiceInfo[] Connect()
        {
            return centralService.RegisterChat(theme);
        }

        public string Disconnect()
        {
            return centralService.UnregisterChat(theme);
        }

        public void sendMessage(string message)
        {
            //TODO
        }

    }
}
