using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class FrmMiniGames : Form
    {
        public FrmMiniGames()
        {
            InitializeComponent();
        }

        private void CmdSolitaire_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSolitaire solitaire = new FrmSolitaire();
            solitaire.Show();
            

            //Evenement actif lors de la fermeture de jeu
            FrmSolitaire.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdMorpion_Click(object sender, EventArgs e)
        {
            this.Hide();
            /*FrmPlayers player = new FrmPlayers(2, 2);
            player.Show();*/
            FrmMorpion morpion = new FrmMorpion();
            morpion.Show();

            FrmMorpion.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdBataille_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBataille bataille = new FrmBataille();
            bataille.Show();

            FrmBataille.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProfile profile = new FrmProfile();
            profile.Show();

            FrmProfile.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        //Affiche le menu a nouveau lorsque le jeu se ferme
        private void FrmJeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void troll(object sender, FormClosingEventArgs e)
        {
            
        }

    }
}
