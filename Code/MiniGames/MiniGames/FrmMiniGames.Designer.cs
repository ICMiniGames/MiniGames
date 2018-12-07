namespace MiniGames
{
    partial class FrmMiniGames
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmdBataille = new System.Windows.Forms.Button();
            this.CmdMorpion = new System.Windows.Forms.Button();
            this.CmdSolitaire = new System.Windows.Forms.Button();
            this.CmdProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdBataille
            // 
            this.CmdBataille.BackColor = System.Drawing.Color.Black;
            this.CmdBataille.BackgroundImage = global::MiniGames.Properties.Resources.Bataille;
            this.CmdBataille.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdBataille.ForeColor = System.Drawing.Color.White;
            this.CmdBataille.Location = new System.Drawing.Point(429, 47);
            this.CmdBataille.Name = "CmdBataille";
            this.CmdBataille.Size = new System.Drawing.Size(192, 233);
            this.CmdBataille.TabIndex = 2;
            this.CmdBataille.Text = "Bataille";
            this.CmdBataille.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CmdBataille.UseVisualStyleBackColor = false;
            this.CmdBataille.Click += new System.EventHandler(this.CmdBataille_Click);
            // 
            // CmdMorpion
            // 
            this.CmdMorpion.BackColor = System.Drawing.Color.DodgerBlue;
            this.CmdMorpion.BackgroundImage = global::MiniGames.Properties.Resources.Morpion;
            this.CmdMorpion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdMorpion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CmdMorpion.Location = new System.Drawing.Point(220, 46);
            this.CmdMorpion.Name = "CmdMorpion";
            this.CmdMorpion.Size = new System.Drawing.Size(192, 233);
            this.CmdMorpion.TabIndex = 1;
            this.CmdMorpion.Text = "Morpion";
            this.CmdMorpion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CmdMorpion.UseVisualStyleBackColor = false;
            this.CmdMorpion.Click += new System.EventHandler(this.CmdMorpion_Click);
            // 
            // CmdSolitaire
            // 
            this.CmdSolitaire.BackColor = System.Drawing.Color.Green;
            this.CmdSolitaire.BackgroundImage = global::MiniGames.Properties.Resources.solitaire;
            this.CmdSolitaire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdSolitaire.ForeColor = System.Drawing.Color.White;
            this.CmdSolitaire.Location = new System.Drawing.Point(12, 46);
            this.CmdSolitaire.Name = "CmdSolitaire";
            this.CmdSolitaire.Size = new System.Drawing.Size(192, 233);
            this.CmdSolitaire.TabIndex = 0;
            this.CmdSolitaire.Text = "Solitaire";
            this.CmdSolitaire.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CmdSolitaire.UseVisualStyleBackColor = false;
            this.CmdSolitaire.Click += new System.EventHandler(this.CmdSolitaire_Click);
            // 
            // CmdProfile
            // 
            this.CmdProfile.Location = new System.Drawing.Point(546, 12);
            this.CmdProfile.Name = "CmdProfile";
            this.CmdProfile.Size = new System.Drawing.Size(75, 23);
            this.CmdProfile.TabIndex = 3;
            this.CmdProfile.Text = "Profile";
            this.CmdProfile.UseVisualStyleBackColor = true;
            this.CmdProfile.Click += new System.EventHandler(this.CmdProfile_Click);
            // 
            // MiniGames
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(633, 292);
            this.Controls.Add(this.CmdProfile);
            this.Controls.Add(this.CmdBataille);
            this.Controls.Add(this.CmdMorpion);
            this.Controls.Add(this.CmdSolitaire);
            this.Name = "MiniGames";
            this.Text = " Mini-Jeux";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CmdSolitaire;
        private System.Windows.Forms.Button CmdMorpion;
        private System.Windows.Forms.Button CmdBataille;
        private System.Windows.Forms.Button CmdProfile;
    }
}

