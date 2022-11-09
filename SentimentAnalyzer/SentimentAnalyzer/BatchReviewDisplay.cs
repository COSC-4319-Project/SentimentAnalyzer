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

            //Scrapper Connection here
        }
    }
}
