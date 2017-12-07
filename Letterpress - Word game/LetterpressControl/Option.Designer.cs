namespace LetterpressControl
{
    partial class Option
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Option));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnResignGame = new System.Windows.Forms.Button();
            this.btnPlayedWords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(12, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 36);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnResignGame
            // 
            this.btnResignGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResignGame.Location = new System.Drawing.Point(12, 148);
            this.btnResignGame.Name = "btnResignGame";
            this.btnResignGame.Size = new System.Drawing.Size(240, 36);
            this.btnResignGame.TabIndex = 17;
            this.btnResignGame.Text = "Resign Game";
            this.btnResignGame.UseVisualStyleBackColor = true;
            this.btnResignGame.Click += new System.EventHandler(this.btnResignGame_Click);
            // 
            // btnPlayedWords
            // 
            this.btnPlayedWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayedWords.Location = new System.Drawing.Point(12, 42);
            this.btnPlayedWords.Name = "btnPlayedWords";
            this.btnPlayedWords.Size = new System.Drawing.Size(240, 36);
            this.btnPlayedWords.TabIndex = 15;
            this.btnPlayedWords.Text = "Played Words";
            this.btnPlayedWords.UseVisualStyleBackColor = true;
            this.btnPlayedWords.Click += new System.EventHandler(this.btnPlayedWords_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Your turn";
            // 
            // btnNewBoard
            // 
            this.btnNewBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBoard.Location = new System.Drawing.Point(12, 95);
            this.btnNewBoard.Name = "btnNewBoard";
            this.btnNewBoard.Size = new System.Drawing.Size(240, 36);
            this.btnNewBoard.TabIndex = 16;
            this.btnNewBoard.Text = "New Board";
            this.btnNewBoard.UseVisualStyleBackColor = true;
            this.btnNewBoard.Click += new System.EventHandler(this.btnNewBoard_Click);
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(265, 250);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnResignGame);
            this.Controls.Add(this.btnNewBoard);
            this.Controls.Add(this.btnPlayedWords);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(271, 256);
            this.MinimumSize = new System.Drawing.Size(271, 256);
            this.Name = "Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResignGame;
        private System.Windows.Forms.Button btnPlayedWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewBoard;
    }
}

