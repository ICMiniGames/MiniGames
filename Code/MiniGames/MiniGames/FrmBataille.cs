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
        List<Card> ListCards = new List<Card>();
        List<Card> CardBot1 = new List<Card>();
        List<Card> CardBot2 = new List<Card>();
        private Random rnd = new Random();

        public FrmBataille()
        {
            
            player = new FrmPlayers(1, 4);
            InitializeComponent();
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
            ListCards = connection.GetCard();
            Shuffle(ListCards);
            for (int i = 0; i < 1 /*ListCards.Count() / 2*/ ; i++)
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

                if (cardBot1.GetValeur() == cardBot2.GetValeur())
                {
                    //MessageBox.Show("Bataille");
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ". Il y a Bataille");
                }
                else if (cardBot1.GetValeur() > cardBot2.GetValeur())
                {
                    //MessageBox.Show("Bot1 Win");
                    CardBot1.Add(cardBot1);
                    CardBot1.Add(cardBot2);
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ".  le Bot1 gagne");
                }
                else if (cardBot1.GetValeur() < cardBot2.GetValeur())
                {
                    //MessageBox.Show("Bot2 Win");
                    CardBot2.Add(cardBot1);
                    CardBot2.Add(cardBot2);
                    Console.WriteLine("Bot1 : " + cardBot1.GetValeur() + ", Bot2 : " + cardBot2.GetValeur() + ". le Bot2 gagne");
                }

                if(CardBot1.Count() == 0)
                {
                    MessageBox.Show("Bot2 Win");
                    break;
                }else if (CardBot2.Count() == 0)
                {
                    MessageBox.Show("Bot1 Win");
                    break;
                }
            }
        }
    }
}
