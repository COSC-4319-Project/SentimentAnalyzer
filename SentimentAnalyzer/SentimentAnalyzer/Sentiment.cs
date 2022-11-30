//Tilly Dewing Fall 2022
//Software Engineering 4319
//Based of research and lexicon by Hu and Liu, KDD-2004, https://www.cs.uic.edu/~liub/FBS/sentiment-analysis.html

using System.Collections.Generic;

namespace SentimentAnalyzer
{
    class Sentiment //Used to try and determine the sentiment of a piece of english text
    {
        public static char[] delemiterCharsSents = {'.','?','!'}; //Used to split senteces (Ending puntuation)
        public static char[] delemiterCharsWords = { ' ', ',', ';'}; //Used to remove puntuation from the end of words

        public static float BatchAnalyze(List<Review> reviews, out int totalParagraphs, out int posParagraphs, out int negParagraphs, out float avgConfidence, out float origRating)
        {
            totalParagraphs = 0;
            posParagraphs = 0;
            negParagraphs = 0;
            avgConfidence = 0;
            origRating = 0;

            foreach (Review review in reviews)
            {
                string paragraph = review.title + " " + review.body;
                float confidence;

                origRating += review.ParseRating();
                
                totalParagraphs++;
                int tempVal = Analyze(paragraph, out confidence);
                if (tempVal == -1)
                {
                    negParagraphs++;
                }
                else if (tempVal == 1)
                {
                    posParagraphs++;
                }

                avgConfidence += confidence;
            }
            //Compute confidence and ratings
            avgConfidence = avgConfidence / (float)totalParagraphs;
            origRating = origRating / (float)totalParagraphs;
            //Return modified ratings
            return ((float)posParagraphs/(float)totalParagraphs * 5);
            
        }
        
        //Analyze a piece of text and out intermediate calculations
        public static int Analyze(string text, out float negPerc, out float neuPerc, out float posPerc, out int wordCount, out float confidence) //Entry point for sentiment class
        {
            Paragraph paragraph = Tokenize(text); //Tag words
            //Compute percentages;
            negPerc = (float)paragraph.negWords / (float)paragraph.wordCount;
            posPerc = (float)paragraph.posWords / (float)paragraph.wordCount;
            neuPerc = ((float)paragraph.wordCount - (float)paragraph.negWords - (float)paragraph.posWords) / (float)paragraph.wordCount;
            //Grab word count for output;
            wordCount = paragraph.wordCount;
            //Compute confidence level
            confidence = (float)(paragraph.posWords + paragraph.negWords) * 7 / (float)paragraph.wordCount;
            confidence = Utilites.Clamp(confidence, 0, 1); //Curtail overconfidence 

            //Return sentiment value
            if (negPerc > posPerc)
            {
                return -1; //Negative
            }
            else if (negPerc < posPerc)
            {
                return 1; //Positive
            }
            return 0;  //Neutral
        }

        public static int Analyze(string text, out float confidence) //Calls analyze without additonal info
        {
            int count;
            float X, Y, Z = 0;
            return Analyze(text, out X, out Y, out Z, out count, out confidence);
        }

        //Idea is to break the sentence up into analyzable tagged chunks
        static Paragraph Tokenize(string text) //Build paragraph data structure from review text
        {
            text = text.ToLower(); //Set string data to lower case to match lexicons
            Paragraph paragraph = new Paragraph(); //Create new paragraph.
            paragraph.sentences = new List<Sentence>(); //Assign sentence list

            foreach (string sent in text.Split(delemiterCharsSents)) //Split sentences
            {
                Sentence sentence = new Sentence(); //assign sentence list
                sentence.words = new List<TaggedWord>(); //assign tagged word list
                bool negate = false; //flag to swap rest of sentence.
                int weight = 1; //weight of words in sentence
                Tag lastTag = Tag.ignore; //Last used sentiment tag of sentence for vauge words.(only positive or negative)

                foreach (string word in sent.Split(delemiterCharsWords))//Split words
                {
                    if(word.Length <= 1) //Discard empty words
                    {
                        continue; //Skip to next item
                    }

                    TaggedWord aWord = TagWord(word);//Get tag for word
                    paragraph.wordCount++; //Increment word count

                    //Based on sentiment update sentence and paragraph values
                    if (negate)
                    {
                        //negsteps--;
                        aWord.tag = InvertTag(aWord.tag);
                    }
                    if (aWord.tag == Tag.negation) //set flag to negate proceding words 
                    {
                        negate = true;
                    }
                    else if (aWord.tag == Tag.contrast) //Contrast words doubles weight
                    {
                        weight = 2;
                    }
                    else if (aWord.tag == Tag.negWord) //Negative word
                    {
                        paragraph.negWords = paragraph.negWords + weight;
                        lastTag = Tag.negWord;
                    }
                    else if (aWord.tag == Tag.posWord) //Positive Word
                    {
                        paragraph.posWords = paragraph.posWords + weight;
                        lastTag = Tag.posWord;
                    }
                    else if (aWord.tag == Tag.vauge)
                    {
                        if (lastTag != Tag.ignore) //Vauge words take on preceding sentiment
                        {
                            paragraph.wordCount++;//Weight vauge words at half of weight of normal words
                            if (lastTag == Tag.posWord) //Take preceding sentiment
                            {
                                paragraph.posWords++;
                            }
                            else
                            {
                                paragraph.negWords++;
                            }
                        }
                    }

                    if (weight > 1 && lastTag != Tag.ignore) //if we hit a contrast word and have proceding sentiment.
                    {
                        if (aWord.tag == Tag.posWord || aWord.tag == Tag.negWord) //Sentiment words should take oposite of proceding sentiment after contrast.
                        {
                            aWord.tag = InvertTag(lastTag);
                        }
                    }

                    sentence.words.Add(aWord); //add new word
                    //Console.WriteLine(aWord);//Debuging purposes
                }
                paragraph.sentences.Add(sentence); //Add sentence to paragraph
            }

            return paragraph; //return built paragraph
        }

        static TaggedWord TagWord(string text) //Tags a word based of Lexicons
        {
            TaggedWord word = new TaggedWord();
            word.word = text;
            //Search lexicons for a match.
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

            if (word.tag == Tag.ignore)//Finally check to parse unrecognized strings of emojiis
            {
                word = TryParseEmojiiString(text);
            }

            //Need a check here for targets (targets should be based of product type and pulled specs)
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

        static TaggedWord TryParseEmojiiString(string text) //Fall back emoji parsing for strings of emojies
        {
            TaggedWord word = new TaggedWord();
            word.word = text;

            foreach (char character in text)
            {
                switch (Lexicon.SearchEmojis(character.ToString()))
                {
                    case -1:
                        word.tag = Tag.negWord;
                        break;
                    case 1:
                        word.tag = Tag.posWord;
                        break;
                }
            }

            return word;
        }
    }

    //Sentiment Data Structure
    enum Tag //Used to tag words inside of a sentence
    { 
        ignore, posWord, negWord, target, negation, contrast, vauge
    }

    struct TaggedWord //Lowest level of paragraph structure consists of a word and a Tag
    {
        public string word;
        public Tag tag;

        public override string ToString()
        {
            return word + " : " + tag;
        }
    }

    struct Sentence //Sentence is a list of Tagged words
    {
        public List<TaggedWord> words;
    }

    struct Paragraph //Paragraph is a list of sentences with word counts
    {
        public List<Sentence> sentences;
        public int wordCount;
        public int posWords;
        public int negWords;
    }
}
