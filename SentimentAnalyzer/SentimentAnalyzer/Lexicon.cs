//Tilly Dewing Fall 2022
//Software Engineering 4319
//positive and negative word lexicons by Hu and Liu, KDD-2004, https://www.cs.uic.edu/~liub/FBS/sentiment-analysis.html

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
        //Relative file locations
        private static readonly string posLexLoc = "/Lexicon/positive-words.txt";
        private static readonly string negLexLoc = "/Lexicon/negative-words.txt";
        private static readonly string negationLexLoc = "/Lexicon/negation-words.txt";
        private static readonly string contrastLexLoc = "/Lexicon/contrast-words.txt";
        private static readonly string vaugeLexLoc = "/Lexicon/vauge-words.txt";
        private static readonly string emojiLexLoc = "/Lexicon/emoji-sentiment.txt";

        //Lexicons
        private static List<string> posWords;
        private static List<string> negWords;
        private static List<string> negationWords;
        private static List<string> contrastWords;
        private static List<string> vaugeWords;
        private static List<emojiEntry> emojiList;

        //Version array
        private static int[] lexVersions = new int[6];

        public static void LoadLexicon(string applicationPath) //Initialization - Loads Lexicons into memory, application path passed from main.
        {
            posWords = File.ReadAllLines(applicationPath + posLexLoc).ToList<string>();
            negWords = File.ReadAllLines(applicationPath + negLexLoc).ToList<string>();
            negationWords = File.ReadAllLines(applicationPath + negationLexLoc).ToList<string>();
            contrastWords = File.ReadAllLines(applicationPath + contrastLexLoc).ToList<string>();
            vaugeWords = File.ReadAllLines(applicationPath + vaugeLexLoc).ToList<string>();
            LoadAndParseEmojiLexicon(applicationPath);

            GetLexiconVersions(); //Get version numbers for each lexicon
        }

        //Wrappers for easier lexicon searches
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

        private static bool BinarySearch(List<string> list, string word) //Binary search of string list
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

        //Emojis
        private static void LoadAndParseEmojiLexicon(string applicationPath) //Load emoji lexicon from file
        {
            List<string> lines = File.ReadAllLines(applicationPath + emojiLexLoc).ToList<string>(); //Read all lines
            emojiList = new List<emojiEntry>(); //make sure list is allocated
            ParseEmojiLex(lines);
        }

        public static void ParseEmojiLex(List<string> lines) //Parse emoji lexicon into memory from lines
        {
            emojiList.Clear();//Clear current list if any entries exsist
            foreach (string line in lines)
            {
                string[] split = line.Split('#'); //Split each lex entry along delimeter char
                if (split.Length == 1) //Version Number is first line
                {
                    lexVersions[5] = int.Parse(line); 
                }
                else //Every other line a lex definition
                {
                    emojiList.Add(new emojiEntry(split[0], int.Parse(split[1])));
                }
            }
        }
        
        public static int SearchEmojis(string emoji)
        {
            foreach (emojiEntry entry in emojiList)
            {
                if (entry.emoji == emoji)
                {
                    return entry.val;//If found return val
                }
            }
            return 0; //Not Found
        }

        //Get lexicons from server
        public static void UpdateLexiconsFromServer()
        {
            if (Client.offlineMode)
            {
                return;
            }
            //Check lexicon versions and grab if nessesary
            if (Client.GetLexiconVersion(0) > lexVersions[0])
            {
                posWords = Client.GetLexicon(0);
            }

            if (Client.GetLexiconVersion(1) > lexVersions[1])
            {
                negWords = Client.GetLexicon(1);
            }
            if (Client.GetLexiconVersion(2) > lexVersions[2])
            {
                negationWords = Client.GetLexicon(2);
            }
            if (Client.GetLexiconVersion(3) > lexVersions[3])
            {
                contrastWords = Client.GetLexicon(3);
            }
            if (Client.GetLexiconVersion(4) > lexVersions[4])
            {
                vaugeWords = Client.GetLexicon(4);
            }
            if (Client.GetLexiconVersion(5) > lexVersions[5])
            {
                ParseEmojiLex(Client.GetLexicon(5));
            }
        }

        //Parse first line of lexicon to get version number
        private static void GetLexiconVersions()
        {
            lexVersions[0] = int.Parse(posWords[0]);
            lexVersions[1] = int.Parse(negWords[0]);
            lexVersions[2] = int.Parse(negationWords[0]);
            lexVersions[3] = int.Parse(contrastWords[0]);
            lexVersions[4] = int.Parse(vaugeWords[0]);
        }
    }
    struct emojiEntry //Data structure emoji lexicon entries emojis are strings of characters ( :) ) or single unicode characters
    {
        public string emoji; //Emoji character or string
        public int val; //1 or -1

        public emojiEntry(string text, int value)
        {
            emoji = text;
            val = value;
        }
    }
}
