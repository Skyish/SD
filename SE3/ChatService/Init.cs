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
                }
            }

            service.CloseService();
            
        }

        private static void beginNewChat(string[] commands)
        {
            if(commands.Length < 3)
            {
                Console.WriteLine("Must provide theme and language");
            }
            ChatServiceManager chat = new ChatServiceManager(commands[1], commands[2], service.URL);
            chat.connectWithChatParticipants(chat.Connect());
        }
    }
}
