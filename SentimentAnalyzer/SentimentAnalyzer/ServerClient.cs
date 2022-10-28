using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SentimentAnalyzer
{
    class ServerClient
    {
        public static string serverIP = "127.0.0.1";
        public static int port = 25555;
        private static NetworkStream msgStream = null;
        private static TcpClient tcpClient;

        public static void InitializeClient()
        {
            tcpClient = new TcpClient();
        }

        public static void TestClient()
        {
            Connect();
            SendMessage("LEX|REQ|0");
            int length = int.Parse(ReciveMessage()); //Get length of lexicon
            Console.WriteLine(length);
            string lex = ReciveMessage(length);
            Console.WriteLine(lex);
            tcpClient.Close();
        }
        public static string GetLexicon(int lexNum)
        {
            Connect();
            SendMessage("LEX|REQ|" + lexNum);
            int length = int.Parse(ReciveMessage()); //Get length of lexicon
            Console.WriteLine(length);
            string lex = ReciveMessage(length);
            tcpClient.Close();
            return lex;
        }
        public static int GetLexiconVersiom(int lexNum)
        { 
            Connect();
            SendMessage("LEX|VER|" + lexNum);
            int ver = int.Parse(ReciveMessage()); //Get length of lexicon
            tcpClient.Close();
            return ver;

        }
        private static bool Connect()
        {
            Console.WriteLine("Connecting to: " + serverIP + ":" + port);
            try //Try catch to handle when client is unable to connect
            {
                tcpClient.Connect(serverIP, port);
                Console.WriteLine("Connected");
                return true;
            }
            catch (SocketException exception)
            {
                Console.WriteLine("[ERROR]Connection Failed");
                return false;
            }
        }

        static void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message); //Encode string to byte array to be sent
            tcpClient.GetStream().Write(buffer, 0, buffer.Length); //sends byte array to client
        }
        static void SendMessageUTF8(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message); //Encode string to byte array to be sent
            tcpClient.GetStream().Write(buffer, 0, buffer.Length); //sends byte array to client
        }
        static string ReciveMessage(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int i = tcpClient.Client.Receive(buffer);
            return System.Text.Encoding.ASCII.GetString(buffer,0,i);
        }
        static string ReciveMessage()
        {
            return ReciveMessage(2048);
        }
        static string ReciveMessageUTF8(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int i = tcpClient.Client.Receive(buffer);
            return System.Text.Encoding.UTF8.GetString(buffer, 0, i);
        }
        static string ReciveMessageUTF8()
        {
            return ReciveMessageUTF8(2048);
        }
    }
}
