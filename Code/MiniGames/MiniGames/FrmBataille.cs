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
    public partial class FrmBataille : Form
    {
        FrmPlayers player;
        FrmChoixBataille choixBataille = new FrmChoixBataille();

        public FrmBataille()
        {
            player = new FrmPlayers(1, 4);
            InitializeComponent();
            player.ShowDialog();
            choixBataille.ShowDialog();
        }
    }
}
