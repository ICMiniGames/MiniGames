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
    public partial class MiniGames : Form
    {
        public MiniGames()
        {
            InitializeComponent();
        }

        private void CmdSolitaire_Click(object sender, EventArgs e)
        {
            this.Hide();
            Solitaire solitaire = new Solitaire();
            solitaire.Show();
            

            //Evenement actif lors de la fermeture de jeu
            Solitaire.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdMorpion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Morpion morpion = new Morpion();
            morpion.Show();

            Morpion.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdBataille_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bataille bataille = new Bataille();
            bataille.Show();

            Bataille.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        private void CmdProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.Show();

            Profile.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        //Affiche le menu a nouveau lorsque le jeu se ferme
        private void FrmJeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

    }
}
