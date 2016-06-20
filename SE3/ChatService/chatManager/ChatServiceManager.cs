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

        private Dictionary<string, ChatService> chatClients = new Dictionary<string, ChatService>();

        public ChatServiceManager(string theme, string language, string URL, string username)
        {
            this.theme = theme;

            this.info = new ChatServiceInfo();
            info.URL = URL;
            info.language = language;
            info.username = username;

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
                foreach(ChatService client in chatClients.Values)
                {
                    //TODO translate!!
                    Translator.LanguageServiceClient translator = new Translator.LanguageServiceClient();
                    string translated = translator.Translate("F4E6E0444F32B660BED9908E9744594B53D2E864", message, info.language, client.chatInfo.language, "text/plain", "", "");
                    client.chatClient.SendMessage(info.username ,translated);
                }
            }

            closeConnectionsWithClients();
            centralService.UnregisterChat(theme);
        }

        private void closeConnectionsWithClients()
        {
            foreach(ChatService client in chatClients.Values)
            {
                client.chatClient.Close();
            }

            chatClients = new Dictionary<string, ChatService>();
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

            this.chatClients.Add(participant.URL, new ChatService(participant, chatClient));
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
                chatClients[leavingClient.URL].chatClient.Close();
                chatClients.Remove(leavingClient.URL);
            }
        }
    }
}
