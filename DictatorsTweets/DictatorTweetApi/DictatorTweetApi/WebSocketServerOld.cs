using DictatorTweetApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;

namespace DictatorTweetApi
{
    public interface IWebSocketServer
    {
        void Start();
    }
    public class WebSocketServerOld : IWebSocketServer
    {
        bool isRunning = false;

        static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        List<Socket> clientSockets = new List<Socket>();

        private readonly Thread serverThread;
        private readonly Thread twitterThread;

        private readonly ITweetService tweetService;
        public WebSocketServerOld(ITweetService ts)
        {
            tweetService = ts;
            serverThread = new Thread(StartServerThread);
            twitterThread = new Thread(twitterFeedSender);
        }

        public void Start()
        {
            //Get the localhost
            IPAddress address = Dns.GetHostAddresses("localhost").Where(x => x.AddressFamily == AddressFamily.InterNetwork).First();
            
            IPEndPoint iPEndPoint = new IPEndPoint(address, 8081);
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

                    lock (clientSockets)
                    {

                        //Send the tweet to all websockets listening
                        foreach (Socket socket in clientSockets.ToList())
                        {
                            if (socket.Connected)
                            {
                                try
                                {
                                    socket.Send(Encoding.ASCII.GetBytes(jsonMessage));
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine("-- Client socket disconnected --");
                                }
                            }
                            else
                            {
                                clientSockets.Remove(socket);
                            }
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
                        Debug.WriteLine("--- Client connected");
                        lock (clientSockets)
                        {

                        clientSockets.Add(clientSocket);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("SOMETHING WENT WRONG, " + e.Message);
                }

            }
        }

    }
}
