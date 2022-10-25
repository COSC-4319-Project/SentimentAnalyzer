namespace SentimentAnalyzer
{
    partial class SelectionForm
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
            this.batchButton = new System.Windows.Forms.Button();
            this.singleReviewButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.errorInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // batchButton
            // 
            this.batchButton.Location = new System.Drawing.Point(29, 24);
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(75, 70);
            this.batchButton.TabIndex = 0;
            this.batchButton.Text = "URL";
            this.batchButton.UseVisualStyleBackColor = true;
            this.batchButton.Click += new System.EventHandler(this.batchButton_Click);
            // 
            // singleReviewButton
            // 
            this.singleReviewButton.Location = new System.Drawing.Point(125, 24);
            this.singleReviewButton.Name = "singleReviewButton";
            this.singleReviewButton.Size = new System.Drawing.Size(75, 70);
            this.singleReviewButton.TabIndex = 1;
            this.singleReviewButton.Text = "Single Review";
            this.singleReviewButton.UseVisualStyleBackColor = true;
            this.singleReviewButton.Click += new System.EventHandler(this.singleReviewButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(220, 24);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(75, 70);
            this.historyButton.TabIndex = 2;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // errorInfoLabel
            // 
            this.errorInfoLabel.AutoSize = true;
            this.errorInfoLabel.Location = new System.Drawing.Point(26, 106);
            this.errorInfoLabel.Name = "errorInfoLabel";
            this.errorInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.errorInfoLabel.TabIndex = 3;
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 116);
            this.Controls.Add(this.errorInfoLabel);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.singleReviewButton);
            this.Controls.Add(this.batchButton);
            this.Name = "SelectionForm";
            this.Text = "SelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button batchButton;
        private System.Windows.Forms.Button singleReviewButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Label errorInfoLabel;
    }
}