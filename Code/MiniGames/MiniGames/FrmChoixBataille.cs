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
        List<string> ListNamePlayer;
        public List<int> ListChoiceBotPlayer;
        public FrmChoixBataille(List<string> ListNamePlayer)
        {
            InitializeComponent();
            this.ListNamePlayer = ListNamePlayer;
        }

        private void ListChoiceBot(object sender, EventArgs e)
        {
            Control Button = (Control)sender;
            ListChoiceBotPlayer.Add(Convert.ToInt16(Button.Name.Substring(12)));
        }
    }
}
