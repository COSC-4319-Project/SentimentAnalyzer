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
        public static string posLexLoc = "/Lexicon/positive-words.txt";
        public static string negLexLoc = "/Lexicon/negative-words.txt";
        public static string negationLexLoc = "/Lexicon/negation-words.txt";

        public static List<string> posWords;
        public static List<string> negWords;
        public static List<string> negationWords;

        public static void LoadLexicon(string applicationPath)
        {
            posWords = File.ReadAllLines(applicationPath + posLexLoc).ToList<string>();
            negWords = File.ReadAllLines(applicationPath + negLexLoc).ToList<string>();
            negationWords = File.ReadAllLines(applicationPath + negationLexLoc).ToList<string>();
        }

        public static bool SearchPos(string word)
        {
            return posWords.Contains(word);
        }

        public static bool SearchNeg(string word)
        {
            return negWords.Contains(word);
        }
        public static bool SearchNegation(string word)
        {
            return negationWords.Contains(word);
        }

    }
}
