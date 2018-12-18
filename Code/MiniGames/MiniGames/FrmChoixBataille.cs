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
        List<string> ListNamePlayer = new List<string>();
        public List<int> ListChoiceBotPlayer = new List<int>();
        int i = 0;
        public FrmChoixBataille(List<string> ListNamePlayer)
        {
            InitializeComponent();
            this.ListNamePlayer = ListNamePlayer;
            lblPlayer.Text = "Au joueur : " + ListNamePlayer[i];
        }

        private void ListChoiceBot(object sender, EventArgs e)
        {
            i++;
            Control Button = (Control)sender;
            ListChoiceBotPlayer.Add(Convert.ToInt16(Button.Text.Substring(3)));
            if (ListNamePlayer.Count() > i)
            {
                lblPlayer.Text = "Au joueur : " + ListNamePlayer[i];
                
            }
            else
            {
                this.Close();
            }
        }
    }
}
