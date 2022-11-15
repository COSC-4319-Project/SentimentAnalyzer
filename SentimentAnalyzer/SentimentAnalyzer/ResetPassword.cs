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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void tokenRequestButton_Click(object sender, EventArgs e)
        {
            if (!Utilites.ValidateUsername.IsMatch(userNameBox1.Text))
            {
                MessageBox.Show("Please enter a valid Username");
                return;
            }
            if (!Utilites.ValidateEmail.IsMatch(emailBox.Text))
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }

            if (Client.RequestPasswordToken(userNameBox1.Text))
            {
                MessageBox.Show("Token sent to email (check junk if you cannot find message)");
                usernameBox2.Text = userNameBox1.Text;
                ActiveControl = tokenBox;
            }
            else
            {
                MessageBox.Show("Invalid Username or Email");
            }
        }

        private void resetPassButton_Click(object sender, EventArgs e)
        {

            if (!Utilites.ValidateUsername.IsMatch(usernameBox2.Text))
            {
                MessageBox.Show("Please enter a valid Username");
                return;
            }
            if (!Utilites.ValidatePassword.IsMatch(newPasswordBox.Text))
            {
                MessageBox.Show("Password must be 8 characters long, contain an upper and lowercase letter, a number, and a symbol (#?!@$%^&*-).");
                return;
            }

            if (Client.ResetPasssword(usernameBox2.Text, tokenBox.Text, newPasswordBox.Text))
            {
                MessageBox.Show("Password sucesfully reset");
                Close();
            }
            else
            {
                MessageBox.Show("Invalid token");
            }
        }
    }
}
