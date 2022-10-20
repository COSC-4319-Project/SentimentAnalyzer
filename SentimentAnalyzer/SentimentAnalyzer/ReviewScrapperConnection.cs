using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

//Using Newtonsoft Json.NET for json parsing

namespace SentimentAnalyzer
{
    class ReviewScrapperConnection
    {
        public static List<Review> reviews;
        public static void LoadReviews(string jsonFileLoc)
        {
            string json = File.ReadAllText(jsonFileLoc);
            reviews = JsonConvert.DeserializeObject<List<Review>>(json);
        }
    }

    class Review
    {
        public string title;
        public string body;
        public byte rating;

        public void ParseRating(string rating)
        {
            byte.TryParse(rating.Split(' ')[0], out this.rating);
        }
    }
}
