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
    class Client
    {
        public static string serverIP = "127.0.0.1";
        public static int port = 25555;
        private static NetworkStream msgStream = null;
        private static TcpClient tcpClient;

        private static User currentUser;
        public static bool loggedin = false;
        public static bool offlineMode = false;
        public static void InitializeClient()
        {
            tcpClient = new TcpClient();
        }
        private static bool Connect()
        {
            Console.WriteLine("Connecting to: " + serverIP + ":" + port);

            try //Try catch to handle when client is unable to connect
            {
                InitializeClient();
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
            loggedin = offlineMode = true;
            currentUser = new User("Guest", "", -1, "guest");
        }

        public static List<string> GetLexicon(int lexNum)
        {
            Connect();
            SendMessage("LEX|REQ|" + lexNum);
            int length = int.Parse(ReciveMessage()); //Get length of lexicon
            Console.WriteLine(length);
            string lex = ReciveMessage(length);
            tcpClient.Close();
            
            return new List<string>(Utilites.SplitToLines(lex));
        }

        public static int GetLexiconVersion(int lexNum)
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
            Console.WriteLine("messageSent");

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
            string response = ReciveMessage();
            tcpClient.Close();

            if (response == "VALID")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RequestPasswordToken(string username)
        {
            Connect();
            SendMessage(string.Format(("ACT|RST|REQ|{0}"), username));
            string response = ReciveMessage();
            tcpClient.Close();

            if (response == "VALID")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ResetPasssword(string username, string token, string newPassword)
        {
            Connect();
            SendMessage(string.Format(("ACT|RST|{0}|{1}|{2}"), username, token, newPassword));
            string response = ReciveMessage();
            tcpClient.Close();

            if (response == "VALID")
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
            SendMessage(string.Format("HIS|SNG|{0}", asinID));
            

            string[] splitRes = ReciveMessage().Split('|');

            if (splitRes.Length > 1) //if valid response
            {
                tcpClient.Close();
                return new HistoryRec(splitRes);
            }
            else
            {
                tcpClient.Close();
                return new HistoryRec(-1);
            }
        }
        
        public static HistoryRec[] GetUserHistory() //Temporary
        {
            
            HistoryRec[] records = new HistoryRec[1];

            if (offlineMode)
            {
                return null;
            }

            tcpClient.Close();
            return records;
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
    public struct User
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
    public struct HistoryRec
    {
        public string asinID;
        public string prodName;
        public int numRev;
        public int numNeg;
        public int numPos;
        public float confidence;
        public float adjustedRating;
        public int uID;
        public DateTime dateAnalyzed;

        public HistoryRec(string asinID, string prodName, int numRev, int numPos, int numNeg, float confidence, float adjustedRating, int uID, DateTime dateAnalyzed)
        {
            this.asinID = asinID;
            this.numRev = numRev;
            this.numPos = numPos;
            this.numNeg = numNeg;
            this.confidence = confidence;
            this.adjustedRating = adjustedRating;
            this.uID = uID;
            this.dateAnalyzed = dateAnalyzed;
            this.prodName = prodName;
        }

        public HistoryRec(string[] message) //Parse response from server into record
        {
            asinID = message[0];
            uID = int.Parse(message[1]);
            adjustedRating = float.Parse(message[2]);
            prodName = message[3];
            numRev = int.Parse(message[4]);
            numPos = int.Parse(message[5]);
            numNeg = int.Parse(message[6]);
            confidence = float.Parse(message[7]);
            dateAnalyzed = DateTime.Parse(message[8]);
        }

        public HistoryRec(int val) //Used for empty record.
        {
            uID = numNeg = numPos = numRev = val;
            confidence = adjustedRating = (float) val;
            asinID = val.ToString();
            dateAnalyzed = DateTime.Now;
            prodName = "EMPTY";
        }
    }

}
