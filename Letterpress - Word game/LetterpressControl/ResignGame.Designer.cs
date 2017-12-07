namespace LetterpressControl
{
    partial class ResignGame
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
            this.btnResign = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnResign
            // 
            this.btnResign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnResign.Location = new System.Drawing.Point(120, 67);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(90, 28);
            this.btnResign.TabIndex = 5;
            this.btnResign.Text = "Resign";
            this.btnResign.UseVisualStyleBackColor = true;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNo.Location = new System.Drawing.Point(16, 67);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(90, 28);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Are you sure you want to resign the game?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ResignGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(223, 105);
            this.ControlBox = false;
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.label1);
            this.Name = "ResignGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label label1;
    }
}