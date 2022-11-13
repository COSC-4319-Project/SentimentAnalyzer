using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalyzer
{
    static class Utilites
    {
        //thanks to Steve Cooper - https://stackoverflow.com/questions/1547476/easiest-way-to-split-a-string-on-newlines-in-net
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

        public static Regex ValidateUsername = new Regex("^[a-zA-Z0-9]+$");
        public static Regex ValidatePassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }
}
