//Tilly Dewing Fall 2022
//Software Engineering 4319

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.IO; //Temporary until SQL implimentation
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalyzer
{
    class Login
    {
        public static bool loggedin = false;

        private static User currentUser;
        private static List<string> userDB; //Temporary until SQL database is connected

        private static string userDBLoc;

        public static void LoadUserDB(string applicationPath) //Temporary until SQL database is connected
        {
            userDBLoc = applicationPath + "/USERDB";
            userDB = File.ReadAllLines(userDBLoc).ToList<string>();
        }
        public static void SaveUserDB()//Temporary until SQL database is connected
        {
            File.WriteAllLines(userDBLoc, userDB);
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }

        public static bool AttemptLogin(string username, string password)
        {
            //Grab Stored password
            string storedPswd = RetriveHashedPassword(username);
            if(storedPswd.Length > 0) //username in database
            {
                //Convert to byte array
                byte[] hashBytes = Convert.FromBase64String(storedPswd);

                //Get Salt (first 16 bytes)
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                //Compute hash for password with no salt
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                //Compare results
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false; //invalid password
                    }
                }
                currentUser = new User(username, storedPswd, 0);//user ID should be retrived from database.
                loggedin = true;
                return true; //correct
            }

            return false; //invalid user
        }

        public static string SaltedHash(string plainText)
        {
            //Create a salt
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            //Create Bytes of hash value
            var pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            //Combined Hash and Salt
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Convert to string
            return Convert.ToBase64String(hashBytes);
        }

        public static bool ChangePassword(string username, string currentPass, string newPass)
        {
            if (AttemptLogin(username, currentPass))
            {
                string saltedHash = SaltedHash(newPass);
                //SQL command to store new saltedhash under username
                
                //temporary
                for (int i = 0; i <= userDB.Count - 1; i++)
                {
                    string[] splitRec = userDB[i].Split(';');
                    if (username == splitRec[0])
                    {
                        userDB[i] = username + ";" + saltedHash;
                        SaveUserDB();
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CreateAccount(string username, string password)
        {
            if (!CheckUsername(username)) //if user is not in DB
            {
                currentUser = new User(username, SaltedHash(password), 0);
                //SQL Call to store user in database here
                userDB.Add(username + ";" + currentUser.password);
                SaveUserDB();
                loggedin = true;
                return true;
            }
            return false;

        }

        private static bool CheckUsername(string username) //returns true if username is in DB
        {
            foreach (string record in userDB)
            {
                string[] splitRec = record.Split(';');
                if (splitRec[0] == username)
                {
                    return true;
                }
            }
            return false;
        }

        private static string RetriveHashedPassword(string username)
        {
            //SQL Call to retrive password hash here

            //Temporary
            foreach (string record in userDB)
            {
                string[] splitRec = record.Split(';');
                if (username == splitRec[0])
                {
                    return splitRec[1];
                }
            }

            return "";
        }
    }

    struct User
    {
        public string userName;
        public string password;
        public int userID;

        public User(string userName, string password, int userID)
        {
            this.userName = userName;
            this.password = password;
            this.userID = userID;
        }
    }
}
