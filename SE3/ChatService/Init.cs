using ChatService.CentralService;
using ChatService.chatManager;
using ChatService.configManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    class Init
    {

        private static ChatServiceHostManager service;

        static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Console.WriteLine("Must provide a port");
                return;
            }

            service = new ChatServiceHostManager(args[0]);
            service.OpenService();

            Console.WriteLine("Service is running!");

            char[] delimiter = new char[] { ' ' };
            string cmd;
            while((cmd = Console.ReadLine()) != "exit")
            {
                string[] commands = cmd.Split(delimiter);
                switch (commands[0])
                {
                    case "newChat":
                        beginNewChat(commands);
                        break;
                    case "leaveChat":
                        LeaveChat(commands);
                        break;
                }
            }

            service.CloseService();
            
        }

        private static void LeaveChat(string[] commands)
        {
            if (commands.Length < 3)
            {
                Console.WriteLine("Must provide theme and language");
            }
            ChatServiceManager chat = new ChatServiceManager(commands[1], commands[2], service.URL);
            Console.WriteLine(chat.Disconnect());
        }

        private static void beginNewChat(string[] commands)
        {
            if(commands.Length < 3)
            {
                Console.WriteLine("Must provide theme and language");
            }
            ChatServiceManager chat = new ChatServiceManager(commands[1], commands[2], service.URL);

            foreach(ChatServiceInfo csi in chat.Connect())
            {
                Console.WriteLine(csi.URL);
                Console.WriteLine(csi.language);
                if(csi.URL != service.URL)
                {
                    connectWithChatParticipant(csi.URL, csi.language, commands[1]);
                }
                
            }
        }

        //TODO callback to be notified of new participant in chat, refactor this function for a proper class
        private static void connectWithChatParticipant(string url, string language, string theme)
        {
            WSHttpBinding bind = new WSHttpBinding();

            EndpointAddress epAddress = new EndpointAddress(url);

            ChatServiceHost.ChatServiceClient chatClient = new ChatServiceHost.ChatServiceClient(bind, epAddress);

            string cmd;
            while ((cmd = Console.ReadLine()) != ":exit")
            {
                chatClient.SendMessage(cmd);     
            }

            chatClient.Close();
            LeaveChat(new string[] { theme, language });
        }
    }
}
