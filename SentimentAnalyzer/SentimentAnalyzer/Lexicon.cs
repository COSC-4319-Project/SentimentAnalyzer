//Lexicon thanks to

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SentimentAnalyzer
{
    class Lexicon
    {
        private static readonly string posLexLoc = "/Lexicon/positive-words.txt";
        private static readonly string negLexLoc = "/Lexicon/negative-words.txt";
        private static readonly string negationLexLoc = "/Lexicon/negation-words.txt";
        private static readonly string contrastLexLoc = "/Lexicon/contrast-words.txt";
        private static readonly string vaugeLexLoc = "/Lexicon/vauge-words.txt";

        private static List<string> posWords;
        private static List<string> negWords;
        private static List<string> negationWords;
        private static List<string> contrastWords;
        private static List<string> vaugeWords;


        public static void LoadLexicon(string applicationPath)
        {
            posWords = File.ReadAllLines(applicationPath + posLexLoc).ToList<string>();
            negWords = File.ReadAllLines(applicationPath + negLexLoc).ToList<string>();
            negationWords = File.ReadAllLines(applicationPath + negationLexLoc).ToList<string>();
            contrastWords = File.ReadAllLines(applicationPath + contrastLexLoc).ToList<string>();
            vaugeWords = File.ReadAllLines(applicationPath + vaugeLexLoc).ToList<string>();
        }

        public static bool SearchPos(string word)
        {
            return BinarySearch(posWords, word);
            //return posWords.Contains(word);
        }

        public static bool SearchNeg(string word)
        {
            return BinarySearch(negWords, word);
            //return negWords.Contains(word);
        }
        public static bool SearchNegation(string word)
        {
            return BinarySearch(negationWords, word);
            //return negationWords.Contains(word);
        }
        public static bool SearchContrast(string word)
        {
            return BinarySearch(contrastWords, word);
            //return contrastWords.Contains(word);
        }
        public static bool SearchVauge(string word)
        { 
            return BinarySearch(vaugeWords, word);
        }


        private static bool BinarySearch(List<string> list, string word)
        {
            int low = 0, high = list.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                switch (String.Compare(list[mid], word))
                {
                    case -1: //<
                        low = mid + 1;
                        break;
                    case 0: //==
                        return true;
                    case 1: //>
                        high = mid - 1;
                        break;
                }
            }

            return false;
        }
    }
}
