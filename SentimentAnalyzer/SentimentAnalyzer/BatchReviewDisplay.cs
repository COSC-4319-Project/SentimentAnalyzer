using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentimentAnalyzer
{
    public partial class BatchReviewDisplay : Form
    {
        public BatchReviewDisplay()
        {
            InitializeComponent();
        }

        public BatchReviewDisplay(HistoryRec rec)
        {
            InitializeComponent();
            
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text; //URL from input box
            Console.WriteLine(Utilites.CheckValidAmazonURL(url));
            if (!Utilites.CheckValidAmazonURL(url))
            {
                return;
            }

            List<Review> reviews = ReviewScrapperConnection.GetReviews(url);

            int totalRev, posRev, NegRev;
            float avgCon, origRating;
            float modRating = Sentiment.BatchAnalyze(reviews, out totalRev, out posRev, out NegRev, out avgCon, out origRating);

            productName.Text = Utilites.GetProdNameFromURL(url);
            pictureBox1.Image = Image.FromFile("user_img.jpg");
            modifiedStarRatingRes.Text = string.Format("{0} out of 5 stars", modRating);
            numReviewsRes.Text = totalRev.ToString();
            numPosReviewsRes.Text = posRev.ToString();
            numNegativeReviewRes.Text = NegRev.ToString();
            avgConRes.Text = avgCon.ToString();
            originalStarVal.Text = string.Format("{0} out of 5 stars", origRating);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Program.selectionForm.Focus();
            Close();
        }
    }
}
