using System;
using System.Net;

namespace WebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Console.WriteLine("INPUT IP ADDRESS FOR SOCKET");
            //Get the ip form user
            string inputAddress = Console.ReadLine();
            server.Start(IPAddress.Parse(inputAddress), 8080);
        }
    }
}
