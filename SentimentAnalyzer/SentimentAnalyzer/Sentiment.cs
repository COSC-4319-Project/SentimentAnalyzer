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
            Paragraph paragraph = Tokenize(text);
            negPerc = (float)paragraph.negWords / (float)paragraph.wordCount;
            posPerc = (float)paragraph.posWords / (float)paragraph.wordCount;
            neuPerc = ((float)paragraph.wordCount - (float)paragraph.negWords - (float)paragraph.posWords) / (float)paragraph.wordCount;
            //Debug Outputs
            Console.WriteLine("Neg %:" + negPerc);
            Console.WriteLine("Neu %:" + neuPerc);
            Console.WriteLine("Pos %:" + posPerc);
            Console.WriteLine("Word cnt:" + paragraph.wordCount);
            Console.WriteLine("posWord cnt:" + paragraph.posWords);
            Console.WriteLine("negWord cnt:" + paragraph.negWords);

            if (negPerc > posPerc)
            {
                return -1;
            }
            else if (negPerc < posPerc)
            {
                return 1;
            }
            return 0; 
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
                bool negation = false; //Flag to negate next word

                foreach (string word in sent.Split(delemiterCharsWords))//Split words
                {
                    if(word.Length > 0)
                    {
                        TaggedWord aWord = TagWord(word);

                        if (negation) //Negate word
                        {
                            negation = false;
                            aWord.tag = InvertTag(aWord.tag);
                        }
                        if (aWord.tag == Tag.negation) //If negation flip previous and next words
                        {
                            negation = true; //Flag to negate next word
                            //Remove last word flip tag and re insert
                            TaggedWord bWord = sentence.words[sentence.words.Count - 1];
                            sentence.words.RemoveAt(sentence.words.Count - 1);
                            if (bWord.tag == Tag.negWord)
                            {
                                paragraph.negWords--;
                                paragraph.posWords++;
                                bWord.tag = Tag.posWord;
                            }
                            if (bWord.tag == Tag.posWord)
                            {
                                paragraph.negWords++;
                                paragraph.posWords--;
                                bWord.tag = Tag.negWord;
                            }
                           
                            bWord.tag = InvertTag(bWord.tag);
                            sentence.words.Add(bWord); //Readd modified word.
                        }

                        //Update Word Counts
                        paragraph.wordCount++;
                        if (aWord.tag == Tag.negWord)
                        {
                            paragraph.negWords++;
                        }
                        else if(aWord.tag == Tag.posWord)
                        {
                            paragraph.posWords++;
                        }

                        sentence.words.Add(aWord);
                        Console.WriteLine(aWord);//Debuging purposes
                    }
                }
                paragraph.sentences.Add(sentence);
            }

            return paragraph;
        }

        static TaggedWord TagWord(string text) //Tags a word based of Lexicon
        {
            TaggedWord word = new TaggedWord();
            word.word = text;

            if (Lexicon.SearchNeg(text))
            {
                word.tag = Tag.negWord;
            }
            else if (Lexicon.SearchPos(text))
            {
                word.tag = Tag.posWord;
            }
            else if (Lexicon.SearchNegation(text))
            {
                word.tag = Tag.negation;
            }
            //Need check here targets (targets should be based of product type and pulled specs)
            return word;
        }

        static Tag InvertTag(Tag tag) //Flip pos to neg or neg to pos (all else return no change)
        {
            if (tag == Tag.posWord)
            {
                return Tag.negWord;
            }
            else if (tag == Tag.negWord)
            {
                return Tag.posWord;
            }

            return tag;
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

        public override string ToString()
        {
            return word + " : " + tag;
        }
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
