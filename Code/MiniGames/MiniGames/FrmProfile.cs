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
    public partial class FrmProfile : Form
    {

        ConnectionDB DB = new ConnectionDB();
        Dictionary<string, string> Player = new Dictionary<string, string>();
        List<string> ListPlayer = new List<string>();


        public FrmProfile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the data from the first player of the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProfile_Load(object sender, EventArgs e)
        {
            //if (DB.NamesPlayer.Count() == 0) { DB.ListPlayerAlreadyExist(); }
            ListPlayer = DB.NamesPlayer;


            string Joueur = "";
            Joueur = ListPlayer[0];
            Player = DB.Get_Player(Joueur);
            lstUser.SelectedItem = Joueur;

            for (int i = 0; i < ListPlayer.Count(); i++)
            {
                lstUser.Items.Add(ListPlayer[i]);
            }

            txtBestTime.Text = Player["TempsSolitaire"];
            txtNbWinSolitaire.Text = Player["VictoireSolitaire"];
            txtNbDefSolitaire.Text = Player["DefSolitaire"];

            txtBetBataille.Text = Player["BetBat"];
            txtNbWinBataille.Text = Player["VictoireBat"];
            txtNbDefBataille.Text = Player["DefBat"];

            txtNbWinMorpion.Text = Player["VictoireMorp"];
            txtNbDefMorpion.Text = Player["DefMorp"];

        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Joueur = lstUser.SelectedItem.ToString();
            Player = DB.Get_Player(Joueur);
            txtBestTime.Text = Player["TempsSolitaire"];
            txtNbWinSolitaire.Text = Player["VictoireSolitaire"];
            txtNbDefSolitaire.Text = Player["DefSolitaire"];

            txtBetBataille.Text = Player["BetBat"];
            txtNbWinBataille.Text = Player["VictoireBat"];
            txtNbDefBataille.Text = Player["DefBat"];

            txtNbWinMorpion.Text = Player["VictoireMorp"];
            txtNbDefMorpion.Text = Player["DefMorp"];
        }
    }
}
