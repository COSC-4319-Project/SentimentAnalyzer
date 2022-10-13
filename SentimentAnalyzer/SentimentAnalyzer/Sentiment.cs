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

        const int negationSteps = 2; //Number of steps forward and backward.

        public static float BatchAnalyze(List<string> paragraphs)
        {
            int totalParagraphs = 0;
            int posParagraphs = 0;
            int negParagraphs = 0;

            foreach (string paragraph in paragraphs)
            {
                totalParagraphs++;
                int tempVal = Analyze(paragraph);
                if (tempVal == -1)
                {
                    negParagraphs++;
                }
                else if (tempVal == 1)
                {
                    posParagraphs++;
                }
            }

            return ((float)posParagraphs/(float)totalParagraphs - (float)negParagraphs / (float)totalParagraphs) * 5;
            
        }

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
        static Paragraph Tokenize(string text)
        {
            text = text.ToLower(); //Set string data to lower case
            Paragraph paragraph = new Paragraph();
            paragraph.sentences = new List<Sentence>();
            Console.WriteLine("Pre Tokenize:");
            Console.WriteLine(text);
            Console.WriteLine("Tokenize:");

            foreach (string sent in text.Split(delemiterCharsSents)) //Split sentences
            {
                Console.WriteLine("Sent:" + sent);
                Sentence sentence = new Sentence();
                sentence.words = new List<TaggedWord>();
                bool negate = false; //flag to swap rest of sentence.
                int weight = 1; //weight of words in sentence
                Tag lastTag = Tag.ignore; //Last sentiment tag of sentence for vauge words.

                foreach (string word in sent.Split(delemiterCharsWords))//Split words
                {
                    if(word.Length <= 1) //Discard empty words
                    {
                        continue; //Skip to next item
                    }

                    TaggedWord aWord = TagWord(word);
                    paragraph.wordCount++;

                    //if (negsteps > 0)
                    if (negate)
                    {
                        //negsteps--;
                        aWord.tag = InvertTag(aWord.tag);
                    }
                    if (aWord.tag == Tag.negation) //set flag tp negate proceding words 
                    {
                        negate = true;
                    }
                    else if (aWord.tag == Tag.contrast) //Contrast words doubles weight
                    {
                        weight = 2;
                    }
                    else if (aWord.tag == Tag.negWord)
                    {
                        paragraph.negWords = paragraph.negWords + weight;
                        lastTag = Tag.negWord;
                    }
                    else if (aWord.tag == Tag.posWord)
                    {
                        paragraph.posWords = paragraph.posWords + weight;
                        lastTag = Tag.posWord;
                    }
                    else if (aWord.tag == Tag.vauge)
                    {
                        if (lastTag != Tag.ignore) //Vauge words take on preceding sentiment
                        {
                            paragraph.wordCount++;//Weight vauge words at half of weight of normal
                            if (lastTag == Tag.posWord)
                            {
                                paragraph.posWords++;
                            }
                            else
                            {
                                paragraph.negWords++;
                            }
                        }
                    }

                    sentence.words.Add(aWord); //add new word
                    Console.WriteLine(aWord);//Debuging purposes
                }
                paragraph.sentences.Add(sentence);
            }

            return paragraph;
        }

        static TaggedWord TagWord(string text) //Tags a word based of Lexicon
        {
            TaggedWord word = new TaggedWord();
            word.word = text;
            //Smallest Searches first
            if (Lexicon.SearchContrast(text))
            {
                word.tag = Tag.contrast;
            }
            else if (Lexicon.SearchVauge(text))
            {
                word.tag = Tag.vauge;
            }
            else if (Lexicon.SearchNegation(text))
            {
                word.tag = Tag.negation;
            }
            else if (Lexicon.SearchNeg(text))
            {
                word.tag = Tag.negWord;
            }
            else if (Lexicon.SearchPos(text))
            {
                word.tag = Tag.posWord;
            }
            else
            {
                switch (Lexicon.SearchEmojis(text))
                {
                    case -1:
                        word.tag = Tag.negWord;
                        break;
                    case 1:
                        word.tag = Tag.posWord;
                        break;
                }
            }
            //Need a check here for targets (targets should be based of product type and pulled specs)
            return word;
        }

        static void InvertTag(ref TaggedWord word, ref int posWords, ref int negwords)
        {
            if (word.tag == Tag.posWord)
            {
                posWords--;
                negwords++;
                word.tag = Tag.negWord;
            }
            else if (word.tag == Tag.negWord)
            {
                posWords--;
                negwords++;
                word.tag = Tag.posWord;
            }
        } //Depriciated
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
    enum Tag //Used to tag words inside of a sentence
    { 
        ignore, posWord, negWord, target, negation, contrast, vauge
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
