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

        private static User currentUser;
        public static bool loggedin = false;

        public static void InitializeClient()
        {
            tcpClient = new TcpClient();
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
            catch (SocketException)
            {
                Console.WriteLine("[ERROR]Connection Failed");
                return false;
            }
        }
        
        public static void GuestLogin() //Guest login, ID = -1 means offline.
        {
            loggedin = true;
            currentUser = new User("Guest", "", -1, "guest");
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

        public static bool AttemptLogin(string username, string password)
        {
            Connect();
            SendMessage("LGN|" + username + "|" + password);
            string response = ReciveMessage();
            string[] splitRes = response.Split('|');
            tcpClient.Close();

            if (splitRes.Length > 1) //valid response
            {
                currentUser = new User(username, password, int.Parse(splitRes[0]), splitRes[1]);
                loggedin = true;
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CreateAccount(string username, string password, string name)
        { 
            Connect();
            SendMessage(string.Format("ACT|{0}|{1}|{2}", username, password, name));
            

            if (ReciveMessage() == "VALID")
            {
                tcpClient.Close();
                return true;
            }
            else
            {
                tcpClient.Close();
                return false;
            }
        }

        public static bool UpdateAccount(string username, string oldPassowrd, string newPassword)
        {
            Connect();
            SendMessage(string.Format("UAP|{0}|{1}|{2}", username, oldPassowrd, newPassword));
            tcpClient.Close();

            if (ReciveMessage() == "VALID")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static HistoryRec RequestHistory(string asinID)
        {
            Connect();
            SendMessage(string.Format("HIS|{0}", asinID));
            tcpClient.Close();

            string[] splitRes = ReciveMessage().Split('|');

            if (splitRes.Length > 1) //if valid response
            {
                return new HistoryRec(splitRes);
            }
            else
            {
                return new HistoryRec(-1);
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
    struct User
    {
        public string userName;
        public string password;
        public string name;
        public int userID;

        public User(string userName, string password, int userID)
        {
            this.userName = userName;
            this.password = password;
            this.userID = userID;
            this.name = "name";
        }
        public User(string userName, string password, int userID, string name)
        {
            this.userName = userName;
            this.password = password;
            this.userID = userID;
            this.name = name;
        }
    }
    struct HistoryRec
    {
        public string asinID;
        public int sentimentVal;
        public int numRev;
        public int numNeg;
        public int numPos;
        public float confidence;
        public float adjustedRating;
        public int uID;
        public DateTime dateAnalyzed;

        public HistoryRec(string asinID, int sentimentVal, int numRev, int numPos, int numNeg, float confidence, float adjustedRating, int uID, DateTime dateAnalyzed)
        {
            this.asinID = asinID;
            this.sentimentVal = sentimentVal;
            this.numRev = numRev;
            this.numPos = numPos;
            this.numNeg = numNeg;
            this.confidence = confidence;
            this.adjustedRating = adjustedRating;
            this.uID = uID;
            this.dateAnalyzed = dateAnalyzed;
        }

        public HistoryRec(string[] message) //Parse response from server into record
        {
            asinID = message[0];
            uID = int.Parse(message[1]);
            adjustedRating = float.Parse(message[2]);
            sentimentVal = int.Parse(message[3]);
            numRev = int.Parse(message[4]);
            numPos = int.Parse(message[5]);
            numNeg = int.Parse(message[6]);
            confidence = float.Parse(message[7]);
            dateAnalyzed = DateTime.Parse(message[8]);
        }

        public HistoryRec(int val) //Used for empty record.
        {
            uID = sentimentVal = numNeg = numPos = numRev = val;
            confidence = adjustedRating = (float) val;
            asinID = val.ToString();
            dateAnalyzed = DateTime.Now;
        }
    }

}
