using ChatService.CentralService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.chatManager
{
    class ChatService
    {
        public ChatServiceInfo chatInfo { get; }
        public ChatServiceHost.ChatServiceClient chatClient { get; }

        public ChatService(ChatServiceInfo chatInfo, ChatServiceHost.ChatServiceClient chatClient)
        {
            this.chatInfo = chatInfo;
            this.chatClient = chatClient;
        }
    }
}
