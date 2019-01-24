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
        #region private attribut

        private List<Card> cards = new List<Card>();
        private ConnectionDB connectionDB = new ConnectionDB();
        private FrmPlayers player;
        private Random rnd = new Random();
        private Card[] ArrayCard = new Card[52];
        private int Heart = 1;
        private int Spide = 1;
        private int Diamond = 1;
        private int Clover = 1;
        private int xOldCard = 0;
        private int yOldCard = 0;
        private int xNewCard = 0;
        private int yNewCard = 0;
        private int[] valueX = new int[8] {254, 374, 494, 614, 734, 854, 974, 21};
        private string File = "C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/";
        private int cardVisible = 1;
        private int Timer = 00;
        private int H = 00;
        private int M = 00;
        private int S = 00;
        private string seconde = "00";
        private string minute = "00";
        private string hour = "00";
        private Control[,] Placement = new Control[7, 21];
        private bool reloadStack = false;
        private int[] sloty = new int[4] { 12, 162, 312, 462 };
        private Control[,] slot = new Control[4, 13];
        private int YSlot = 0;
        private Card[] cardList = new Card[24];
        #endregion private attribut

        #region public method
        /// <summary>
        /// Constructor of FrmSolitaire.
        /// </summary>
        public FrmSolitaire()
        {
            player = new FrmPlayers(1, 1);
            
            cards = connectionDB.GetCard();
            Shuffle(cards);
            InitializeComponent();
            player.ShowDialog();

            Slot1.SendToBack();
            Slot2.SendToBack();
            Slot3.SendToBack();
            Slot4.SendToBack();
            Slot5.SendToBack();
            Slot6.SendToBack();
            Slot7.SendToBack();
            
            for (int i = 0; i < cards.Count(); i++)
            {
                ArrayCard[i] = cards[i];
            }

            for(int i = 0; i < 24; i++)
            {
                cardList[i] = ArrayCard[28 + i];
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

        #endregion public method

        #region private method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            Control PictureBox = (Control)sender;
            
            xOldCard = PictureBox.Location.X;
            yOldCard = PictureBox.Location.Y;

            if (e.Button == MouseButtons.Left)
            {
                PictureBox.BringToFront();
                PictureBox.MouseMove += new MouseEventHandler(Card_MouseMove);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseMove(object sender, MouseEventArgs e)
        {
            int PlacementX = 0;
            int PlacementY = 0;
            Control PictureBox = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                /*for(int i = 0; i< 7; i++)
                {
                    for(int x = 0; x < 21; x++)
                    {
                        if (Placement[i, x] != null)
                        {
                            if (Placement[i, x].Name == PictureBox.Name)
                            {
                                PlacementX = i;
                                PlacementY = x;
                            }
                        }
                    }
                }*/


                PictureBox.Location = this.PointToClient(new Point(Cursor.Position.X - 20, Cursor.Position.Y - 20));
                xNewCard = Cursor.Position.X - 20;
                yNewCard = Cursor.Position.Y - 20;
                /*int NbMultiple = 1;
                for(int i = PlacementY+1; i < 21; i++)
                {
                    if (Placement[PlacementX, i] != null) { Placement[PlacementX, i].BringToFront(); Placement[PlacementX, i].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * NbMultiple))); NbMultiple++; }

                }*/
                /*if (Placement[PlacementX, PlacementY + 1] != null) { Placement[PlacementX, PlacementY + 1].BringToFront(); Placement[PlacementX, PlacementY + 1].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 1))); }
                if (Placement[PlacementX, PlacementY + 2] != null) { Placement[PlacementX, PlacementY + 2].BringToFront(); Placement[PlacementX, PlacementY + 2].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 2))); }
                if (Placement[PlacementX, PlacementY + 3] != null) { Placement[PlacementX, PlacementY + 3].BringToFront(); Placement[PlacementX, PlacementY + 3].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 3))); }
                if (Placement[PlacementX, PlacementY + 4] != null) { Placement[PlacementX, PlacementY + 4].BringToFront(); Placement[PlacementX, PlacementY + 4].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 4))); }
                if (Placement[PlacementX, PlacementY + 5] != null) { Placement[PlacementX, PlacementY + 5].BringToFront(); Placement[PlacementX, PlacementY + 5].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 5))); }
                if (Placement[PlacementX, PlacementY + 6] != null) { Placement[PlacementX, PlacementY + 6].BringToFront(); Placement[PlacementX, PlacementY + 6].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 6))); }
                if (Placement[PlacementX, PlacementY + 7] != null) { Placement[PlacementX, PlacementY + 7].BringToFront(); Placement[PlacementX, PlacementY + 7].Location = this.PointToClient(new Point(xNewCard, yNewCard + (20 * 7))); }
                */int CursorX = PictureBox.Location.X; //Cursor.Position.X - 20;
                int CursorY = PictureBox.Location.Y; //Cursor.Position.Y - 20;
                
            }
            else
            {
                PictureBox.MouseMove -= new MouseEventHandler(Card_MouseMove);
                PictureBox.MouseMove += new MouseEventHandler(Card_MouseUp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseUp(object sender, MouseEventArgs e)
        {
            int PictureBoxX = 0;
            int PictureBoxY = 0;
            int PictureBoxNewY = 0;
            int Colum = 0 ;
            int X = 0;
            int Y = 0;
            bool nameCard = true;
            Control PictureBox = (Control)sender;
            
            for(int x = 0; x < 8; x++)
            {
                
                if(valueX[x] + 96 >= PictureBox.Location.X && valueX[x] - 24 <= PictureBox.Location.X)
                {
                    Colum = x;
                    X = valueX[x];
                    if (X != 21)
                    {
                        for (int y = 0; y < 20; y++)
                        {
                            if (Placement[Colum, y] != null)
                            {
                                Y = Placement[Colum, y].Location.Y;
                            }
                            else if (Placement[Colum, y] == null && y == 0)
                            {
                                Y = -8;
                            }
                            else
                            {
                                PictureBoxNewY = y;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int y = 0; y < 4; y++) { 
                            if (sloty[y] + 129 >= PictureBox.Location.Y && sloty[y] - 21 <= PictureBox.Location.Y)
                            {
                                Y = sloty[y];
                                YSlot = y;
                            }
                        }
                    }
                }
            }
            for(int x = 0; x < 7; x++)
            {
                for(int y = 0; y < 20; y++)
                {
                    if (Placement[x, y] != null && nameCard)
                    {
                        if (Placement[x, y].Name == PictureBox.Name)
                        {
                            PictureBoxX = x;
                            PictureBoxY = y;
                            nameCard = false;
                            break;
                        }
                    }
                }
            }
            int PlacementSlot = 0;
            string symbole = "";
            bool Vrai = true;
            int symboleCard = 0;
            switch (Y)
            {
                case 12:
                    if (ArrayCard[Convert.ToInt16(PictureBox.Name.Substring(8))].GetValeur() == Heart) { symbole = "Coeur"; symboleCard = 0; } else { Vrai = false; } break;
                case 162:
                    if (ArrayCard[Convert.ToInt16(PictureBox.Name.Substring(8))].GetValeur() == Spide) { symbole = "Pique"; symboleCard = 1; } else { Vrai = false; } break;
                case 312:
                    if (ArrayCard[Convert.ToInt16(PictureBox.Name.Substring(8))].GetValeur() == Diamond) { symbole = "Carreau"; symboleCard = 2; } else { Vrai = false; } break;
                case 462:
                    if (ArrayCard[Convert.ToInt16(PictureBox.Name.Substring(8))].GetValeur() == Clover) { symbole = "Trèfle"; symboleCard = 3; } else { Vrai = false; } break;
            }
            for (int i = 0; i < 13; i++)
            {
                if (slot[symboleCard, i] == null && Vrai)
                {
                    slot[symboleCard, i] = PictureBox;
                    PlacementSlot = i;
                    Vrai = false;
                }
            }
            int Xpicture = 0;
            if (VerifCard((PictureBox)PictureBox, Colum, PictureBoxNewY) || VerifCardSlot((PictureBox)PictureBox, YSlot, 0, symbole, PlacementSlot))
            {
                if (cardList.Contains(ArrayCard[Convert.ToInt16(PictureBox.Name.Substring(8))]) && Convert.ToInt16(PictureBox.Name.Substring(8)) != 28)
                {
                    cardList[Convert.ToInt16(PictureBox.Name.Substring(8)) - 29] = null;
                }
                switch (X)
                {
                    case 254: Xpicture = 0; PictureBox.Location = new Point(254, Y + 20); Placement[0, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 374: Xpicture = 1; PictureBox.Location = new Point(374, Y + 20); Placement[1, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 494: Xpicture = 2; PictureBox.Location = new Point(494, Y + 20); Placement[2, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 614: Xpicture = 3; PictureBox.Location = new Point(614, Y + 20); Placement[3, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 734: Xpicture = 4; PictureBox.Location = new Point(734, Y + 20); Placement[4, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 854: Xpicture = 5; PictureBox.Location = new Point(854, Y + 20); Placement[5, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 974: Xpicture = 6; PictureBox.Location = new Point(974, Y + 20); Placement[6, PictureBoxNewY] = PictureBox; Placement[PictureBoxX, PictureBoxY] = null; break;
                    case 21:
                    PictureBox.Location = new Point(21, Y);
                    for (int i = 0; i < 13; i++)
                    {
                        if(slot[YSlot, i] != null)
                        {
                            i++;
                        }
                    }
                    Placement[PictureBoxX, PictureBoxY] = null;
                    break;
                }

                switch (Convert.ToInt16(PictureBox.Name.Substring(8)))
                {
                    case 8: CardGame2.Enabled = true; CardGame2.Image = Image.FromFile(@File + ArrayCard[1].GetLink() + ".png"); break;
                    case 9: CardGame3.Enabled = true; CardGame3.Image = Image.FromFile(@File + ArrayCard[2].GetLink() + ".png"); break;
                    case 10: CardGame4.Enabled = true; CardGame4.Image = Image.FromFile(@File + ArrayCard[3].GetLink() + ".png"); break;
                    case 11: CardGame5.Enabled = true; CardGame5.Image = Image.FromFile(@File + ArrayCard[4].GetLink() + ".png"); break;
                    case 12: CardGame6.Enabled = true; CardGame6.Image = Image.FromFile(@File + ArrayCard[5].GetLink() + ".png"); break;
                    case 13: CardGame7.Enabled = true; CardGame7.Image = Image.FromFile(@File + ArrayCard[6].GetLink() + ".png"); break;
                    case 14: CardGame9.Enabled = true; CardGame9.Image = Image.FromFile(@File + ArrayCard[8].GetLink() + ".png"); break;
                    case 15: CardGame10.Enabled = true; CardGame10.Image = Image.FromFile(@File + ArrayCard[9].GetLink() + ".png"); break;
                    case 16: CardGame11.Enabled = true; CardGame11.Image = Image.FromFile(@File + ArrayCard[10].GetLink() + ".png"); break;
                    case 17: CardGame12.Enabled = true; CardGame12.Image = Image.FromFile(@File + ArrayCard[11].GetLink() + ".png"); break;
                    case 18: CardGame13.Enabled = true; CardGame13.Image = Image.FromFile(@File + ArrayCard[12].GetLink() + ".png"); break;
                    case 19: CardGame15.Enabled = true; CardGame15.Image = Image.FromFile(@File + ArrayCard[14].GetLink() + ".png"); break;
                    case 20: CardGame16.Enabled = true; CardGame16.Image = Image.FromFile(@File + ArrayCard[15].GetLink() + ".png"); break;
                    case 21: CardGame17.Enabled = true; CardGame17.Image = Image.FromFile(@File + ArrayCard[16].GetLink() + ".png"); break;
                    case 22: CardGame18.Enabled = true; CardGame18.Image = Image.FromFile(@File + ArrayCard[17].GetLink() + ".png"); break;
                    case 23: CardGame20.Enabled = true; CardGame20.Image = Image.FromFile(@File + ArrayCard[19].GetLink() + ".png"); break;
                    case 24: CardGame21.Enabled = true; CardGame21.Image = Image.FromFile(@File + ArrayCard[20].GetLink() + ".png"); break;
                    case 25: CardGame22.Enabled = true; CardGame22.Image = Image.FromFile(@File + ArrayCard[21].GetLink() + ".png"); break;
                    case 26: CardGame24.Enabled = true; CardGame24.Image = Image.FromFile(@File + ArrayCard[23].GetLink() + ".png"); break;
                    case 27: CardGame25.Enabled = true; CardGame25.Image = Image.FromFile(@File + ArrayCard[24].GetLink() + ".png"); break;
                    case 28: CardGame27.Enabled = true; CardGame27.Image = Image.FromFile(@File + ArrayCard[26].GetLink() + ".png"); break;
                }
            }
            else
            {
                PictureBox.Location = new Point(xOldCard, yOldCard);

                switch (xOldCard)
                {
                    case 254: Xpicture = 0; break;
                    case 374: Xpicture = 1; break;
                    case 494: Xpicture = 2; break;
                    case 614: Xpicture = 3; break;
                    case 734: Xpicture = 4; break;
                    case 854: Xpicture = 5; break;
                    case 974: Xpicture = 6; break;
                }


                while (Placement[Xpicture, PictureBoxNewY] != null)
                {
                    Placement[Xpicture, PictureBoxNewY].Location = new Point(Placement[Xpicture, PictureBoxNewY].Location.X, Placement[Xpicture, PictureBoxNewY].Location.Y);
                    Placement[Xpicture, PictureBoxNewY].BringToFront();
                    PictureBoxNewY++;
                }
            }
            

            PictureBox.MouseMove -= new MouseEventHandler(Card_MouseUp);
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stack_Click(object sender, EventArgs e)
        {
            if (!reloadStack)
            {
                
                while (cardList[cardVisible - 1] == null)
                {
                    cardVisible++;
                }
                PictureBox CardGameStack = new PictureBox();
                CardGameStack.Name = "CardGame" + (cardVisible + 28);
                CardGameStack.Image = Image.FromFile(@File + cardList[cardVisible - 1].GetLink() + ".png");
                CardGameStack.Size = new Size(73, 110);
                CardGameStack.SizeMode = PictureBoxSizeMode.StretchImage;
                CardGameStack.Location = new Point(1188, 132);
                CardGameStack.MouseDown += new MouseEventHandler(Card_MouseDown);
                this.Controls.Add(CardGameStack);

                CardGameStack.BringToFront();
                cardVisible++;
                if (cardVisible >= 24)
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
                            cardVisible = 1;
                            StackHide.Image = Image.FromFile(@File + "DosCarte.png");
                            reloadStack = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// method for count the time it takes to solve the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSolitaire_Tick(object sender, EventArgs e)
        {
            
            
            S++;
            if(S < 10)
            {
                seconde = "0" + S;
            }
            else
            {
                seconde = S.ToString();
            }
            Timer++;
            if(S >= 60)
            {
                S = 0;
                M++;
                if (M < 10)
                {
                    minute = "0" + M;
                }
                else
                {
                    minute = M.ToString();
                }
                if (M >= 60)
                {
                    H++;
                    if (H < 10)
                    {
                        hour = "0" + H;
                    }
                    else
                    {
                        hour = H.ToString();
                    }
                }
            }
            string TextTimer = hour + " : " + minute + " : " + seconde;
            lblTime.Text = TextTimer;

        }

        /// <summary>
        /// check the cards for placement on other cards.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Colone"></param>
        /// <param name="Ligne"></param>
        /// <returns></returns>
        private bool VerifCard(PictureBox p, int Colone, int Ligne)
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

        /// <summary>
        /// Check the cards for placement in piles by symbol.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Colone"></param>
        /// <param name="Ligne"></param>
        /// <param name="Symbole"></param>
        /// <param name="EmplacementCard"></param>
        /// <returns></returns>
        private bool VerifCardSlot(PictureBox p, int Colone, int Ligne, string Symbole, int EmplacementCard)
        {
            string CardSymbole = ArrayCard[Convert.ToInt16(p.Name.Substring(8)) - 1].GetSymbole();
            int value = ArrayCard[Convert.ToInt16(p.Name.Substring(8)) - 1].GetValeur();

            try
            {
                int valueToVerify = ArrayCard[Convert.ToInt16(slot[Colone, EmplacementCard-1].Name.Substring(8))-1].GetValeur();

                if (Symbole == CardSymbole)
                {
                    if (valueToVerify + 1 == value)
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
                if (1 == value)
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
        #endregion private method
    }
}
