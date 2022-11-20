using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalyzer
{
    static class Utilites //Program utilties (assorted functions that didn't fit in other classes)
    {
        //thanks to Steve Cooper - https://stackoverflow.com/questions/1547476/easiest-way-to-split-a-string-on-newlines-in-net
        
        //efficently split string along new line characters. (esenstially the same string.split() but far faster)
        public static IEnumerable<string> SplitToLines(this string input) 
        {
            if (input == null)
            {
                yield break;
            }

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        //Check url is in a valid format.
        public static bool CheckValidAmazonURL(string url)
        {
            //Example URL: https://www.amazon.com/Liberty-Imports-Jumbo-Rubber-Duck/dp/B00ODBPB1U/
            string[] splitURL = url.Split('/');
            bool result = true;
            if ((splitURL.Length < 5) || (splitURL[2] != "www.amazon.com") || (splitURL[4] != "dp") || (splitURL[5].Length != 10))
            {
                result = false;
            }

            return result;
        }

        //extract asin from url
        public static string GetAsinFromURL(string url)
        {
            string[] splitURL = url.Split('/');
            if ((splitURL.Length > 5) & (splitURL[5].Length == 10))
            {
                return splitURL[5];
            }
            return "";
        }

        //extract product name from url
        public static string GetProdNameFromURL(string url)
        {
            string[] splitURL = url.Split('/');
            if ((splitURL.Length > 5))
            {
                return splitURL[3];
            }
            return "";
        }

        //Float Clamp function.
        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        //Regex for client side input validation.
        public static Regex ValidateUsername = new Regex("^[a-zA-Z0-9]+$");
        public static Regex ValidatePassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        public static Regex ValidateEmail = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

    }
}
