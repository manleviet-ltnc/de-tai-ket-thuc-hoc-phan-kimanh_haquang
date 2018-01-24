namespace Letterpress
{
    partial class GameOver
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlayedWords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScored = new System.Windows.Forms.Label();
            this.btnRematch = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(7, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlayedWords
            // 
            this.btnPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayedWords.Location = new System.Drawing.Point(7, 94);
            this.btnPlayedWords.Name = "btnPlayedWords";
            this.btnPlayedWords.Size = new System.Drawing.Size(240, 36);
            this.btnPlayedWords.TabIndex = 2;
            this.btnPlayedWords.Text = "Played Words";
            this.btnPlayedWords.UseVisualStyleBackColor = true;
            this.btnPlayedWords.Click += new System.EventHandler(this.btnPlayedWords_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game over";
            // 
            // lblScored
            // 
            this.lblScored.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScored.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScored.Location = new System.Drawing.Point(12, 41);
            this.lblScored.Name = "lblScored";
            this.lblScored.Size = new System.Drawing.Size(230, 30);
            this.lblScored.TabIndex = 1;
            this.lblScored.Text = "Player  wins ";
            this.lblScored.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRematch
            // 
            this.btnRematch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRematch.Location = new System.Drawing.Point(7, 146);
            this.btnRematch.Name = "btnRematch";
            this.btnRematch.Size = new System.Drawing.Size(240, 36);
            this.btnRematch.TabIndex = 3;
            this.btnRematch.Text = "Rematch";
            this.btnRematch.UseVisualStyleBackColor = true;
            this.btnRematch.Click += new System.EventHandler(this.btnRematch_Click);
            // 
            // btnStats
            // 
            this.btnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.Location = new System.Drawing.Point(7, 198);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(240, 36);
            this.btnStats.TabIndex = 5;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(255, 296);
            this.ControlBox = false;
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.lblScored);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRematch);
            this.Controls.Add(this.btnPlayedWords);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(271, 312);
            this.MinimumSize = new System.Drawing.Size(271, 312);
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPlayedWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScored;
        private System.Windows.Forms.Button btnRematch;
        private System.Windows.Forms.Button btnStats;
    }
}