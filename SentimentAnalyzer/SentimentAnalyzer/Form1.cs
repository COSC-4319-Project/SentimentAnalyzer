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
            DateTime startTime = DateTime.Now;
            int x = Sentiment.Analyze(ReviewInputBox.Text);
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
            Console.WriteLine("Analysis complete took: " + (startTime - DateTime.Now));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectionForm.ShowDialog();
        }
    }
}
