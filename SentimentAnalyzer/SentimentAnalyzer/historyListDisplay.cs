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
    public partial class HistoryListDisplay : Form
    {
        public HistoryRec[] displayedRecords;
        public HistoryListDisplay(HistoryRec[] recs)
        {
            InitializeComponent();
            InitializeColumns();

            displayedRecords = recs;

            foreach (HistoryRec rec in recs)
            {
                ListViewItem item = new ListViewItem(new string[] { rec.prodName, rec.adjustedRating.ToString(), rec.dateAnalyzed.ToString() });
                listView1.Items.Add(item);
            }
        }

        public void InitializeColumns()
        {
            listView1.Columns.Add("Product Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Adjusted Rating", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Date Analyzed", -2, HorizontalAlignment.Left);
            listView1.View = View.Details;
        }
        public HistoryListDisplay()
        {
            InitializeComponent();
            InitializeColumns();

            HistoryRec rec = new HistoryRec();
            rec.prodName = "TEST"; rec.dateAnalyzed = DateTime.Today; rec.adjustedRating = 4.6f;
            ListViewItem item = new ListViewItem(new string[] { rec.prodName, rec.adjustedRating.ToString(), rec.dateAnalyzed.ToString() });
            listView1.Items.Add(item);
        }
        public void GetHistoryItems(int uID)
        {
            listView1.Items.Clear(); //Empty current list
            foreach (HistoryRec rec in Client.GetUserHistory())
            {
                ListViewItem item = new ListViewItem(new string[] { rec.prodName, rec.adjustedRating.ToString(), rec.dateAnalyzed.ToString() });
                listView1.Items.Add(item);
            }
        }
        private void listView1_MouseDoubleClick(object sender, EventArgs e) //Double click on history item to open display window
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            string selName = listView1.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < displayedRecords.Count(); i++)
            {
                if (selName == displayedRecords[i].prodName)
                {
                    ShowDialog(new BatchReviewDisplay(displayedRecords[i]));
                }
            }
        }

        private void HistoryListDisplay_Load(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Program.selectionForm.Focus();
            Close();
        }
    }
}
