namespace MiniGames
{
    partial class FrmChoixBataille
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoixBataille));
            this.lblPlayer = new System.Windows.Forms.Label();
            this.cmdChoiceBot1 = new System.Windows.Forms.Button();
            this.cmdChoiceBot2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(12, 28);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(122, 25);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "Au joueur : ";
            // 
            // cmdChoiceBot1
            // 
            this.cmdChoiceBot1.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.cmdChoiceBot1.Location = new System.Drawing.Point(17, 82);
            this.cmdChoiceBot1.Name = "cmdChoiceBot1";
            this.cmdChoiceBot1.Size = new System.Drawing.Size(145, 100);
            this.cmdChoiceBot1.TabIndex = 2;
            this.cmdChoiceBot1.Text = "Bot 1";
            this.cmdChoiceBot1.UseVisualStyleBackColor = true;
            this.cmdChoiceBot1.Click += new System.EventHandler(this.ListChoiceBot);
            // 
            // cmdChoiceBot2
            // 
            this.cmdChoiceBot2.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChoiceBot2.Location = new System.Drawing.Point(314, 82);
            this.cmdChoiceBot2.Name = "cmdChoiceBot2";
            this.cmdChoiceBot2.Size = new System.Drawing.Size(145, 100);
            this.cmdChoiceBot2.TabIndex = 3;
            this.cmdChoiceBot2.Text = "Bot 2";
            this.cmdChoiceBot2.UseVisualStyleBackColor = true;
            this.cmdChoiceBot2.Click += new System.EventHandler(this.ListChoiceBot);
            // 
            // FrmChoixBataille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 203);
            this.Controls.Add(this.cmdChoiceBot2);
            this.Controls.Add(this.cmdChoiceBot1);
            this.Controls.Add(this.lblPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChoixBataille";
            this.Text = "Sélection du bot gagnant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Button cmdChoiceBot1;
        private System.Windows.Forms.Button cmdChoiceBot2;
    }
}