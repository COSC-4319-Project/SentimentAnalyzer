//Tilly Dewing COSC 4319 Spring 2022
//Based of research and lexicon by Hu and Liu, KDD-2004, https://www.cs.uic.edu/~liub/FBS/sentiment-analysis.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalyzer
{
    class Sentiment //Used to try and determine the sentiment of a piece of english text
    {
        public static char[] delemiterCharsSents = {'.','?','!'}; //Used to split senteces (Ending puntuation)
        public static char[] delemiterCharsWords = { ' ', ','};

        public static int Analyze(string text, out float negPerc, out float neuPerc, out float posPerc) //Entry point for sentiment class
        {
            Tokenize(text);
            negPerc = 0;
            posPerc = 0;
            neuPerc = 0;
            return 0; //Returns -1 negative, 0 netural, 1 positive 
        }
        public static int Analyze(string text) //Calls analyze without additonal info
        {
            float X, Y, Z = 0;
            return Analyze(text, out X, out Y, out Z);
        }

        //Idea is to break the sentence up into analyzable tagged chunks
        static Paragraph Tokenize(string Text) //Overkill for now but Paragraph data structure will be nessesary for further work
        {                               
            Paragraph paragraph = new Paragraph();
            paragraph.sentences = new List<Sentence>();
            Console.WriteLine("Pre Tokenize:");
            Console.WriteLine(Text);
            Console.WriteLine("Tokenize:");

            foreach (string sent in Text.Split(delemiterCharsSents)) //Split sentences
            {
                Console.WriteLine("Sent:" + sent);
                Sentence sentence = new Sentence();
                sentence.words = new List<TaggedWord>();

                foreach (string word in sent.Split(delemiterCharsWords))//Split words
                {
                    if(word.Length > 0)
                    {
                        Console.WriteLine("TaggedWord: " + word);
                        TaggedWord aWord;
                        aWord.word = word;
                        aWord.tag = Tag.ignore; //Temporary will use lexicon to determine Tag

                        sentence.words.Add(aWord);
                        paragraph.wordCount++;
                    }
                }
                paragraph.sentences.Add(sentence);
            }

            return paragraph;
        }

    }
    //Sentiment Data Structures
    //Extra int fields are to allow detailed analysis later on.
    enum Tag //Used to tag words inside of a sentence
    { 
        ignore, posWord, negWord, target, negation
    }
    struct TaggedWord
    {
        public string word;
        public Tag tag;
    }
    struct Sentence
    {
        public List<TaggedWord> words;
    }
    struct Paragraph
    {
        public List<Sentence> sentences;
        public int wordCount;
        public int posWords;
        public int negWords;
    }
}
