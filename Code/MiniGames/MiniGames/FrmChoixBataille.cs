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
        #region public attribut
        public List<int> ListChoiceBotPlayer = new List<int>();
        #endregion public attribut

        #region private attribut
        List<string> ListNamePlayer = new List<string>();
        int i = 0;
        #endregion private attribut

        #region contructor
        /// <summary>
        /// This constructor initializes a new instance of the form of ChoixBataille.
        /// </summary>
        /// <param name="ListNamePlayer"></param>
        public FrmChoixBataille(List<string> ListNamePlayer)
        {
            InitializeComponent();
            this.ListNamePlayer = ListNamePlayer;
            lblPlayer.Text = "Au joueur : " + ListNamePlayer[i];
        }

        #endregion contructor
        
        #region private method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion private method
    }
}
