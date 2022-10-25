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
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void singleReviewButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Run(new Form1());
        }

        private void batchButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Run(new BatchReviewDisplay());
        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
