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
        ConnectionDB connection = new ConnectionDB();
        FrmChoixBataille choixBataille;
        List<string> ListNamePlayer;
        List<int> ListChoiceBotPlayer;
        List<int> ListWinPlayer = new List<int>();
        List<Card> ListCards = new List<Card>();
        List<Card> CardBot1 = new List<Card>();
        List<Card> CardBot2 = new List<Card>();
        private Random rnd = new Random();
        private int NbBet = 0;

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

        /// <summary>
        /// mix of stacks of cards
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

        private void cmdStartBet_Click(object sender, EventArgs e)
        {
            NbBet++;
            int WinBot1 = 0;
            int WinBot2 = 0;
            ListCards = connection.GetCard();
            Shuffle(ListCards);
            for (int i = 0; i < ListCards.Count() / 2 ; i++)
            {
                CardBot1.Add(ListCards[i]);
                ListCards.Remove(ListCards[i]);
                CardBot2.Add(ListCards[i]);
                ListCards.Remove(ListCards[i]);
            }
            Shuffle(CardBot1);
            Shuffle(CardBot2);

            while (CardBot1.Count() != 0 || CardBot2.Count() != 0)
            {
                //lblNbCardBot1.Text = CardBot1.Count().ToString();
                //lblNbCardBot2.Text = CardBot2.Count().ToString();
                Card cardBot1 = CardBot1[0];
                CardBot1.Remove(cardBot1);
                Card cardBot2 = CardBot2[0];
                CardBot2.Remove(cardBot2);

                if(cardBot1.GetValeur() == 1) // Manche gagnée par le bot 1
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

                if(CardBot1.Count() == 0) // Fin de partie
                {
                    break;
                }
            }
            if (WinBot1 > WinBot2) // en cas de victoire
            {
                lblWinner.Text = "Le match c'est terminé sur la victoire du bot1";
                WinBot("Bot1");
            }
            else if(WinBot2 > WinBot1) // en cas de victoire du bot 2
            {
                lblWinner.Text = "Le match c'est terminé sur la victoire du bot2";
                WinBot("Bot2");
            }
            else //en cas d'égalité
            {
                lblWinner.Text = "Le match c'est terminé sur une égalité";
                WinBot("Bot0");
            }
        }

        private void WinBot(string Winner)
        {
            for (int i = 0; i < ListChoiceBotPlayer.Count(); i++) {
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
            }
            else
            {
                string Loser1 = "";
                string Loser2 = "";
                string Loser3 = "";

                for (int i = 0; i < ListChoiceBotPlayer.Count(); i++)
                {
                    if(ListWinPlayer[i] == 5)
                    {
                        if (ListNamePlayer.Count() == 2) { if (ListNamePlayer[1] == "") { Loser1 = ""; } else { Loser1 = ListNamePlayer[1]; } }
                        if (ListNamePlayer.Count() == 3) { if (ListNamePlayer[2] == "") { Loser2 = ""; } else { Loser2 = ListNamePlayer[2]; } }
                        if (ListNamePlayer.Count() == 4) { if (ListNamePlayer[3] == "") { Loser3 = ""; } else { Loser3 = ListNamePlayer[3]; } }

                        connection.InsertScoreBataille(ListNamePlayer[i], Loser1, Loser2, Loser3, ListChoiceBotPlayer.Count(), NbBet);

                        if(MessageBox.Show("Bravo " + ListNamePlayer[i] + " tu sa gagné la partie grâce à tes paris.\nVoulez-vous continuer à jouer et continuer avec les mêmes joueurs ?", "Victoire", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void ClearGround(bool KeepPlayer)
        {
            for(int i = 0; i < ListNamePlayer.Count(); i++)
            {
                ListWinPlayer[i] = 0;
                ListChoiceBotPlayer[i] = 0;
            }

            lblNbWin1.Text = "Victoire : 0";
            lblNbWin2.Text = "Victoire : 0";
            lblNbWin3.Text = "Victoire : 0";
            lblNbWin4.Text = "Victoire : 0";
            lblWinner.Text = "Le match c'est terminé sur";
            NbBet = 0;



        }
    }
}
