namespace Letterpress
{
    partial class NewGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pbxNewGame = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pnlNewGame = new System.Windows.Forms.Panel();
            this.btnStats = new System.Windows.Forms.Button();
            this.grpContinue = new System.Windows.Forms.GroupBox();
            this.lstContinue = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewGame)).BeginInit();
            this.pnlNewGame.SuspendLayout();
            this.grpContinue.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "More-icon.jpg");
            // 
            // pbxNewGame
            // 
            this.pbxNewGame.Image = ((System.Drawing.Image)(resources.GetObject("pbxNewGame.Image")));
            this.pbxNewGame.Location = new System.Drawing.Point(0, 0);
            this.pbxNewGame.Name = "pbxNewGame";
            this.pbxNewGame.Size = new System.Drawing.Size(90, 90);
            this.pbxNewGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNewGame.TabIndex = 2;
            this.pbxNewGame.TabStop = false;
            this.pbxNewGame.Click += new System.EventHandler(this.Control_Click);
            this.pbxNewGame.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.pbxNewGame.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(96, 27);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(116, 38);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.Control_Click);
            this.btnNewGame.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.btnNewGame.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // pnlNewGame
            // 
            this.pnlNewGame.Controls.Add(this.btnNewGame);
            this.pnlNewGame.Controls.Add(this.pbxNewGame);
            this.pnlNewGame.Location = new System.Drawing.Point(0, 36);
            this.pnlNewGame.Name = "pnlNewGame";
            this.pnlNewGame.Size = new System.Drawing.Size(290, 90);
            this.pnlNewGame.TabIndex = 0;
            this.pnlNewGame.Click += new System.EventHandler(this.Control_Click);
            this.pnlNewGame.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.pnlNewGame.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnStats
            // 
            this.btnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.Location = new System.Drawing.Point(-1, -1);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(50, 24);
            this.btnStats.TabIndex = 5;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // grpContinue
            // 
            this.grpContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpContinue.Controls.Add(this.lstContinue);
            this.grpContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpContinue.Location = new System.Drawing.Point(5, 136);
            this.grpContinue.Name = "grpContinue";
            this.grpContinue.Size = new System.Drawing.Size(280, 263);
            this.grpContinue.TabIndex = 4;
            this.grpContinue.TabStop = false;
            this.grpContinue.Text = "Continue";
            // 
            // lstContinue
            // 
            this.lstContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContinue.FormattingEnabled = true;
            this.lstContinue.ItemHeight = 20;
            this.lstContinue.Location = new System.Drawing.Point(7, 29);
            this.lstContinue.Name = "lstContinue";
            this.lstContinue.Size = new System.Drawing.Size(267, 224);
            this.lstContinue.TabIndex = 0;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(290, 404);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.pnlNewGame);
            this.Controls.Add(this.grpContinue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(306, 443);
            this.MinimumSize = new System.Drawing.Size(306, 443);
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Letterpress";
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewGame)).EndInit();
            this.pnlNewGame.ResumeLayout(false);
            this.grpContinue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pbxNewGame;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel pnlNewGame;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.GroupBox grpContinue;
        private System.Windows.Forms.ListBox lstContinue;
    }
}