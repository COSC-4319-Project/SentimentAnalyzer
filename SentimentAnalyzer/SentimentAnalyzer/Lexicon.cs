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

        public static List<string> posWords;
        public static List<string> negWords;

        public static void LoadLexicon()
        {
            posWords = File.ReadAllLines(posLexLoc).ToList<string>(); ;
            negWords = File.ReadAllLines(negLexLoc).ToList<string>();
            foreach (string line in posWords)
                Console.WriteLine(line);
        }

        public static bool SearchPos(string word)
        {
            return posWords.Contains(word);
        }

        public static bool SearchNeg(string word)
        {
            return negWords.Contains(word);

        }
    }
}
