namespace MiniGames
{
    partial class Bataille
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
            this.txtBot1 = new System.Windows.Forms.TextBox();
            this.txtBot2 = new System.Windows.Forms.TextBox();
            this.pcbBot2 = new System.Windows.Forms.PictureBox();
            this.pcbBot1 = new System.Windows.Forms.PictureBox();
            this.lblWinner = new System.Windows.Forms.Label();
            this.lblPlayerChoice2 = new System.Windows.Forms.Label();
            this.lblPlayerChoice1 = new System.Windows.Forms.Label();
            this.lblPlayerChoice4 = new System.Windows.Forms.Label();
            this.lblPlayerChoice3 = new System.Windows.Forms.Label();
            this.lblNbWin1 = new System.Windows.Forms.Label();
            this.lblNbWin4 = new System.Windows.Forms.Label();
            this.lblNbWin3 = new System.Windows.Forms.Label();
            this.lblNbWin2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBot1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBot1
            // 
            this.txtBot1.Enabled = false;
            this.txtBot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBot1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBot1.Location = new System.Drawing.Point(27, 26);
            this.txtBot1.Multiline = true;
            this.txtBot1.Name = "txtBot1";
            this.txtBot1.Size = new System.Drawing.Size(138, 62);
            this.txtBot1.TabIndex = 0;
            this.txtBot1.Text = "Bot 1";
            this.txtBot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBot2
            // 
            this.txtBot2.Enabled = false;
            this.txtBot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBot2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBot2.Location = new System.Drawing.Point(706, 26);
            this.txtBot2.Multiline = true;
            this.txtBot2.Name = "txtBot2";
            this.txtBot2.Size = new System.Drawing.Size(138, 62);
            this.txtBot2.TabIndex = 1;
            this.txtBot2.Text = "Bot 2";
            this.txtBot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pcbBot2
            // 
            this.pcbBot2.Image = global::MiniGames.Properties.Resources.DosCarte;
            this.pcbBot2.Location = new System.Drawing.Point(771, 105);
            this.pcbBot2.Name = "pcbBot2";
            this.pcbBot2.Size = new System.Drawing.Size(73, 110);
            this.pcbBot2.TabIndex = 2;
            this.pcbBot2.TabStop = false;
            // 
            // pcbBot1
            // 
            this.pcbBot1.Image = global::MiniGames.Properties.Resources.DosCarte;
            this.pcbBot1.Location = new System.Drawing.Point(27, 105);
            this.pcbBot1.Name = "pcbBot1";
            this.pcbBot1.Size = new System.Drawing.Size(73, 110);
            this.pcbBot1.TabIndex = 4;
            this.pcbBot1.TabStop = false;
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.Location = new System.Drawing.Point(299, 38);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(245, 25);
            this.lblWinner.TabIndex = 5;
            this.lblWinner.Text = "Le gagnant du pari est : ";
            // 
            // lblPlayerChoice2
            // 
            this.lblPlayerChoice2.AutoSize = true;
            this.lblPlayerChoice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerChoice2.Location = new System.Drawing.Point(22, 374);
            this.lblPlayerChoice2.Name = "lblPlayerChoice2";
            this.lblPlayerChoice2.Size = new System.Drawing.Size(425, 25);
            this.lblPlayerChoice2.TabIndex = 6;
            this.lblPlayerChoice2.Text = "Le joueur (joueur) à parier sur le Bot (num) ";
            // 
            // lblPlayerChoice1
            // 
            this.lblPlayerChoice1.AutoSize = true;
            this.lblPlayerChoice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerChoice1.Location = new System.Drawing.Point(22, 327);
            this.lblPlayerChoice1.Name = "lblPlayerChoice1";
            this.lblPlayerChoice1.Size = new System.Drawing.Size(425, 25);
            this.lblPlayerChoice1.TabIndex = 7;
            this.lblPlayerChoice1.Text = "Le joueur (joueur) à parier sur le Bot (num) ";
            // 
            // lblPlayerChoice4
            // 
            this.lblPlayerChoice4.AutoSize = true;
            this.lblPlayerChoice4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerChoice4.Location = new System.Drawing.Point(22, 474);
            this.lblPlayerChoice4.Name = "lblPlayerChoice4";
            this.lblPlayerChoice4.Size = new System.Drawing.Size(425, 25);
            this.lblPlayerChoice4.TabIndex = 8;
            this.lblPlayerChoice4.Text = "Le joueur (joueur) à parier sur le Bot (num) ";
            // 
            // lblPlayerChoice3
            // 
            this.lblPlayerChoice3.AutoSize = true;
            this.lblPlayerChoice3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerChoice3.Location = new System.Drawing.Point(22, 425);
            this.lblPlayerChoice3.Name = "lblPlayerChoice3";
            this.lblPlayerChoice3.Size = new System.Drawing.Size(425, 25);
            this.lblPlayerChoice3.TabIndex = 9;
            this.lblPlayerChoice3.Text = "Le joueur (joueur) à parier sur le Bot (num) ";
            // 
            // lblNbWin1
            // 
            this.lblNbWin1.AutoSize = true;
            this.lblNbWin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbWin1.Location = new System.Drawing.Point(453, 327);
            this.lblNbWin1.Name = "lblNbWin1";
            this.lblNbWin1.Size = new System.Drawing.Size(114, 25);
            this.lblNbWin1.TabIndex = 10;
            this.lblNbWin1.Text = "Victoire : 0";
            // 
            // lblNbWin4
            // 
            this.lblNbWin4.AutoSize = true;
            this.lblNbWin4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbWin4.Location = new System.Drawing.Point(453, 474);
            this.lblNbWin4.Name = "lblNbWin4";
            this.lblNbWin4.Size = new System.Drawing.Size(114, 25);
            this.lblNbWin4.TabIndex = 11;
            this.lblNbWin4.Text = "Victoire : 0";
            // 
            // lblNbWin3
            // 
            this.lblNbWin3.AutoSize = true;
            this.lblNbWin3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbWin3.Location = new System.Drawing.Point(453, 425);
            this.lblNbWin3.Name = "lblNbWin3";
            this.lblNbWin3.Size = new System.Drawing.Size(114, 25);
            this.lblNbWin3.TabIndex = 12;
            this.lblNbWin3.Text = "Victoire : 0";
            // 
            // lblNbWin2
            // 
            this.lblNbWin2.AutoSize = true;
            this.lblNbWin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbWin2.Location = new System.Drawing.Point(453, 374);
            this.lblNbWin2.Name = "lblNbWin2";
            this.lblNbWin2.Size = new System.Drawing.Size(114, 25);
            this.lblNbWin2.TabIndex = 13;
            this.lblNbWin2.Text = "Victoire : 0";
            // 
            // Bataille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(856, 590);
            this.Controls.Add(this.lblNbWin2);
            this.Controls.Add(this.lblNbWin3);
            this.Controls.Add(this.lblNbWin4);
            this.Controls.Add(this.lblNbWin1);
            this.Controls.Add(this.lblPlayerChoice3);
            this.Controls.Add(this.lblPlayerChoice4);
            this.Controls.Add(this.lblPlayerChoice1);
            this.Controls.Add(this.lblPlayerChoice2);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.pcbBot1);
            this.Controls.Add(this.pcbBot2);
            this.Controls.Add(this.txtBot2);
            this.Controls.Add(this.txtBot1);
            this.Name = "Bataille";
            this.Text = "Bataille";
            ((System.ComponentModel.ISupportInitialize)(this.pcbBot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBot1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBot1;
        private System.Windows.Forms.TextBox txtBot2;
        private System.Windows.Forms.PictureBox pcbBot2;
        private System.Windows.Forms.PictureBox pcbBot1;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label lblPlayerChoice2;
        private System.Windows.Forms.Label lblPlayerChoice1;
        private System.Windows.Forms.Label lblPlayerChoice4;
        private System.Windows.Forms.Label lblPlayerChoice3;
        private System.Windows.Forms.Label lblNbWin1;
        private System.Windows.Forms.Label lblNbWin4;
        private System.Windows.Forms.Label lblNbWin3;
        private System.Windows.Forms.Label lblNbWin2;
    }
}