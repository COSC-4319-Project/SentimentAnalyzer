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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
            this.errorInfoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.batchButton = new System.Windows.Forms.Button();
            this.singleReviewButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorInfoLabel
            // 
            this.errorInfoLabel.AutoSize = true;
            this.errorInfoLabel.Location = new System.Drawing.Point(52, 204);
            this.errorInfoLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.errorInfoLabel.Name = "errorInfoLabel";
            this.errorInfoLabel.Size = new System.Drawing.Size(0, 25);
            this.errorInfoLabel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.batchButton);
            this.panel1.Controls.Add(this.singleReviewButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 888);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SentimentAnalyzer.Properties.Resources.ReReviewLogo_6_1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 223);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // batchButton
            // 
            this.batchButton.BackColor = System.Drawing.Color.SkyBlue;
            this.batchButton.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchButton.Image = global::SentimentAnalyzer.Properties.Resources._126577_search_find_icon;
            this.batchButton.Location = new System.Drawing.Point(6, 246);
            this.batchButton.Margin = new System.Windows.Forms.Padding(6);
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(342, 135);
            this.batchButton.TabIndex = 0;
            this.batchButton.Text = "   Amazon Review";
            this.batchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.batchButton.UseVisualStyleBackColor = false;
            this.batchButton.Click += new System.EventHandler(this.batchButton_Click);
            // 
            // singleReviewButton
            // 
            this.singleReviewButton.BackColor = System.Drawing.Color.SkyBlue;
            this.singleReviewButton.Font = new System.Drawing.Font("Georgia", 10.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleReviewButton.Image = global::SentimentAnalyzer.Properties.Resources._126582_edit_pencil_write_icon;
            this.singleReviewButton.Location = new System.Drawing.Point(6, 404);
            this.singleReviewButton.Margin = new System.Windows.Forms.Padding(6);
            this.singleReviewButton.Name = "singleReviewButton";
            this.singleReviewButton.Size = new System.Drawing.Size(342, 135);
            this.singleReviewButton.TabIndex = 1;
            this.singleReviewButton.Text = "   Custom Review";
            this.singleReviewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.singleReviewButton.UseVisualStyleBackColor = false;
            this.singleReviewButton.Click += new System.EventHandler(this.singleReviewButton_Click);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1554, 888);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.errorInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SelectionForm";
            this.Text = "Re:Review-Home";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button batchButton;
        private System.Windows.Forms.Button singleReviewButton;
        private System.Windows.Forms.Label errorInfoLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}