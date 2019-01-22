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
    public partial class FrmSolitaire : Form
    {
        List<Card> cards = new List<Card>();
        ConnectionDB connectionDB = new ConnectionDB();
        FrmPlayers player;
        private Random rnd = new Random();
        Card[] ArrayCard = new Card[52];
        int xOldCard = 0;
        int yOldCard = 0;
        int xNewCard = 0;
        int yNewCard = 0;
        int[] valueX = new int[7] { 254, 374, 494, 614, 734, 854, 974 };
        string File = "C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/";
        int cardVisible = 28;
        int Timer = 0;
        int H = 00;
        int M = 00;
        int S = 0;
        Control[,] Placement = new Control[7, 21];
        bool reloadStack = false;
         
        public FrmSolitaire()
        {
            player = new FrmPlayers(1, 1);
            
            cards = connectionDB.GetCard();
            Shuffle(cards);
            InitializeComponent();
            player.ShowDialog();

            for(int i = 0; i < cards.Count(); i++)
            {
                ArrayCard[i] = cards[i];
            }

            Placement[0, 0] = CardGame1;
            Placement[1, 0] = CardGame2;
            Placement[1, 1] = CardGame8;
            Placement[2, 0] = CardGame3;
            Placement[2, 1] = CardGame9;
            Placement[2, 2] = CardGame14;
            Placement[3, 0] = CardGame4;
            Placement[3, 1] = CardGame10;
            Placement[3, 2] = CardGame15;
            Placement[3, 3] = CardGame19;
            Placement[4, 0] = CardGame5;
            Placement[4, 1] = CardGame11;
            Placement[4, 2] = CardGame16;
            Placement[4, 3] = CardGame20;
            Placement[4, 4] = CardGame23;
            Placement[5, 0] = CardGame6;
            Placement[5, 1] = CardGame12;
            Placement[5, 2] = CardGame17;
            Placement[5, 3] = CardGame21;
            Placement[5, 4] = CardGame24;
            Placement[5, 5] = CardGame26;
            Placement[6, 0] = CardGame7;
            Placement[6, 1] = CardGame13;
            Placement[6, 2] = CardGame18;
            Placement[6, 3] = CardGame22;
            Placement[6, 4] = CardGame25;
            Placement[6, 5] = CardGame27;
            Placement[6, 6] = CardGame28;

        }

        private void Solitaire_Load(object sender, EventArgs e)
        {
            StackVisible.Enabled = false;
            CardGame1.Image = Image.FromFile(@File + ArrayCard[0].GetLink() + ".png");
            CardGame8.Image = Image.FromFile(@File + ArrayCard[7].GetLink() + ".png");
            CardGame14.Image = Image.FromFile(@File + ArrayCard[13].GetLink() + ".png");
            CardGame19.Image = Image.FromFile(@File + ArrayCard[18].GetLink() + ".png");
            CardGame23.Image = Image.FromFile(@File + ArrayCard[22].GetLink() + ".png");
            CardGame26.Image = Image.FromFile(@File + ArrayCard[25].GetLink() + ".png");
            CardGame28.Image = Image.FromFile(@File + ArrayCard[27].GetLink() + ".png");

        }

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


        private void Card_MouseDown(object sender, MouseEventArgs e)
        {

            //OnMouseMove(e);
            
            Control PictureBox = (Control)sender;
            
            xOldCard = PictureBox.Location.X;
            yOldCard = PictureBox.Location.Y;

            if (e.Button == MouseButtons.Left)
            {
                PictureBox.BringToFront();
                PictureBox.MouseMove += new MouseEventHandler(Card_MouseMove);
            }
        }
        private void Card_MouseMove(object sender, MouseEventArgs e)
        {

            Control PictureBox = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                PictureBox.Location = this.PointToClient(new Point(Cursor.Position.X - 20, Cursor.Position.Y - 20));
                xNewCard = Cursor.Position.X - 20;
                yNewCard = Cursor.Position.Y - 20;
                //xNewCard -= 200;
                //yNewCard -= 200;
                int CursorX = PictureBox.Location.X; //Cursor.Position.X - 20;
                int CursorY = PictureBox.Location.Y; //Cursor.Position.Y - 20;

                lblX.Text = CursorX.ToString();
                lblY.Text = CursorY.ToString();
            }
            else
            {
                PictureBox.MouseMove -= new MouseEventHandler(Card_MouseMove);
                PictureBox.MouseMove += new MouseEventHandler(Card_MouseUp);
            }

        }

        private void Card_MouseUp(object sender, MouseEventArgs e)
        {
            int PictureBoxX = 0;
            int PictureBoxY = 0;
            int PictureBoxNewY = 0;
            int Colum = 0 ;
            int X = 0;
            int Y = 0;
            bool Row = false;

            Control PictureBox = (Control)sender;
            
            for(int x = 0; x < 7; x++)
            {
                
                if(valueX[x] + 96 >= PictureBox.Location.X && valueX[x] - 24 <= PictureBox.Location.X)
                {
                    Colum = x;
                    X = valueX[x];
                    for (int y = 0; y < 20; y++)
                    {
                        
                        if (Placement[Colum, y] != null)
                        {
                            Y = Placement[Colum, y].Location.Y;

                        }
                        else
                        {
                            PictureBoxNewY = y;
                            break;
                        }
                        
                    }
                }
            }
            for(int x = 0; x < 7; x++)
            {
                for(int y = 0; y < 20; y++)
                {
                    try
                        {
                            if (Placement[x, y].Name == PictureBox.Name)
                            {
                                PictureBoxX = x;
                                PictureBoxY = y;
                                break;
                            }
                        }
                        catch { }
                }
            }
            if (VerifCard((PictureBox)PictureBox, Colum, PictureBoxNewY))
            {
                switch (X)
                {
                    case 254: PictureBox.Location = new Point(254, Y + 20); Placement[0, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 374: PictureBox.Location = new Point(374, Y + 20); Placement[1, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 494: PictureBox.Location = new Point(494, Y + 20); Placement[2, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 614: PictureBox.Location = new Point(614, Y + 20); Placement[3, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 734: PictureBox.Location = new Point(734, Y + 20); Placement[4, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 854: PictureBox.Location = new Point(854, Y + 20); Placement[5, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 974: PictureBox.Location = new Point(974, Y + 20); Placement[6, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                        
                }

                switch (Convert.ToInt16(PictureBox.Name.Substring(8)))
                {
                    case 8: CardGame2.Image = Image.FromFile(@File + ArrayCard[1].GetLink() + ".png"); break;
                    case 9: CardGame3.Image = Image.FromFile(@File + ArrayCard[2].GetLink() + ".png"); break;
                    case 10: CardGame4.Image = Image.FromFile(@File + ArrayCard[3].GetLink() + ".png"); break;
                    case 11: CardGame5.Image = Image.FromFile(@File + ArrayCard[4].GetLink() + ".png"); break;
                    case 12: CardGame6.Image = Image.FromFile(@File + ArrayCard[5].GetLink() + ".png"); break;
                    case 13: CardGame7.Image = Image.FromFile(@File + ArrayCard[6].GetLink() + ".png"); break;
                    case 14: CardGame9.Image = Image.FromFile(@File + ArrayCard[8].GetLink() + ".png"); break;
                    case 15: CardGame10.Image = Image.FromFile(@File + ArrayCard[9].GetLink() + ".png"); break;
                    case 16: CardGame11.Image = Image.FromFile(@File + ArrayCard[10].GetLink() + ".png"); break;
                    case 17: CardGame12.Image = Image.FromFile(@File + ArrayCard[11].GetLink() + ".png"); break;
                    case 18: CardGame13.Image = Image.FromFile(@File + ArrayCard[12].GetLink() + ".png"); break;
                    case 19: CardGame15.Image = Image.FromFile(@File + ArrayCard[14].GetLink() + ".png"); break;
                    case 20: CardGame16.Image = Image.FromFile(@File + ArrayCard[15].GetLink() + ".png"); break;
                    case 21: CardGame17.Image = Image.FromFile(@File + ArrayCard[16].GetLink() + ".png"); break;
                    case 22: CardGame18.Image = Image.FromFile(@File + ArrayCard[17].GetLink() + ".png"); break;
                    case 23: CardGame20.Image = Image.FromFile(@File + ArrayCard[19].GetLink() + ".png"); break;
                    case 24: CardGame21.Image = Image.FromFile(@File + ArrayCard[20].GetLink() + ".png"); break;
                    case 25: CardGame22.Image = Image.FromFile(@File + ArrayCard[21].GetLink() + ".png"); break;
                    case 26: CardGame24.Image = Image.FromFile(@File + ArrayCard[23].GetLink() + ".png"); break;
                    case 27: CardGame25.Image = Image.FromFile(@File + ArrayCard[24].GetLink() + ".png"); break;
                    case 28: CardGame27.Image = Image.FromFile(@File + ArrayCard[26].GetLink() + ".png"); break;
                }
            }
            else
            {
                PictureBox.Location = new Point(xOldCard, yOldCard);
            }
            

            PictureBox.MouseMove -= new MouseEventHandler(Card_MouseUp);
            
            
        }

        private void Stack_Click(object sender, EventArgs e)
        {
            if (!reloadStack)
            {
                cardVisible++;
                PictureBox CardGameStack = new PictureBox();
                CardGameStack.Name = "CardGame" + cardVisible;
                CardGameStack.Image = Image.FromFile(@File + ArrayCard[cardVisible - 1].GetLink() + ".png");
                CardGameStack.Size = new Size(73, 110);
                CardGameStack.SizeMode = PictureBoxSizeMode.StretchImage;
                CardGameStack.Location = new Point(1188, 132);
                CardGameStack.MouseDown += new MouseEventHandler(Card_MouseDown);
                this.Controls.Add(CardGameStack);

                CardGameStack.BringToFront();

                if (cardVisible >= 52)
                {
                    StackHide.Image = Image.FromFile(@File + "Reload.png");
                    reloadStack = true;
                    StackHide.Enabled = true;
                }
            }
            else
            {
                foreach(Control ctrl in Controls)
                {
                    if(ctrl.Location.X == 1188)
                    {
                        if(ctrl.Location.Y == 132)
                        {
                            ctrl.Enabled = false;
                            ctrl.Visible = false;
                            cardVisible = 28;
                            StackHide.Image = Image.FromFile(@File + "DosCarte.png");
                            reloadStack = false;
                        }
                    }



                }
            }
        }

        private void timerSolitaire_Tick(object sender, EventArgs e)
        {
            S = Timer;
            string TextTimer = H+":"+M+":"+S;
            lblTime.Text = TextTimer;
            Timer++;
            if(Timer >= 60)
            {
                Timer = 0;
                M++;
                if(M >= 60)
                {
                    H++;
                }
            }
        }

        public bool VerifCard(PictureBox p, int Colone, int Ligne)
        {
            string color = ArrayCard[Convert.ToInt16(p.Name.Substring(8))-1].GetColor();
            int value = ArrayCard[Convert.ToInt16(p.Name.Substring(8))-1].GetValeur();

            try
            {
                string colorToVerify = ArrayCard[Convert.ToInt16(Placement[Colone, Ligne - 1].Name.Substring(8)) - 1].GetColor(); //problème de limite du tableau.
                int valueToVerify = ArrayCard[Convert.ToInt16(Placement[Colone, Ligne - 1].Name.Substring(8)) - 1].GetValeur();

                if (colorToVerify != color)
                {
                    if (valueToVerify - 1 == value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
               
                if (13 == value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                



            }
            return false;
        }
    }
}
