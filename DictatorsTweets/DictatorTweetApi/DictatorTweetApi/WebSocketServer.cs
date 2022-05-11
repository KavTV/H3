using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DictatorTweetApi
{
    public class WebSocketServer
    {
        bool isRunning = false;
        static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private readonly Thread serverThread;
        private readonly Thread twitterThread;
        List<Socket> clientSockets = new List<Socket>();
        public WebSocketServer()
        {
            serverThread = new Thread(StartServerThread);
            twitterThread = new Thread(twitterFeedSender);
        }

        public void Start()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8081);
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
                Thread.Sleep(2000);
                foreach (Socket socket in clientSockets)
                {
                    if (socket.Connected)
                    {
                        socket.Send(Encoding.ASCII.GetBytes("jens"));
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
                    if (clientSocket == null)
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
