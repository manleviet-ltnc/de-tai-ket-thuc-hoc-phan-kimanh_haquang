﻿namespace LetterpressControl
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
            this.btnRemoveGame = new System.Windows.Forms.Button();
            this.btnRematch = new System.Windows.Forms.Button();
            this.btnPlayedWords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayedWords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(7, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 36);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemoveGame
            // 
            this.btnRemoveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveGame.Location = new System.Drawing.Point(7, 200);
            this.btnRemoveGame.Name = "btnRemoveGame";
            this.btnRemoveGame.Size = new System.Drawing.Size(240, 36);
            this.btnRemoveGame.TabIndex = 23;
            this.btnRemoveGame.Text = "Remove Game";
            this.btnRemoveGame.UseVisualStyleBackColor = true;
            // 
            // btnRematch
            // 
            this.btnRematch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRematch.Location = new System.Drawing.Point(7, 147);
            this.btnRematch.Name = "btnRematch";
            this.btnRematch.Size = new System.Drawing.Size(240, 36);
            this.btnRematch.TabIndex = 22;
            this.btnRematch.Text = "Rematch";
            this.btnRematch.UseVisualStyleBackColor = true;
            // 
            // btnPlayedWords
            // 
            this.btnPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayedWords.Location = new System.Drawing.Point(7, 94);
            this.btnPlayedWords.Name = "btnPlayedWords";
            this.btnPlayedWords.Size = new System.Drawing.Size(240, 36);
            this.btnPlayedWords.TabIndex = 21;
            this.btnPlayedWords.Text = "Played Words";
            this.btnPlayedWords.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Game over";
            // 
            // txtPlayedWords
            // 
            this.txtPlayedWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayedWords.Location = new System.Drawing.Point(12, 41);
            this.txtPlayedWords.Name = "txtPlayedWords";
            this.txtPlayedWords.Size = new System.Drawing.Size(230, 30);
            this.txtPlayedWords.TabIndex = 25;
            this.txtPlayedWords.Text = "Player  wins ";
            this.txtPlayedWords.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(255, 297);
            this.ControlBox = false;
            this.Controls.Add(this.txtPlayedWords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveGame);
            this.Controls.Add(this.btnRematch);
            this.Controls.Add(this.btnPlayedWords);
            this.Controls.Add(this.label1);
            this.Name = "GameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemoveGame;
        private System.Windows.Forms.Button btnRematch;
        private System.Windows.Forms.Button btnPlayedWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtPlayedWords;
    }
}