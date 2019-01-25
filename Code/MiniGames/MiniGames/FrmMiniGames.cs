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
        #region private attribut
        ConnectionDB connection = new ConnectionDB();
        #endregion private attribut

        #region constructor
        /// <summary>
        /// This constructor initializes a new instance of the form of MiniGames.
        /// </summary>
        public FrmMiniGames()
        {
            InitializeComponent();
        }
        #endregion constructor

        #region private method
        /// <summary>
        /// Method for open solitaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSolitaire_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSolitaire solitaire = new FrmSolitaire();
            solitaire.Show();

            FrmSolitaire.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        /// <summary>
        /// Method for open Morpion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdMorpion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMorpion morpion = new FrmMorpion();
            morpion.Show();

            FrmMorpion.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        /// <summary>
        /// Method for open Bataille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdBataille_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBataille bataille = new FrmBataille();
            bataille.Show();

            FrmBataille.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }
        /// <summary>
        /// Method for open Profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProfile profile = new FrmProfile();
            profile.Show();

            FrmProfile.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJeu_FormClosing);
        }

        /// <summary>
        /// Method to open FrmMiniGames when the previous form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FrmJeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// Method to open FrmMiniGames when the previous form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion private method


    }
}
