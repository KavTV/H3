using System;
using System.Net;


namespace WebClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            while (true)
            {

                //Get ip address from user
                Console.WriteLine("INPUT IP ADDRESS TO SOCKET THAT YOU WANT TO CONNECT TO");
                string inputIp = Console.ReadLine();
                client.ConnectWebsocket(IPAddress.Parse(inputIp), 8080);

                while (true)
                {
                    client.PrintSocketMessage();
                    Console.WriteLine("PRESS ENTER TO MAKE REQUEST");
                    Console.ReadLine();
                }
            }

        }
    }
}
