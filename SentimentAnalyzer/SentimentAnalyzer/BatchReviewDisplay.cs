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

            //Check URL is in valid format return if not
            Console.WriteLine(Utilites.CheckValidAmazonURL(url));
            if (!Utilites.CheckValidAmazonURL(url))
            {
                return;
            }
            //Temp storage for results
            int totalRev, posRev, NegRev;
            float avgCon, origRating;
            string asin = Utilites.GetAsinFromURL(url);
            string prodName = Utilites.GetProdNameFromURL(url);
            float modRating;
            HistoryRec rec = new HistoryRec();

            // Try and get rec from server
            if (!Client.offlineMode)
            { 
                rec = Client.RequestHistory(asin);
            }

            if (rec.uID != -1)//if we got a record
            {
                //Get values from record
                totalRev = rec.numRev;
                posRev = rec.numPos;
                NegRev = rec.numRev;
                modRating = rec.adjustedRating;
                avgCon = rec.confidence;
                origRating = rec.orginalRating;

                //try and load cached image if availble.
                try
                {
                    pictureBox1.Image = Image.FromFile(asin + ".jpg");
                }
                catch (Exception)
                {
                    //Set place holder image
                    pictureBox1.Image = Properties.Resources.placeholderProductImage;
                }
            }
            else
            {
                //Get Reviews from scrapper
                List<Review> reviews = ReviewScrapperConnection.GetReviews(url);
                //analyze scrapped reviews to get results
                modRating = Sentiment.BatchAnalyze(reviews, out totalRev, out posRev, out NegRev, out avgCon, out origRating);
                pictureBox1.Image = Image.FromFile("user_img.jpg"); //Load scrapped image

                //if client is online send over results to be cached on server
                if(!Client.offlineMode)
                {
                    rec = new HistoryRec(asin, prodName, totalRev, posRev, NegRev, avgCon, modRating, origRating, Client.currentUser.userID, DateTime.Now);
                    Console.WriteLine("Sending analyzed data to server");
                    Client.SendReviewHistory(rec);
                }
            }

            //Set analyzed values on UI
            productName.Text = prodName;
            modifiedStarRatingRes.Text = string.Format("{0} out of 5 stars", modRating);
            numReviewsRes.Text = totalRev.ToString();
            numPosReviewsRes.Text = posRev.ToString();
            numNegativeReviewRes.Text = NegRev.ToString();
            avgConRes.Text = avgCon.ToString();
            originalStarVal.Text = string.Format("{0} out of 5 stars", origRating);

            //Try and cache image
            try
            {
                System.IO.File.Copy("user_img.jpg", asin + ".jpeg");
            }
            catch
            {
                Console.WriteLine("Error: Image already cached");
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Program.selectionForm.Focus();
            Close();
        }
    }
}
