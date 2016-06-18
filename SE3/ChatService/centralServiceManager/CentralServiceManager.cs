﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService.CentralService;

namespace ChatService.centralServiceManager
{
    class CentralServiceManager
    {

        private ChatServiceInfo chatInfo;
        private readonly CentralServiceClient centralService;

        public CentralServiceManager(ChatServiceInfo chatInfo)
        {
            this.chatInfo = chatInfo;
            this.centralService = new CentralServiceClient();
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
