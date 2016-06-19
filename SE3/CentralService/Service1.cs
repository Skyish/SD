using CentralService.chatRoomManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant, IncludeExceptionDetailInFaults = true)]
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CentralService : ICentralService
    {

        private ChatRoomManager manager = new ChatRoomManager();

        public List<ChatServiceInfo> Register(string theme, ChatServiceInfo chatInfo)
        {
            INewParticipantAnnouncer cli = OperationContext.Current.GetCallbackChannel<INewParticipantAnnouncer>();
            return manager.JoinChatRoom(theme, chatInfo, cli);
        }

        public string UnRegister(string theme, ChatServiceInfo chatInfo)
        {
            manager.LeaveChatRoom(theme, chatInfo);

            return "Bye from " + theme + " || " + chatInfo.language + " || " + chatInfo.URL + " || " + manager.GetStats();
        }
    }
}
