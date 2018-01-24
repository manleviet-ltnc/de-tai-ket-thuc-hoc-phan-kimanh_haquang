namespace LetterpressControl
{
    partial class PlayedWords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayedWords));
            this.lblTotalPlayedWords = new System.Windows.Forms.Label();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lblPlayedWords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalPlayedWords
            // 
            this.lblTotalPlayedWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPlayedWords.AutoSize = true;
            this.lblTotalPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPlayedWords.Location = new System.Drawing.Point(52, 13);
            this.lblTotalPlayedWords.Name = "lblTotalPlayedWords";
            this.lblTotalPlayedWords.Size = new System.Drawing.Size(151, 25);
            this.lblTotalPlayedWords.TabIndex = 0;
            this.lblTotalPlayedWords.Text = "0 Played Words";
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkay.Location = new System.Drawing.Point(12, 213);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(230, 36);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lblPlayedWords
            // 
            this.lblPlayedWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayedWords.Location = new System.Drawing.Point(4, 48);
            this.lblPlayedWords.Name = "lblPlayedWords";
            this.lblPlayedWords.Size = new System.Drawing.Size(245, 151);
            this.lblPlayedWords.TabIndex = 2;
            this.lblPlayedWords.Text = "Tap any word for a definition from Merriam - Webster Dictionary.";
            this.lblPlayedWords.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PlayedWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(254, 261);
            this.ControlBox = false;
            this.Controls.Add(this.lblPlayedWords);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.lblTotalPlayedWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(270, 277);
            this.MinimumSize = new System.Drawing.Size(270, 277);
            this.Name = "PlayedWords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PlayedWords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalPlayedWords;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label lblPlayedWords;
    }
}