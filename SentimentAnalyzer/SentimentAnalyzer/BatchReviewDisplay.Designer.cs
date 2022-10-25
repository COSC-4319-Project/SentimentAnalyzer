namespace SentimentAnalyzer
{
    partial class BatchReviewDisplay
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modifiedStarRatingRes = new System.Windows.Forms.Label();
            this.avgConRes = new System.Windows.Forms.Label();
            this.numNegativeReviewRes = new System.Windows.Forms.Label();
            this.numPosReviewsRes = new System.Windows.Forms.Label();
            this.numReviewsRes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.productName = new System.Windows.Forms.Label();
            this.originalStarVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SentimentAnalyzer.Properties.Resources.placeholderProductImage;
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modifiedStarRatingRes);
            this.groupBox1.Controls.Add(this.avgConRes);
            this.groupBox1.Controls.Add(this.numNegativeReviewRes);
            this.groupBox1.Controls.Add(this.numPosReviewsRes);
            this.groupBox1.Controls.Add(this.numReviewsRes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(263, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 282);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analysis Results";
            // 
            // modifiedStarRatingRes
            // 
            this.modifiedStarRatingRes.AutoSize = true;
            this.modifiedStarRatingRes.Location = new System.Drawing.Point(109, 110);
            this.modifiedStarRatingRes.Name = "modifiedStarRatingRes";
            this.modifiedStarRatingRes.Size = new System.Drawing.Size(13, 13);
            this.modifiedStarRatingRes.TabIndex = 13;
            this.modifiedStarRatingRes.Text = "0";
            // 
            // avgConRes
            // 
            this.avgConRes.AutoSize = true;
            this.avgConRes.Location = new System.Drawing.Point(109, 87);
            this.avgConRes.Name = "avgConRes";
            this.avgConRes.Size = new System.Drawing.Size(13, 13);
            this.avgConRes.TabIndex = 12;
            this.avgConRes.Text = "0";
            // 
            // numNegativeReviewRes
            // 
            this.numNegativeReviewRes.AutoSize = true;
            this.numNegativeReviewRes.Location = new System.Drawing.Point(109, 65);
            this.numNegativeReviewRes.Name = "numNegativeReviewRes";
            this.numNegativeReviewRes.Size = new System.Drawing.Size(13, 13);
            this.numNegativeReviewRes.TabIndex = 11;
            this.numNegativeReviewRes.Text = "0";
            // 
            // numPosReviewsRes
            // 
            this.numPosReviewsRes.AutoSize = true;
            this.numPosReviewsRes.Location = new System.Drawing.Point(109, 43);
            this.numPosReviewsRes.Name = "numPosReviewsRes";
            this.numPosReviewsRes.Size = new System.Drawing.Size(13, 13);
            this.numPosReviewsRes.TabIndex = 10;
            this.numPosReviewsRes.Text = "0";
            // 
            // numReviewsRes
            // 
            this.numReviewsRes.AutoSize = true;
            this.numReviewsRes.Location = new System.Drawing.Point(109, 21);
            this.numReviewsRes.Name = "numReviewsRes";
            this.numReviewsRes.Size = new System.Drawing.Size(13, 13);
            this.numReviewsRes.TabIndex = 9;
            this.numReviewsRes.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Modified Star Rating:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Avg. Confidence:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Negative Reviews:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Positive Reviews:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reviews Analyzed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.productName);
            this.groupBox2.Controls.Add(this.originalStarVal);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 282);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Info";
            // 
            // productName
            // 
            this.productName.AutoSize = true;
            this.productName.Location = new System.Drawing.Point(11, 196);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(75, 13);
            this.productName.TabIndex = 3;
            this.productName.Text = "Product Name";
            // 
            // originalStarVal
            // 
            this.originalStarVal.AutoSize = true;
            this.originalStarVal.Location = new System.Drawing.Point(11, 221);
            this.originalStarVal.Name = "originalStarVal";
            this.originalStarVal.Size = new System.Drawing.Size(77, 13);
            this.originalStarVal.TabIndex = 2;
            this.originalStarVal.Text = "0 out of 5 stars";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Enter an Amazon product URL:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 20);
            this.textBox1.TabIndex = 5;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(453, 42);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(75, 23);
            this.analyzeButton.TabIndex = 6;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            // 
            // BatchReviewDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 359);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BatchReviewDisplay";
            this.Text = "BatchReviewDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label originalStarVal;
        private System.Windows.Forms.Label modifiedStarRatingRes;
        private System.Windows.Forms.Label avgConRes;
        private System.Windows.Forms.Label numNegativeReviewRes;
        private System.Windows.Forms.Label numPosReviewsRes;
        private System.Windows.Forms.Label numReviewsRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button analyzeButton;
    }
}