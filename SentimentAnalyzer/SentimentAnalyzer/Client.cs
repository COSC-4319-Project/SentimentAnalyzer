using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SentimentAnalyzer
{
    class Client
    {
        //IP information
        public static string serverIP = "127.0.0.1";
        public static int port = 25555;

        //Network objects
        private static TcpClient tcpClient;
        private static SslStream sslStream;

        //Data for current logged on user
        public static User currentUser;
        public static bool loggedin = false;
        public static bool offlineMode = false; //Flag to disable network features.


        public static void InitializeClient()
        {
            tcpClient = new TcpClient();
        }

        private static bool Connect()
        {
            Console.WriteLine("Connecting to: " + serverIP + ":" + port);

            try //Try catch to handle when client is unable to connect
            {
                //InitializeClient();
                //tcpClient.Connect(serverIP, port);
                tcpClient = new TcpClient("127.0.0.1", 5300);
                Console.WriteLine("Connected");
                NetworkStream stream = tcpClient.GetStream();

                //Wrap stream with cert call back to allow cert
                sslStream = new SslStream(stream, false, new RemoteCertificateValidationCallback(CertificateValidationCallback));
                sslStream.AuthenticateAsClient("clientName");

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("[ERROR]Connection Failed");
                return false;
            }

        }

        //Callback function that allows all certificates
        static bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static void GuestLogin() //Guest login, ID = -1 means offline.
        {
            loggedin = offlineMode = true;
            currentUser = new User("Guest", "", -1, "guest");
        }

        public static List<string> GetLexicon(int lexNum) //Gets lexicon from server (for updates)
        {
            if (!Connect()) //Try Connect
            {
                return null;
            }

            SendMessage("LEX|REQ|" + lexNum); //send Lexicon request message
            int length = int.Parse(ReciveMessage()); //Server sends length of lexicon
            string lex = ReciveMessage(8192); //Server sends lexicon.
            tcpClient.Close();
            
            return new List<string>(Utilites.SplitToLines(lex)); //Return list split along newline characters
        }

        public static int GetLexiconVersion(int lexNum) //Gets most recent lexicon version from server
        {
            if (!Connect())
            {
                return -1;
            }
            SendMessage("LEX|VER|" + lexNum); //Lex Version message
            int ver = int.Parse(ReciveMessage()); //Server sends version back
            tcpClient.Close();
            return ver;

        }

        public static bool AttemptLogin(string username, string password)
        {
            //Attempt connection
            if (!Connect())
            {
                return false;
            }
            //Request salt from server for user
            SendMessage("SLT|" + username);
            string salt = ReciveMessage();

            if (salt == "INVALID") //Check we recived a valid salt
            {
                return false;
            }
            //Hash user entered password with provided salt
            string saltedPassword = LoginUtility.HashFromSalt(password, salt);
            tcpClient.Close();
            Connect();

            //Send salted pasword and username to server
            SendMessage("LGN|" + username + "|" + saltedPassword);

            //Recive server's resoponse
            string response = ReciveMessage();
            string[] splitRes = response.Split('|');

            tcpClient.Close(); //Close connection

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

        //ACT|userName|password|name - create account message
        public static bool CreateAccount(string username, string password, string name)
        {
            Connect();
            if (!Connect())
            {
                return false;
            }

            SendMessage(string.Format("ACT|{0}|{1}|{2}", username, LoginUtility.SaltedHash(password), LoginUtility.SaltedHash(name)));
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

        public static bool UpdateAccount(string username, string oldPassword, string newPassword)
        {
            if (!Connect()) //attempt connection to server
            {
                return false;
            }

            //Request salt from server for user
            SendMessage("SLT|" + username);
            string salt = ReciveMessage();

            if (salt == "INVALID") //Check we recived a valid salt
            {
                return false;
            }
            //Hash current passsword
            string hashPassword = LoginUtility.HashFromSalt(oldPassword, salt);

            SendMessage(string.Format("UAP|{0}|{1}|{2}", username, hashPassword, LoginUtility.SaltedHash(newPassword)));
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

        public static bool RequestPasswordToken(string username, string email)
        {
            if (!Connect())
            {
                return false;
            }
            SendMessage(string.Format(("ACT|RST|REQ|{0}|{1}"), username, email));
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
            if (!Connect())
            {
                return false;
            }
            SendMessage(string.Format(("ACT|RST|{0}|{1}|{2}"), username, token, LoginUtility.SaltedHash(newPassword)));
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
            if (!Connect())
            {
                return new HistoryRec();
            }
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

        //AHIS|asin|uID|adjRat|productName|numRev|numPos|numNeg|connfidence|dateAnalyzed|origRating
        public static void SendReviewHistory(HistoryRec rec)
        {
            Connect();
            SendMessage(string.Format("AHIS|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", rec.asinID,rec.uID, rec.adjustedRating, rec.prodName, rec.numRev,rec.numPos,rec.numNeg, rec.confidence, rec.dateAnalyzed,rec.orginalRating));
            tcpClient.Close();
        }

        static void SendMessage(string message)
        {
            message = "@" + message; //First character is split into another message for some reason in SSL
            byte[] buffer = Encoding.ASCII.GetBytes(message); //Encode string to byte array to be sent
            sslStream.Write(buffer, 0, buffer.Length); //sends byte array to client
        }
        static void SendMessageUTF8(string message)
        {
            message = "@" + message; //First character is split into another message for some reason in SSL
            byte[] buffer = Encoding.UTF8.GetBytes(message); //Encode string to byte array to be sent
            sslStream.Write(buffer, 0, buffer.Length); //sends byte array to client
        }
        static string ReciveMessage(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int i = sslStream.Read(buffer,0,bufferSize);
            i = sslStream.Read(buffer, 0, bufferSize);
            return Encoding.ASCII.GetString(buffer,0,i);
        }
        static string ReciveMessage()
        {
            return ReciveMessage(8192);
        }
        static string ReciveMessageUTF8(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int i = sslStream.Read(buffer, 0, bufferSize);
            i = sslStream.Read(buffer, 0, bufferSize);
            return Encoding.UTF8.GetString(buffer, 0, i);
        }
        static string ReciveMessageUTF8()
        {
            return ReciveMessageUTF8(8192);
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
        public float orginalRating;
        public int uID;
        public DateTime dateAnalyzed;

        public HistoryRec(string asinID, string prodName, int numRev, int numPos, int numNeg, float confidence, float adjustedRating, float origRating, int uID, DateTime dateAnalyzed)
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
            this.orginalRating = origRating;
        }

        //asin|uID|adjRat|productName|numRev|numPos|numNeg|connfidence|dateAnalyzed|origRating
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
            orginalRating = float.Parse(message[9]);
        }

        public HistoryRec(int val) //Used for empty record.
        {
            uID = numNeg = numPos = numRev = val;
            confidence = adjustedRating = orginalRating =(float) val;
            asinID = val.ToString();
            dateAnalyzed = DateTime.Now;
            prodName = "EMPTY";
        }
    }

}
