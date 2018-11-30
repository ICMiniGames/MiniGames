using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class Morpion : Form
    {
        Player player;
        int CurrentPlayer = 0;
        float Distance = 32;
        int NbTour = 0;
        Pen P = new Pen(Color.Black, 5);
        Pen PG = new Pen(Color.Black, 10);
        Pen PGC = new Pen(Color.White, 10);
        float X;
        float Y;
        bool start = true;
        bool cross = false;
        bool circle = false;
        bool clear = false;
        string[] TabMorpion = new string[9];
        bool Winner = false;

        public Morpion()
        {
            TabMorpion[0] = "";
            TabMorpion[1] = "";
            TabMorpion[2] = ""; 
            TabMorpion[3] = "";
            TabMorpion[4] = "";
            TabMorpion[5] = "";
            TabMorpion[6] = "";
            TabMorpion[7] = "";
            TabMorpion[8] = "";

            CurrentPlayer = 1;
            player = new Player(2, 2);
            InitializeComponent();
            player.ShowDialog();

            lblPlayer1.BackColor = Color.Black;
            lblPlayer1.ForeColor = Color.White;
            this.Paint += new PaintEventHandler(MyPaint);
        }
        private void MyPaint(object sender, PaintEventArgs e)
        {
            if (start)
            {
                Graphics G;
                G = e.Graphics;
                G.DrawLine(P, (Distance * 2), (Distance * 6), (Distance * 14), (Distance * 6));
                G.DrawLine(P, (Distance * 2), (Distance * 10), (Distance * 14), (Distance * 10));
                G.DrawLine(P, (Distance * 6), (Distance * 2), (Distance * 6), (Distance * 14));
                G.DrawLine(P, (Distance * 10), (Distance * 2), (Distance * 10), (Distance * 14));
                start = false;
            }
        }
        private void Clicker(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            NbTour++;
            switch(CurrentPlayer)
            {
                case 1: Switcher("X", button); break;
                case 2: Switcher("O", button); break;
            }
            
            Choice(button);
            if (NbTour >= 5)
            {
                if (Winner == false)
                {
                    VerifyWinner();
                }
            }
        }

        private void Choice(Control button)
        {
            button.Visible = false;

            X = button.Location.X;
            Y = button.Location.Y;


            switch (CurrentPlayer)
            {
                case 1: cross = true; this.Paint += new PaintEventHandler(MyPaintCross); CurrentPlayer = 2; lblPlayer2.BackColor = Color.Black; lblPlayer2.ForeColor = Color.White; lblPlayer1.BackColor = Color.White; lblPlayer1.ForeColor = Color.Black; break;
                case 2: circle = true; this.Paint += new PaintEventHandler(MyPaintEllipse); CurrentPlayer = 1; lblPlayer1.BackColor = Color.Black; lblPlayer1.ForeColor = Color.White; lblPlayer2.BackColor = Color.White; lblPlayer2.ForeColor = Color.Black; break;
            }

        }

        private void Switcher(string caract, Control button)
        {
            switch(Convert.ToInt16(button.Name.Substring(7)))
            {
                case 1: TabMorpion[0] = caract; break;
                case 2: TabMorpion[1] = caract; break;
                case 3: TabMorpion[2] = caract; break;
                case 4: TabMorpion[3] = caract; break;
                case 5: TabMorpion[4] = caract; break;
                case 6: TabMorpion[5] = caract; break;
                case 7: TabMorpion[6] = caract; break;
                case 8: TabMorpion[7] = caract; break;
                case 9: TabMorpion[8] = caract; break;
            }
        }

        private void VerifyWinner()
        {
            if(TabMorpion[0] == "O" || TabMorpion[0] == "X")
            {
                char lol;
            }
            //vérifier chaque case



            
        }

        private void MessageWin()
        {
            cmdCase1.Visible = false;
            cmdCase2.Visible = false;
            cmdCase3.Visible = false;
            cmdCase4.Visible = false;
            cmdCase5.Visible = false;
            cmdCase6.Visible = false;
            cmdCase7.Visible = false;
            cmdCase8.Visible = false;
            cmdCase9.Visible = false;


            
            Winner = true;
            if (MessageBox.Show("Bravo joueur " + CurrentPlayer + " tu as gagné \nVoulez-vous quitter le jeu ?", "Message de confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {
                clear = true;
                cmdCase1.Visible = true;
                cmdCase2.Visible = true;
                cmdCase3.Visible = true;
                cmdCase4.Visible = true;
                cmdCase5.Visible = true;
                cmdCase6.Visible = true;
                cmdCase7.Visible = true;
                cmdCase8.Visible = true;
                cmdCase9.Visible = true;

                for(int i = 1; i <= 9; i++)
                {
                    clear = true;
                    switch (i)
                    {
                        case 1: X = cmdCase1.Location.X; Y = cmdCase1.Location.Y; break;
                        case 2: X = cmdCase2.Location.X; Y = cmdCase2.Location.Y; break;
                        case 3: X = cmdCase3.Location.X; Y = cmdCase3.Location.Y; break;
                        case 4: X = cmdCase4.Location.X; Y = cmdCase4.Location.Y; break;
                        case 5: X = cmdCase5.Location.X; Y = cmdCase5.Location.Y; break;
                        case 6: X = cmdCase6.Location.X; Y = cmdCase6.Location.Y; break;
                        case 7: X = cmdCase7.Location.X; Y = cmdCase7.Location.Y; break;
                        case 8: X = cmdCase8.Location.X; Y = cmdCase8.Location.Y; break;
                        case 9: X = cmdCase9.Location.X; Y = cmdCase9.Location.Y; break;
                    }
                    this.Paint += new PaintEventHandler(Clear);
                }

                for(int x = 0; x < 9; x++)
                {
                    
                    TabMorpion[x] = "";
                    
                }

                NbTour = 0;
                Winner = false;
            }
        }

        private void MyPaintCross(object sender, PaintEventArgs e)
        {
            if (cross)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawLine(PG, X, Y, X + 64, Y + 64);
                GM.DrawLine(PG, X, Y + 64, X + 64, Y);
                cross = false;
            }
        }
        private void MyPaintEllipse(object sender, PaintEventArgs e)
        {
            if (circle)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawEllipse(PG, X + 5, Y + 5, 53, 53);
                circle = false;
            }
        }

        private void Clear(object sender, PaintEventArgs e)
        {
            if (clear)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawLine(PGC, X, Y, X + 64, Y + 64);
                GM.DrawLine(PGC, X, Y + 64, X + 64, Y);
                GM.DrawEllipse(PGC, X + 5, Y + 5, 53, 53);
                clear = false;
            }
        }
    }
}
