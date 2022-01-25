using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WebClient
{
    internal class Client
    {
        Socket socket;
        public void ConnectWebsocket(IPAddress address, int port)
        {
            IPEndPoint ipe = new IPEndPoint(address, port);
            Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            tempSocket.Connect(ipe);

            this.socket = tempSocket;
        }

        public void PrintSocketMessage()
        {
            if (!socket.Connected)
            {
                return;
            }
            //Could change GET to POST and we would get a different response from the server.
            string request = @"GET / HTTP/1.1
                                Host: 10.108.130.123:8080
                                Connection: keep - alive
                                Cache - Control: max - age = 0
                                Upgrade - Insecure - Requests: 1
                                User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 97.0.4692.99 Safari / 537.36";
            
            Console.WriteLine("Sending request");
            socket.Send(Encoding.UTF8.GetBytes(request));

            byte[] bytesReceived = new byte[256];

            Console.WriteLine("Getting message...");
            int bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);

            Console.WriteLine(Encoding.ASCII.GetString(bytesReceived, 0, bytes));
        }

    }
}
