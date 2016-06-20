using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatService.Translator;
using ChatService.CentralService;

namespace ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ChatServiceClient : IChatService
    {
        public void SendMessage(string username, string message)
        {
            Console.WriteLine();
            Console.WriteLine(username + " => " + message);
            Console.WriteLine();
        }
    }
}
