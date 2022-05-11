using DictatorTweetApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DictatorTweetApi
{
    public interface IWebSocketServer
    {
        void Start();
    }
    public class WebSocketServer : IWebSocketServer
    {
        bool isRunning = false;

        static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        private readonly Thread serverThread;
        private readonly Thread twitterThread;

        private readonly ITweetService tweetService;
        public WebSocketServer(ITweetService ts)
        {
            tweetService = ts;
            serverThread = new Thread(StartServerThread);
            twitterThread = new Thread(twitterFeedSender);
        }

        public void Start()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.107"), 8081);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(12);
            isRunning = true;

            serverThread.Start();
            twitterThread.Start();

            Debug.WriteLine($"--- Connected to ip {iPEndPoint.Address} on port: {iPEndPoint.Port} ---");
        }
        void twitterFeedSender()
        {
            while (isRunning)
            {
                //Send tweet every 2 seconds
                Thread.Sleep(2000);

                //Only find a tweet if there is any websockets connected
                if (clientSockets.Count != 0)
                {
                    //We will get a new twitter message
                    TwitterMessage twitterMessage = tweetService.GetTwitterMessage();
                    //Convert it to a string
                    string jsonMessage = JsonConvert.SerializeObject(twitterMessage);

                    //Send the tweet to all websockets listening
                    foreach (Socket socket in clientSockets)
                    {
                        if (socket.Connected)
                        {
                            socket.Send(Encoding.ASCII.GetBytes(jsonMessage));
                        }
                    }
                }
            }
        }

        void StartServerThread()
        {
            while (isRunning)
            {
                Socket clientSocket;
                try
                {
                    clientSocket = serverSocket.Accept();
                    if (clientSocket != null)
                    {
                        clientSockets.Add(clientSocket);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("SOMETHING WENT WRONG, " + e.Message);
                }

            }
        }
    }
}
