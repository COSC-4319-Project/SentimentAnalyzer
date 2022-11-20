﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

//Using Newtonsoft Json.NET for json parsing

namespace SentimentAnalyzer
{
    class ReviewScrapperConnection
    {
        //static List<Review> reviews;
        private static List<Review> LoadReviewsFromJSON(string asin)
        {
            List<Review> reviews = new List<Review>();

            string json = File.ReadAllText(asin + "-reviews.json");

            char[] delimeters = { '{', '}' };

            string[] split = json.Split(delimeters);

            //Every other line is garbage so increment by 2
            for (int i = 1; i < split.Length; i += 2)
            {
                //Console.WriteLine(split[i]);
                string[] rec = split[i].Split('"');
                if (rec.Length >= 13)
                {
                    //Console.WriteLine("REC LENGTH : " + rec.Length);
                    reviews.Add(new Review(rec[5], rec[7], rec[11]));
                }
            }

            return reviews;
        }

        public static List<Review> GetReviews(string url)
        {
            CallScrapper(url);
            string asin = Utilites.GetAsinFromURL(url);
            Console.WriteLine(asin);
            return LoadReviewsFromJSON(asin);
        }

        private static void CallScrapper(string url)
        {
            File.WriteAllText("user_url.txt", url);

            // full path of python interpreter 
            string python =  GetPythonPath() + @"\Python311\python.exe";
            Console.WriteLine(python);
            // python app to call 
            string myPythonApp = "amazon.py";

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = true;
            //myProcessStartInfo.RedirectStandardOutput = true;
            
            // start python app with a argument pointing to itself 
            myProcessStartInfo.Arguments = myPythonApp;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;
            Console.WriteLine(myProcess.StartInfo.FileName);
            Console.WriteLine(myProcess.StartInfo.WorkingDirectory);
            //Console.WriteLine("Calling Python script with arguments {0} and {1}", x, y);
            // start the process
           
            myProcess.Start();

            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            myProcess.Close();

            // write the output we got from python app 
            //Console.WriteLine("Value received from script: " + myString);
        }

        public static string GetPythonPath()
        {
            var entries = Environment.GetEnvironmentVariable("path").Split(';');
            string python_location = null;

            foreach (string entry in entries)
            {
                if (entry.ToLower().Contains("python"))
                {
                    var breadcrumbs = entry.Split('\\');
                    foreach (string breadcrumb in breadcrumbs)
                    {
                        if (breadcrumb.ToLower().Contains("python"))
                        {
                            python_location += breadcrumb + '\\';
                            break;
                        }
                        python_location += breadcrumb + '\\';
                    }
                    break;
                }
            }

            return python_location;
        }
    }
    public class Review
    {
        public string title;
        public string rating;
        public string body;

        public Review(string title, string rating, string body)
        {
            this.title = title;
            this.body = body;
            this.rating = rating;
        }

        public override string ToString()
        {
            return string.Format("Title: {0} Rating: {1} Body: {2}", title, rating, body);
        }
        public float ParseRating()
        {
            float rate = 0;
            float.TryParse(rating.Split(' ')[0], out rate);
            return rate;
        }
    }
}
