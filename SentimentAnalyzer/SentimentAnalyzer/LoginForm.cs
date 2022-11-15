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
    public partial class LoginForm : Form
    {
        public bool isGuest;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Client.GuestLogin();
                Close();
            }
            else if (UsernameBox.Text.Length > 0 && PasswordBox.Text.Length > 0)
            {
                if (Client.AttemptLogin(UsernameBox.Text, PasswordBox.Text))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("ERR: Invalid user or pswd");
                    //resultLabel.Text = "ERR: Invalid user or pswd";
                }
            }
        }

        private void createAcctButt_Click(object sender, EventArgs e)
        {
            new SignUpForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ResetPassword().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.Enabled = !checkBox1.Checked;
            UsernameBox.Enabled = !checkBox1.Checked;
            createAcctButt.Enabled = !checkBox1.Checked;

            if (checkBox1.Checked)
            {
                UsernameBox.Text = "Guest";
            }
            else
            {
                UsernameBox.Text = "";

            }
        }
    }
}
