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

        }

        private void CmdMorpion_Click(object sender, EventArgs e)
        {
            Morpion morpion = new Morpion();
            morpion.ShowDialog();
        }

        private void CmdBataille_Click(object sender, EventArgs e)
        {

        }
    }
}
