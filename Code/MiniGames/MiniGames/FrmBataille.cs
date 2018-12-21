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
        #region public attribut
        public List<Card> ListCards = new List<Card>();
        public List<Card> CardBot1 = new List<Card>();
        public List<Card> CardBot2 = new List<Card>();
        public List<int> ListWinPlayer = new List<int>();
        public string StatRound;
        public int WinBot1 = 0;
        public int WinBot2 = 0;
        #endregion public attribut

        #region private attribut
        FrmPlayers player;
        ConnectionDB connection = new ConnectionDB();
        FrmChoixBataille choixBataille;
        List<string> ListNamePlayer;
        List<int> ListChoiceBotPlayer;
        private Random rnd = new Random();
        private int NbBet = 0;
        #endregion private attribut

        #region constructor
        /// <summary>
        /// This constructor initializes a new instance of the form of Bataille.
        /// </summary>
        public FrmBataille()
        {
            for (int i = 0; i < 4; i++) { ListWinPlayer.Add(0); }
            InitializeComponent();
            player = new FrmPlayers(1, 4);
            player.ShowDialog();
            ListNamePlayer = player.NamePlayer();
            
            switch (player.NbNamePlayers)
            {
                case 1: grpUser4.Visible = false; grpUser3.Visible = false; grpUser2.Visible = false; grpUser4.Enabled = false; grpUser3.Enabled = false; grpUser2.Enabled = false; break;
                case 2: grpUser4.Visible = false; grpUser3.Visible = false; grpUser2.Visible = true; grpUser4.Enabled = false; grpUser3.Enabled = false; grpUser2.Enabled = true; break;
                case 3: grpUser4.Visible = false; grpUser3.Visible = true; grpUser2.Visible = true; grpUser4.Enabled = false; grpUser3.Enabled = true; grpUser2.Enabled = true; break;
                case 4: grpUser4.Visible = true; grpUser3.Visible = true; grpUser2.Visible = true; grpUser4.Enabled = true; grpUser3.Enabled = true; grpUser2.Enabled = true; break;
            }

            choixBataille = new FrmChoixBataille(ListNamePlayer);
            choixBataille.ShowDialog();
            ListChoiceBotPlayer = choixBataille.ListChoiceBotPlayer;

            lblPlayerChoice1.Text = "Le joueur " + ListNamePlayer[0] + " à parier sur le Bot " + ListChoiceBotPlayer[0];
            if (grpUser2.Enabled) { lblPlayerChoice2.Text = "Le joueur " + ListNamePlayer[1] + " à parier sur le Bot " + ListChoiceBotPlayer[1]; }
            if (grpUser3.Enabled) { lblPlayerChoice3.Text = "Le joueur " + ListNamePlayer[2] + " à parier sur le Bot " + ListChoiceBotPlayer[2]; }
            if (grpUser4.Enabled) { lblPlayerChoice4.Text = "Le joueur " + ListNamePlayer[3] + " à parier sur le Bot " + ListChoiceBotPlayer[3]; }
        }
        #endregion constructor

        #region public method
        /// <summary>
        /// Create lsit of card for each bot
        /// </summary>
        public void CreateCardList()
        {
            ListCards = connection.GetCard();
            Shuffle(ListCards);
            for (int i = 0; i < ListCards.Count() / 2; i++)
            {
                CardBot1.Add(ListCards[i]);
                CardBot2.Add(ListCards[i]);
            }
            Shuffle(CardBot1);
            Shuffle(CardBot2);
        }

        /// <summary>
        /// Method that activates when you click on the bet launch button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmdStartBet_Click(object sender, EventArgs e)
        {
            NbBet++;

            CreateCardList();

            while (CardBot1.Count() != 0 || CardBot2.Count() != 0)
            {
                //lblNbCardBot1.Text = CardBot1.Count().ToString();
                //lblNbCardBot2.Text = CardBot2.Count().ToString();
                Card cardBot1 = CardBot1[0];
                CardBot1.Remove(cardBot1);
                Card cardBot2 = CardBot2[0];
                CardBot2.Remove(cardBot2);

                if (cardBot1.GetValeur() == 1) // Manche gagnée par le bot 1
                {
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ".  le Bot1 gagne");
                    WinBot1++;
                }
                else if (cardBot2.GetValeur() == 1) // Manche gagnée par le bot 2
                {
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ". le Bot2 gagne");
                    WinBot2++;
                }
                else if (cardBot1.GetValeur() == cardBot2.GetValeur()) // Manche avec égalité
                {
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ". Il y a Bataille");
                }
                else if (cardBot1.GetValeur() > cardBot2.GetValeur()) // Manche gagnée par le bot 1
                {
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ".  le Bot1 gagne");
                    WinBot1++;
                }
                else if (cardBot1.GetValeur() < cardBot2.GetValeur()) // Manche gagnée par le bot 2
                {
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ". le Bot2 gagne");
                    WinBot2++;
                }

                if (CardBot1.Count() == 0) // Fin de partie
                {
                    break;
                }
            }
            if (WinBot1 > WinBot2) // en cas de victoire
            {
                lblWinner.Text = "Le match c'est terminé sur la victoire du bot1";
                StatRound = "Bot1";
            }
            else if (WinBot2 > WinBot1) // en cas de victoire du bot 2
            {
                lblWinner.Text = "Le match c'est terminé sur la victoire du bot2";
                StatRound = "Bot2";
            }
            else //en cas d'égalité
            {
                lblWinner.Text = "Le match c'est terminé sur une égalité";
                StatRound = "Bot0";
            }
            WinBot(StatRound);
            WinBot1 = 0;
            WinBot2 = 0;
        }

        /// <summary>
        /// A method to check the number of wins for each player and add points to them when they are betting.
        /// </summary>
        /// <param name="Winner"></param>
        public void WinBot(string Winner)
        {
            for (int i = 0; i < ListChoiceBotPlayer.Count(); i++)
            {
                int Win = ListWinPlayer[i];
                switch (Winner)
                {
                    case "Bot0": break; //égalité donc pas de gagnant
                    case "Bot1": //vitoire du bot 1 donc possible gagnant
                        if (ListChoiceBotPlayer[i] == 1)
                        {
                            Win++;
                        }
                        break;
                    case "Bot2": //victoire du bot 2 donc possible gagnant
                        if (ListChoiceBotPlayer[i] == 2)
                        {
                            Win++;
                        }

                        break;
                }
                ListWinPlayer[i] = Win;
            }

            lblNbWin1.Text = "Victoire : " + ListWinPlayer[0].ToString();
            lblNbWin2.Text = "Victoire : " + ListWinPlayer[1].ToString();
            lblNbWin3.Text = "Victoire : " + ListWinPlayer[2].ToString();
            lblNbWin4.Text = "Victoire : " + ListWinPlayer[3].ToString();

            if (!ListWinPlayer.Contains(5))
            {
                choixBataille = new FrmChoixBataille(ListNamePlayer);
                choixBataille.ShowDialog();
                ListChoiceBotPlayer = choixBataille.ListChoiceBotPlayer;

                lblPlayerChoice1.Text = "Le joueur " + ListNamePlayer[0] + " à parier sur le Bot " + ListChoiceBotPlayer[0];
                if (grpUser2.Enabled) { lblPlayerChoice2.Text = "Le joueur " + ListNamePlayer[1] + " à parier sur le Bot " + ListChoiceBotPlayer[1]; }
                if (grpUser3.Enabled) { lblPlayerChoice3.Text = "Le joueur " + ListNamePlayer[2] + " à parier sur le Bot " + ListChoiceBotPlayer[2]; }
                if (grpUser4.Enabled) { lblPlayerChoice4.Text = "Le joueur " + ListNamePlayer[3] + " à parier sur le Bot " + ListChoiceBotPlayer[3]; }
            }
            else
            {
                string Loser1 = "";
                string Loser2 = "";
                string Loser3 = "";

                for (int i = 0; i < ListChoiceBotPlayer.Count(); i++)
                {
                    if (ListWinPlayer[i] == 5)
                    {
                        switch (ListChoiceBotPlayer.Count())
                        {
                            case 1: Loser1 = ""; Loser2 = ""; Loser3 = ""; break;
                            case 2: if (i == 0) { Loser1 = ListNamePlayer[1]; } else { Loser1 = ListNamePlayer[0]; } break;
                            case 3: if (i == 0) { Loser1 = ListNamePlayer[1]; Loser2 = ListNamePlayer[2]; } else if (i == 1) { Loser1 = ListNamePlayer[0]; Loser2 = ListNamePlayer[2]; } else { Loser1 = ListNamePlayer[0]; Loser2 = ListNamePlayer[1]; } break;
                            case 4: if (i == 0) { Loser1 = ListNamePlayer[1]; Loser2 = ListNamePlayer[2]; Loser3 = ListNamePlayer[3]; } else if (i == 1) { Loser1 = ListNamePlayer[0]; Loser2 = ListNamePlayer[2]; Loser3 = ListNamePlayer[3]; } else if (i == 2) { Loser1 = ListNamePlayer[0]; Loser2 = ListNamePlayer[1]; Loser3 = ListNamePlayer[3]; } else { Loser1 = ListNamePlayer[0]; Loser2 = ListNamePlayer[1]; Loser3 = ListNamePlayer[2]; } break;
                        }
                        connection.InsertScoreBataille(ListNamePlayer[i], Loser1, Loser2, Loser3, ListChoiceBotPlayer.Count(), NbBet);

                        if (MessageBox.Show("Bravo " + ListNamePlayer[i] + " tu as gagné(e) la partie en " + NbBet + " paris.\nVoulez-vous continuer à jouer et continuer avec les mêmes joueurs ?", "Victoire", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ClearGround(true);
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }

        }
        #endregion public method
        
        #region private method
        /// <summary>
        /// mix of list of cards
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stack"></param>
        private void Shuffle<T>(List<T> list)
        {
            var values = list.ToArray();                           //Stock value of stack
            list.Clear();                                          //Clear value of stack
            foreach (var value in values.OrderBy(x => rnd.Next()))  //swap the space between two cards
            {
                list.Add(value);                                  //Send the stored card instead of another
            }
        }

        /// <summary>
        /// Reset the game except the number of each player and their name.
        /// </summary>
        /// <param name="KeepPlayer"></param>
        private void ClearGround(bool KeepPlayer)
        {
            for (int i = 0; i < ListNamePlayer.Count(); i++)
            {
                ListWinPlayer[i] = 0;
                ListChoiceBotPlayer[i] = 0;
            }

            lblNbWin1.Text = "Victoire : 0";
            lblNbWin2.Text = "Victoire : 0";
            lblNbWin3.Text = "Victoire : 0";
            lblNbWin4.Text = "Victoire : 0";
            lblWinner.Text = "";
            NbBet = 0;
        }
        #endregion private method
    }
}
