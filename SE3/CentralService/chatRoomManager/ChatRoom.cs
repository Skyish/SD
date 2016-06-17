using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.chatRoomManager
{
    class ChatRoom
    {
        public string theme { get; }

        private List<ChatServiceInfo> participants { get; }

        public ChatRoom(string theme)
        {
            this.theme = theme;
            this.participants = new List<ChatServiceInfo>();
        }

        public void AddParticipant(ChatServiceInfo client)
        {
            if(!participants.Contains(client))
                participants.Add(client);
        }

        public void RemoveParticipant(ChatServiceInfo client)
        {
            participants.Remove(client);
        }
    }
}
