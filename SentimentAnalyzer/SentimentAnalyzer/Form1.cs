//Tilly Dewing Fall 2022
//Software Engineering 4319

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            int wordCount;
            float confidence, negPerc, neuPerc, posPerc;

            int x = Sentiment.Analyze(ReviewInputBox.Text, out negPerc, out neuPerc, out posPerc, out wordCount, out confidence);

            string text = "";
            switch (x)
            {
                case -1:
                    text = "Negative";
                    break;
                case 0:
                    text = "Neutral";
                    break;
                case 1:
                    text = "Positive";
                    break;
            }
            ResultsText.Text = text;

            negWordCount.Text = String.Format("Value: {0:P2}.", negPerc);
            posWordCount.Text = String.Format("Value: {0:P2}.", posPerc);
            neutralWordCount.Text = String.Format("Value: {0:P2}.", neuPerc);
            wordCountRes.Text = wordCount.ToString();

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Program.selectionForm.Focus();
            Close();
        }
    }
}
