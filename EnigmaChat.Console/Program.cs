using EnigmaChat.SignalR.Client;
using EnigmaChat.SignalR.Client.EventHandlers;
using System;
using System.Threading.Tasks;

namespace EnigmaChat.Console
{
    public class Program
    {
        static ChatService service;
        static string room;
        static string name;
        static string ConnectionId;
        static Random random = new Random();
        public static async Task Main(string[] args)
        {
            await TestMulticast();
        }
        private static async Task TestMulticast()
        {
            name = "console " + random.Next(0, 10000);
            service = new ChatService();
            service.OnReceivedMessage += Service_OnReceivedMessage;
            System.Console.WriteLine("Enter IP:");
            var ip = System.Console.ReadLine();
            service.Init(ip, ip != "localhost");

            await service.ConnectAsync();
            System.Console.WriteLine("You are connected...");

            await JoinRoom();

            var keepGoing = true;
            do
            {
                var text = System.Console.ReadLine();
                if (text == "exit")
                {
                    keepGoing = false;
                }
                else if (text == "leave")
                {
                    await service.LeaveChannelAsync(room, name);
                    System.Console.WriteLine($"You've left of {room} Room");
                    await JoinRoom();
                }
                else
                {
                    await service.SendMessageAsync(room, name, text);
                }
            }
            while (keepGoing);
        }

        static async Task JoinRoom()
        {
            System.Console.WriteLine($"Enter room ({string.Join(",", service.GetRooms())}):");
            room = System.Console.ReadLine();

            await service.JoinChannelAsync(room, name);
            System.Console.WriteLine($"Entered to {room} Room");
        }



        private static void Service_OnReceivedMessage(object sender, MessageEventArgs e)
        {
            if (e.User == name)
                return;
            System.Console.WriteLine($"{e.User}: {e.Message}");
        }
    }
}
