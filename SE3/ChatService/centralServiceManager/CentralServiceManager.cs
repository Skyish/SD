using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService.CentralService;
using ChatService.chatManager;
using System.ServiceModel;

namespace ChatService.centralServiceManager
{
    class CentralServiceManager
    {

        private ChatServiceInfo chatInfo;
        private readonly CentralServiceClient centralService;
        private ChatServiceManager chatServiceManager;

        public CentralServiceManager(ChatServiceInfo chatInfo, ChatServiceManager chatServiceManager)
        {
            this.chatServiceManager = chatServiceManager;
            this.chatInfo = chatInfo;
            this.centralService = new CentralServiceClient(new InstanceContext(chatServiceManager));
        }

        public ChatServiceInfo[] RegisterChat(string theme)
        {
            return centralService.Register(theme, chatInfo);
        }

        public string UnregisterChat(string theme)
        {
            return centralService.UnRegister(theme, chatInfo);
        }
    }
}
