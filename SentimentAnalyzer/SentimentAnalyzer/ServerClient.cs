using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SentimentAnalyzer
{
    class ServerClient
    {
        public static string serverIP = "127.0.0.1";
        public static int port = 25555;
        public static int bufferSize = 2048; //2KB buffer size for messages

        private static NetworkStream msgStream = null;
        private static TcpClient tcpClient;

        public static bool Connect()
        {
            Console.WriteLine("Connecting to: " + serverIP + ":" + port);
            try //Try catch to handle when client is unable to connect
            {
                tcpClient.Connect(serverIP, port);
                EndPoint endPoint = tcpClient.Client.RemoteEndPoint;
            }
            catch (SocketException exeption)
            {
                Console.WriteLine("[ERROR]Connection Failed");
                return false;
            }
        }
    }
}
