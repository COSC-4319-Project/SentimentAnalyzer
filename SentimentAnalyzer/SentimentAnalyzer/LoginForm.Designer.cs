namespace SentimentAnalyzer
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createAcctButt = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.guestCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpfulEdvice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.SkyBlue;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginButton.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Black;
            this.loginButton.Location = new System.Drawing.Point(20, 268);
            this.loginButton.Margin = new System.Windows.Forms.Padding(6);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(238, 85);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UsernameBox.Location = new System.Drawing.Point(168, 90);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(6);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(414, 38);
            this.UsernameBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PasswordBox.Location = new System.Drawing.Point(168, 153);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(6);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(414, 38);
            this.PasswordBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Georgia", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.usernameLabel.Location = new System.Drawing.Point(1, 90);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(169, 31);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // createAcctButt
            // 
            this.createAcctButt.BackColor = System.Drawing.Color.SkyBlue;
            this.createAcctButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createAcctButt.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAcctButt.Location = new System.Drawing.Point(20, 390);
            this.createAcctButt.Margin = new System.Windows.Forms.Padding(6);
            this.createAcctButt.Name = "createAcctButt";
            this.createAcctButt.Size = new System.Drawing.Size(238, 77);
            this.createAcctButt.TabIndex = 5;
            this.createAcctButt.Text = "Create Account";
            this.createAcctButt.UseVisualStyleBackColor = false;
            this.createAcctButt.Click += new System.EventHandler(this.createAcctButt_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.ForeColor = System.Drawing.Color.Red;
            this.resultLabel.Location = new System.Drawing.Point(446, 235);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 25);
            this.resultLabel.TabIndex = 6;
            // 
            // guestCheckBox
            // 
            this.guestCheckBox.AutoSize = true;
            this.guestCheckBox.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestCheckBox.Location = new System.Drawing.Point(7, 221);
            this.guestCheckBox.Name = "guestCheckBox";
            this.guestCheckBox.Size = new System.Drawing.Size(445, 29);
            this.guestCheckBox.TabIndex = 7;
            this.guestCheckBox.Text = "Login as guest? (network features disabled)";
            this.guestCheckBox.UseVisualStyleBackColor = true;
            this.guestCheckBox.CheckedChanged += new System.EventHandler(this.guestCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HelpfulEdvice);
            this.panel1.Controls.Add(this.guestCheckBox);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.createAcctButt);
            this.panel1.Controls.Add(this.UsernameBox);
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PasswordBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 658);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(20, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 77);
            this.button1.TabIndex = 9;
            this.button1.Text = "Forgot Password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Forgot something? Don\'t worry, Click here for help!";
            // 
            // HelpfulEdvice
            // 
            this.HelpfulEdvice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HelpfulEdvice.AutoSize = true;
            this.HelpfulEdvice.Font = new System.Drawing.Font("Georgia", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpfulEdvice.Location = new System.Drawing.Point(2, 359);
            this.HelpfulEdvice.Name = "HelpfulEdvice";
            this.HelpfulEdvice.Size = new System.Drawing.Size(538, 25);
            this.HelpfulEdvice.TabIndex = 9;
            this.HelpfulEdvice.Text = "If you do not have an account, SIGN UP TODAY!!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Shrikhand", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(1087, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 77);
            this.label3.TabIndex = 10;
            this.label3.Text = "Welcome To:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SentimentAnalyzer.Properties.Resources.ReReviewLogo_6_1;
            this.pictureBox1.Location = new System.Drawing.Point(591, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1318, 910);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(1499, 658);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LoginForm";
            this.Text = "Re:Review-Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createAcctButt;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.CheckBox guestCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HelpfulEdvice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}