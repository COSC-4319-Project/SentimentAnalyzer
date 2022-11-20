
namespace SentimentAnalyzer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ReviewInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confidenceResult = new System.Windows.Forms.Label();
            this.negWordCount = new System.Windows.Forms.Label();
            this.posWordCount = new System.Windows.Forms.Label();
            this.neutralWordCount = new System.Windows.Forms.Label();
            this.wordCountRes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultsText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HomeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReviewInputBox
            // 
            this.ReviewInputBox.Location = new System.Drawing.Point(374, 108);
            this.ReviewInputBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ReviewInputBox.Multiline = true;
            this.ReviewInputBox.Name = "ReviewInputBox";
            this.ReviewInputBox.Size = new System.Drawing.Size(716, 548);
            this.ReviewInputBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a Review:";
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.BackColor = System.Drawing.Color.SkyBlue;
            this.AnalyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnalyzeButton.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzeButton.Location = new System.Drawing.Point(898, 671);
            this.AnalyzeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(196, 60);
            this.AnalyzeButton.TabIndex = 2;
            this.AnalyzeButton.Text = "Analyze";
            this.AnalyzeButton.UseVisualStyleBackColor = false;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.confidenceResult);
            this.groupBox1.Controls.Add(this.negWordCount);
            this.groupBox1.Controls.Add(this.posWordCount);
            this.groupBox1.Controls.Add(this.neutralWordCount);
            this.groupBox1.Controls.Add(this.wordCountRes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ResultsText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1120, 108);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(670, 552);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Review Results:";
            // 
            // confidenceResult
            // 
            this.confidenceResult.AutoSize = true;
            this.confidenceResult.Location = new System.Drawing.Point(266, 242);
            this.confidenceResult.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.confidenceResult.Name = "confidenceResult";
            this.confidenceResult.Size = new System.Drawing.Size(0, 31);
            this.confidenceResult.TabIndex = 13;
            // 
            // negWordCount
            // 
            this.negWordCount.AutoSize = true;
            this.negWordCount.Location = new System.Drawing.Point(266, 152);
            this.negWordCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.negWordCount.Name = "negWordCount";
            this.negWordCount.Size = new System.Drawing.Size(0, 31);
            this.negWordCount.TabIndex = 11;
            // 
            // posWordCount
            // 
            this.posWordCount.AutoSize = true;
            this.posWordCount.Location = new System.Drawing.Point(266, 113);
            this.posWordCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.posWordCount.Name = "posWordCount";
            this.posWordCount.Size = new System.Drawing.Size(0, 31);
            this.posWordCount.TabIndex = 10;
            // 
            // neutralWordCount
            // 
            this.neutralWordCount.AutoSize = true;
            this.neutralWordCount.Location = new System.Drawing.Point(266, 196);
            this.neutralWordCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.neutralWordCount.Name = "neutralWordCount";
            this.neutralWordCount.Size = new System.Drawing.Size(0, 31);
            this.neutralWordCount.TabIndex = 9;
            // 
            // wordCountRes
            // 
            this.wordCountRes.AutoSize = true;
            this.wordCountRes.Location = new System.Drawing.Point(266, 75);
            this.wordCountRes.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.wordCountRes.Name = "wordCountRes";
            this.wordCountRes.Size = new System.Drawing.Size(0, 31);
            this.wordCountRes.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 31);
            this.label8.TabIndex = 7;
            this.label8.Text = "Confidence:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Neutral Words:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Neg Words:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pos Words:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Words:";
            // 
            // ResultsText
            // 
            this.ResultsText.AutoSize = true;
            this.ResultsText.Location = new System.Drawing.Point(266, 37);
            this.ResultsText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ResultsText.Name = "ResultsText";
            this.ResultsText.Size = new System.Drawing.Size(0, 31);
            this.ResultsText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sentiment:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.HomeButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 817);
            this.panel1.TabIndex = 4;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.SkyBlue;
            this.HomeButton.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.Image = global::SentimentAnalyzer.Properties.Resources._126572_home_house_icon;
            this.HomeButton.Location = new System.Drawing.Point(12, 252);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(268, 104);
            this.HomeButton.TabIndex = 6;
            this.HomeButton.Text = "   Home";
            this.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SentimentAnalyzer.Properties.Resources.ReReviewLogo_6_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 231);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1852, 817);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReviewInputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Re:Review-Custom Input";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReviewInputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ResultsText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label confidenceResult;
        private System.Windows.Forms.Label negWordCount;
        private System.Windows.Forms.Label posWordCount;
        private System.Windows.Forms.Label neutralWordCount;
        private System.Windows.Forms.Label wordCountRes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

