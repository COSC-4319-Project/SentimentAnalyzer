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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (!Utilites.ValidateUsername.IsMatch(usernameBox.Text))
            {
                MessageBox.Show("Username must only consist of upper and lower case alpha-numeric characters");
                return;
            }
            if (!Utilites.ValidatePassword.IsMatch(passwordBox.Text))
            {
                MessageBox.Show("Password must be 8 characters long, contain an upper and lowercase letter, a number, and a symbol (#?!@$%^&*-).");
                return;
            }

            if (Client.CreateAccount(usernameBox.Text, passwordBox.Text, emailBox.Text))
            {
                MessageBox.Show("Account created sucsusfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Username already in use");
            }
        }
    }
}
