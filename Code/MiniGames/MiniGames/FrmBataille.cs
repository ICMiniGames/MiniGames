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
        FrmChoixBataille choixBataille;
        List<string> ListNamePlayer;
        List<int> ListChoiceBotPlayer;

        public FrmBataille()
        {
            player = new FrmPlayers(1, 4);
            InitializeComponent();
            player.ShowDialog();
            ListNamePlayer = player.NamePlayer();
            
            switch (player.NbNamePlayers)
            {
                case 1: grpUser4.Visible = false; grpUser3.Visible = false; grpUser2.Visible = false; break;
                case 2: grpUser4.Visible = false; grpUser3.Visible = false; break;
                case 3: grpUser4.Visible = false; break;
                case 4: break;
            }

            choixBataille = new FrmChoixBataille(ListNamePlayer);
            choixBataille.ShowDialog();
            ListChoiceBotPlayer = choixBataille.ListChoiceBotPlayer;

            lblPlayerChoice1.Text = "Le joueur " + ListNamePlayer[0] + " à parier sur le Bot " + ListChoiceBotPlayer[0];
            if (grpUser2.Visible) { lblPlayerChoice2.Text = "Le joueur " + ListNamePlayer[1] + " à parier sur le Bot " + ListChoiceBotPlayer[1]; }
            if (grpUser2.Visible) { lblPlayerChoice3.Text = "Le joueur " + ListNamePlayer[2] + " à parier sur le Bot " + ListChoiceBotPlayer[2]; }
            if (grpUser2.Visible) { lblPlayerChoice4.Text = "Le joueur " + ListNamePlayer[3] + " à parier sur le Bot " + ListChoiceBotPlayer[3]; }
        }
    }
}
