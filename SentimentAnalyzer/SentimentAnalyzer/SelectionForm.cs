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
    public partial class SelectionForm : Form
    {
        //Forms
        Form1 form1 = new Form1();
        BatchReviewDisplay reviewDisplay = new BatchReviewDisplay();

        public SelectionForm()
        {
            InitializeComponent();
        }

        private void singleReviewButton_Click(object sender, EventArgs e)
        {
            reviewDisplay.ShowDialog();
        }

        private void batchButton_Click(object sender, EventArgs e)
        {
            form1.ShowDialog();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            //Show History UI
        }
    }
}
