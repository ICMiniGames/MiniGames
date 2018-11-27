namespace MiniGames
{
    partial class Morpion
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
            this.cmdCase1 = new System.Windows.Forms.Button();
            this.cmdCase2 = new System.Windows.Forms.Button();
            this.cmdCase3 = new System.Windows.Forms.Button();
            this.cmdCase4 = new System.Windows.Forms.Button();
            this.cmdCase5 = new System.Windows.Forms.Button();
            this.cmdCase6 = new System.Windows.Forms.Button();
            this.cmdCase7 = new System.Windows.Forms.Button();
            this.cmdCase8 = new System.Windows.Forms.Button();
            this.cmdCase9 = new System.Windows.Forms.Button();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCase1
            // 
            this.cmdCase1.Location = new System.Drawing.Point(96, 96);
            this.cmdCase1.Name = "cmdCase1";
            this.cmdCase1.Size = new System.Drawing.Size(64, 64);
            this.cmdCase1.TabIndex = 0;
            this.cmdCase1.UseVisualStyleBackColor = true;
            this.cmdCase1.Click += new System.EventHandler(this.cmdCase1_Click);
            // 
            // cmdCase2
            // 
            this.cmdCase2.Location = new System.Drawing.Point(224, 96);
            this.cmdCase2.Name = "cmdCase2";
            this.cmdCase2.Size = new System.Drawing.Size(64, 64);
            this.cmdCase2.TabIndex = 1;
            this.cmdCase2.UseVisualStyleBackColor = true;
            this.cmdCase2.Click += new System.EventHandler(this.cmdCase2_Click);
            // 
            // cmdCase3
            // 
            this.cmdCase3.Location = new System.Drawing.Point(352, 96);
            this.cmdCase3.Name = "cmdCase3";
            this.cmdCase3.Size = new System.Drawing.Size(64, 64);
            this.cmdCase3.TabIndex = 2;
            this.cmdCase3.UseVisualStyleBackColor = true;
            this.cmdCase3.Click += new System.EventHandler(this.cmdCase3_Click);
            // 
            // cmdCase4
            // 
            this.cmdCase4.Location = new System.Drawing.Point(96, 224);
            this.cmdCase4.Name = "cmdCase4";
            this.cmdCase4.Size = new System.Drawing.Size(64, 64);
            this.cmdCase4.TabIndex = 3;
            this.cmdCase4.UseVisualStyleBackColor = true;
            this.cmdCase4.Click += new System.EventHandler(this.cmdCase4_Click);
            // 
            // cmdCase5
            // 
            this.cmdCase5.Location = new System.Drawing.Point(224, 224);
            this.cmdCase5.Name = "cmdCase5";
            this.cmdCase5.Size = new System.Drawing.Size(64, 64);
            this.cmdCase5.TabIndex = 4;
            this.cmdCase5.UseVisualStyleBackColor = true;
            this.cmdCase5.Click += new System.EventHandler(this.cmdCase5_Click);
            // 
            // cmdCase6
            // 
            this.cmdCase6.Location = new System.Drawing.Point(352, 224);
            this.cmdCase6.Name = "cmdCase6";
            this.cmdCase6.Size = new System.Drawing.Size(64, 64);
            this.cmdCase6.TabIndex = 5;
            this.cmdCase6.UseVisualStyleBackColor = true;
            this.cmdCase6.Click += new System.EventHandler(this.cmdCase6_Click);
            // 
            // cmdCase7
            // 
            this.cmdCase7.Location = new System.Drawing.Point(96, 352);
            this.cmdCase7.Name = "cmdCase7";
            this.cmdCase7.Size = new System.Drawing.Size(64, 64);
            this.cmdCase7.TabIndex = 6;
            this.cmdCase7.UseVisualStyleBackColor = true;
            this.cmdCase7.Click += new System.EventHandler(this.cmdCase7_Click);
            // 
            // cmdCase8
            // 
            this.cmdCase8.Location = new System.Drawing.Point(224, 352);
            this.cmdCase8.Name = "cmdCase8";
            this.cmdCase8.Size = new System.Drawing.Size(64, 64);
            this.cmdCase8.TabIndex = 7;
            this.cmdCase8.UseVisualStyleBackColor = true;
            this.cmdCase8.Click += new System.EventHandler(this.cmdCase8_Click);
            // 
            // cmdCase9
            // 
            this.cmdCase9.Location = new System.Drawing.Point(352, 352);
            this.cmdCase9.Name = "cmdCase9";
            this.cmdCase9.Size = new System.Drawing.Size(64, 64);
            this.cmdCase9.TabIndex = 8;
            this.cmdCase9.UseVisualStyleBackColor = true;
            this.cmdCase9.Click += new System.EventHandler(this.cmdCase9_Click);
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(13, 13);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer1.TabIndex = 9;
            this.lblPlayer1.Text = "Joueur 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(432, 13);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer2.TabIndex = 10;
            this.lblPlayer2.Text = "Joueur 2";
            // 
            // Morpion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 473);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.cmdCase9);
            this.Controls.Add(this.cmdCase8);
            this.Controls.Add(this.cmdCase7);
            this.Controls.Add(this.cmdCase6);
            this.Controls.Add(this.cmdCase5);
            this.Controls.Add(this.cmdCase4);
            this.Controls.Add(this.cmdCase3);
            this.Controls.Add(this.cmdCase2);
            this.Controls.Add(this.cmdCase1);
            this.Name = "Morpion";
            this.Text = "Morpion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCase1;
        private System.Windows.Forms.Button cmdCase2;
        private System.Windows.Forms.Button cmdCase3;
        private System.Windows.Forms.Button cmdCase4;
        private System.Windows.Forms.Button cmdCase5;
        private System.Windows.Forms.Button cmdCase6;
        private System.Windows.Forms.Button cmdCase7;
        private System.Windows.Forms.Button cmdCase8;
        private System.Windows.Forms.Button cmdCase9;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
    }
}