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

        public List<ChatServiceInfo> JoinChatRoom(string theme, ChatServiceInfo participant, INewParticipantAnnouncer cli)
        {
            if (!chatRooms.Keys.Contains(theme))
            {
                CreateChatRoom(theme);
            }

            AnnounceNewClient(chatRooms[theme], participant);

            chatRooms[theme].AddParticipant(participant, cli);

            return chatRooms[theme].clientsServices;
        }

        public void AnnounceNewClient(ChatRoom room, ChatServiceInfo newParticipant)
        {

            foreach (INewParticipantAnnouncer client in room.clients.Values)
            {
                client.newAnnounce(newParticipant);
            }
        }

        public void AnnounceLeavingClient(ChatRoom room, ChatServiceInfo leavingClient)
        {
            foreach(INewParticipantAnnouncer client in room.clients.Values)
            {
                client.newDisconnect(leavingClient);
            }
        }

        public void LeaveChatRoom(string theme, ChatServiceInfo participant)
        {
            if (!chatRooms.Keys.Contains(theme))
                return;

            AnnounceLeavingClient(chatRooms[theme], participant);

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
