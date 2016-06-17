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

        private readonly Theme theme;
        private readonly ChatServiceInfo info;
        private readonly CentralServiceManager centralService;

        public ChatServiceManager(string theme, string language, string URL)
        {
            this.theme = new Theme();
            this.theme.theme = theme;

            this.info = new ChatServiceInfo();
            info.URL = URL;
            info.language = language;

            this.centralService = new CentralServiceManager(info);
        }

        public string Connect()
        {
            return centralService.RegisterChat(theme);
        }

        public void Disconnect()
        {
            centralService.UnregisterChat(theme);
        }

        public void sendMessage(string message)
        {
            //TODO
        }

    }
}
