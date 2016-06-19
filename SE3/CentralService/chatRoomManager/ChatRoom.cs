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

        public Dictionary<string, INewParticipantAnnouncer> clients { get; }

        public List<ChatServiceInfo> clientsServices { get; }

        public ChatRoom(string theme)
        {
            this.theme = theme;
            this.clientsServices = new List<ChatServiceInfo>();
            this.clients = new Dictionary<string, INewParticipantAnnouncer>();
        }

        public void AddParticipant(ChatServiceInfo clientService, INewParticipantAnnouncer client)
        {
            if (!clientsServices.Contains(clientService))
            {
                clientsServices.Add(clientService);
                clients.Add(clientService.URL, client);
            }
                
        }

        public void RemoveParticipant(ChatServiceInfo clientService)
        {
            clientsServices.Remove(clientService);
            clients.Remove(clientService.URL);
        }

        internal string GetCount()
        {
            return clientsServices.Count.ToString();
        }
    }
}
