using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatService.CentralService;
using ChatService.centralServiceManager;
using System.ServiceModel;

namespace ChatService.chatManager
{
    class ChatServiceManager: ICentralServiceCallback
    {

        private readonly string theme;
        private readonly ChatServiceInfo info;
        private readonly CentralServiceManager centralService;

        private Dictionary<string, ChatServiceHost.ChatServiceClient> chatClients = new Dictionary<string, ChatServiceHost.ChatServiceClient>();

        public ChatServiceManager(string theme, string language, string URL)
        {
            this.theme = theme;

            this.info = new ChatServiceInfo();
            info.URL = URL;
            info.language = language;

            this.centralService = new CentralServiceManager(info, this);
        }

        public ChatServiceInfo[] Connect()
        {
            return centralService.RegisterChat(theme);
        }

        public string Disconnect()
        {
            return centralService.UnregisterChat(theme);
        }

        public void chat()
        {
            string message;
            while ((message = Console.ReadLine()) != ":exit")
            {
                foreach(ChatServiceHost.ChatServiceClient client in chatClients.Values)
                {
                    client.SendMessage(message);
                }
            }

            closeConnectionsWithClients();
            centralService.UnregisterChat(theme);
        }

        private void closeConnectionsWithClients()
        {
            foreach(ChatServiceHost.ChatServiceClient client in chatClients.Values)
            {
                client.Close();
            }

            chatClients = new Dictionary<string, ChatServiceHost.ChatServiceClient>();
        }

        internal void connectWithChatParticipants(ChatServiceInfo[] chatServiceInfos)
        {
            foreach(ChatServiceInfo participant in chatServiceInfos)
            {
                if(participant.URL != info.URL)
                    connectWithChatClient(participant);
            }

            chat();
        }

        private void connectWithChatClient(ChatServiceInfo participant)
        {
            WSHttpBinding bind = new WSHttpBinding();

            EndpointAddress epAddress = new EndpointAddress(participant.URL);

            ChatServiceHost.ChatServiceClient chatClient = new ChatServiceHost.ChatServiceClient(bind, epAddress);

            this.chatClients.Add(participant.URL, chatClient);
        }

        public void newAnnounce(ChatServiceInfo newClient)
        {
            Console.WriteLine("Got new participant at " + newClient.URL);
            connectWithChatClient(newClient);

        }

        public void newDisconnect(ChatServiceInfo leavingClient)
        {
            if (chatClients.ContainsKey(leavingClient.URL))
            {
                chatClients[leavingClient.URL].Close();
                chatClients.Remove(leavingClient.URL);
            }
        }
    }
}
