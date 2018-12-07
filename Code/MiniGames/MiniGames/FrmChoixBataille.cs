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
    public partial class FrmChoixBataille : Form
    {
        FrmPlayers player = new FrmPlayers(1, 4); //Permet d'utiliser le joueur crée dans FrmPlayer.cs
        public FrmChoixBataille()
        {
            InitializeComponent();
            player.ShowDialog();
        }

        /// <summary>
        /// Permet au joueur de parie sur le BOT1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChoiceBot1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Permet au joueur de parie sur le BOT2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChoiceBot2_Click(object sender, EventArgs e)
        {

        }
    }
}
