using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.chatRoomManager
{
    class ChatRoomManager
    {

        private Dictionary<string, ChatRoom> chatRooms = new Dictionary<string, ChatRoom>();

        public List<ChatServiceInfo> JoinChatRoom(string theme, ChatServiceInfo participant)
        {
            if (!chatRooms.Keys.Contains(theme))
            {
                CreateChatRoom(theme);
            }
            chatRooms[theme].AddParticipant(participant);

            return chatRooms[theme].participants;
        }

        public void LeaveChatRoom(string theme, ChatServiceInfo participant)
        {
            if (!chatRooms.Keys.Contains(theme))
                return;
            chatRooms[theme].RemoveParticipant(participant);
        }

        public string GetStats()
        {
            string result = "";

            result += "number of chatRooms => " + chatRooms.Count;

            foreach(string theme in chatRooms.Keys)
            {
                result += "\n " + theme + " => " + chatRooms[theme].GetCount() + " Participants";
            }

            return result;
        }

        private void CreateChatRoom(string theme)
        {
            chatRooms.Add(theme, new ChatRoom(theme));
        }
    }
}
