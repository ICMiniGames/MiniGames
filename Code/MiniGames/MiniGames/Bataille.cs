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
    public partial class Bataille : Form
    {
        Player player;
        ChoixBataille choixBataille = new ChoixBataille();

        public Bataille()
        {
            player = new Player(1, 4);
            InitializeComponent();
            player.ShowDialog();
            choixBataille.ShowDialog();
        }
    }
}
