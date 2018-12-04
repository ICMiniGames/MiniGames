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
    public partial class FrmMorpion : Form
    {
        #region Variable
        int CurrentPlayer = 0;                  //Variable to know which player plays.
        float Distance = 32;                    //Variable containing the general distance for the grid.
        int NbTour = 0;                         //Variable used to count the number of turns that are playing.
        Pen P = new Pen(Color.Black, 5);        //Variable containing the color and the size of the pencil.
        Pen PG = new Pen(Color.Black, 10);      //Variable containing the color and the size of the pencil.
        Pen PGC = new Pen(Color.White, 10);     //Variable containing the color and the size of the pencil.
        float X;                                //Variable containing a horizontal coordinate.
        float Y;                                //Variable containing a vertical coordinate.
        bool cross = false;                     //Variable to avoid drawing crosses if the circles have already been drawn.
        bool circle = false;                    //Variable to avoid drawing circles if the crosses have already been drawn.
        bool clear = false;                     //Variable to avoid cleaning the ground if the game is not over.
        string[] TabMorpion = new string[9];    //Variable containing, in the same place, the characters equivalent to the symbol of the players.
        int[,] TabButtonMorpion = new int[9,2]; //Variable containing the location on the X and Y axis of the PictureBox.
        bool Winner = false;                    //Variable to know if there is a winner.
        bool Win = false;                       //Variable to know if there is a winner.
        int NbCaseUsed = 0;                     //Variable containing the number of boxes that already have a character to know if there is a draw or not.
        #endregion Variable

        #region constructors
        /// <summary>
        /// This constructor initializes a new instance of the form of Morpion.
        /// </summary>
        public FrmMorpion()
        {
            CurrentPlayer = 1;

            FrmPlayers player = new FrmPlayers(2, 2);
            player.ShowDialog();

            InitializeComponent();
            
            List<string> listNamePlayer = player.NamePlayer();
            lblPlayer1.Text = listNamePlayer[0];
            lblPlayer2.Text = listNamePlayer[1];

            TabButtonMorpion[0, 0] = cmdCase1.Location.X;
            TabButtonMorpion[0, 1] = cmdCase1.Location.Y;
            TabButtonMorpion[1, 0] = cmdCase2.Location.X;
            TabButtonMorpion[1, 1] = cmdCase2.Location.Y;
            TabButtonMorpion[2, 0] = cmdCase4.Location.X;
            TabButtonMorpion[2, 1] = cmdCase4.Location.Y;
            TabButtonMorpion[3, 0] = cmdCase3.Location.X;
            TabButtonMorpion[3, 1] = cmdCase3.Location.Y;
            TabButtonMorpion[4, 0] = cmdCase5.Location.X;
            TabButtonMorpion[4, 1] = cmdCase5.Location.Y;
            TabButtonMorpion[5, 0] = cmdCase6.Location.X;
            TabButtonMorpion[5, 1] = cmdCase6.Location.Y;
            TabButtonMorpion[6, 0] = cmdCase7.Location.X;
            TabButtonMorpion[6, 1] = cmdCase7.Location.Y;
            TabButtonMorpion[7, 0] = cmdCase8.Location.X;
            TabButtonMorpion[7, 1] = cmdCase8.Location.Y;
            TabButtonMorpion[8, 0] = cmdCase9.Location.X;
            TabButtonMorpion[8, 1] = cmdCase9.Location.Y;

            lblPlayer1.BackColor = Color.Black;
            lblPlayer1.ForeColor = Color.White;
            this.Paint += new PaintEventHandler(MyPaint);
        }
        #endregion constructors

        #region private methods
        /// <summary>
        /// Method used for when we click in a box, it allows to put the symbol in the report of the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clicker(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            NbTour++;
            switch(CurrentPlayer)
            {
                case 1: Switcher("X", button); break;
                case 2: Switcher("O", button); break;
            }

            ChoicePosition(button);
            if (NbTour >= 5)
            {
                if (Winner == false)
                {
                    VerifyWinner();
                }

                if (Win == false)
                {

                    for (int i = 0; i < TabMorpion.Count(); i++)
                    {
                        if (TabMorpion[i] != null)
                        {
                            NbCaseUsed++;
                        }
                    }
                    if (NbCaseUsed == 9)
                    {
                        MessageNull();
                    }
                    else
                    {
                        NbCaseUsed = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Method for choosing the location of the player's symbol.
        /// </summary>
        /// <param name="button"></param>
        private void ChoicePosition(Control button)
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

        /// <summary>
        /// Switch method to put the characters equivalent to the playing field in a table.
        /// </summary>
        /// <param name="caract"></param>
        /// <param name="button"></param>
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

        /// <summary>
        /// Victory case verification method.
        /// </summary>
        private void VerifyWinner()
        {
            string Case1 = TabMorpion[0];
            string Case2 = TabMorpion[1];
            string Case3 = TabMorpion[2];
            string Case4 = TabMorpion[3];
            string Case5 = TabMorpion[4];
            string Case6 = TabMorpion[5];
            string Case7 = TabMorpion[6];
            string Case8 = TabMorpion[7];
            string Case9 = TabMorpion[8];
            
            //vérifier chaque case
            //horizontal
            if ((Case1 == "X" || Case1 == "O" || Case2 == "X" || Case2 == "O" || Case3 == "X" || Case3 == "O") && (Case1 == Case2 && Case2 == Case3 && Case1 == Case3))
            {
                Win = true;
                MessageWin();
            }
            if ((Case4 == "X" || Case4 == "O" || Case5 == "X" || Case5 == "O" || Case6 == "X" || Case6 == "O") && (Case4 == Case5 && Case5 == Case6 && Case4 == Case6))
            {
                Win = true;
                MessageWin();
            }
            if ((Case7 == "X" || Case7 == "O" || Case8 == "X" || Case8 == "O" || Case9 == "X" || Case9 == "O") && (Case7 == Case8 && Case8 == Case9 && Case7 == Case9))
            {
                Win = true;
                MessageWin();
            }
            //vertical
            if ((Case1 == "X" || Case1 == "O" || Case4 == "X" || Case4 == "O" || Case7 == "X" || Case7 == "O") && (Case1 == Case4 && Case4 == Case7 && Case1 == Case7))
            {
                Win = true;
                MessageWin();
            }
            if ((Case2 == "X" || Case2 == "O" || Case5 == "X" || Case5 == "O" || Case8 == "X" || Case8 == "O") && (Case2 == Case5 && Case5 == Case8 && Case2 == Case8))
            {
                Win = true;
                MessageWin();
            }
            if ((Case3 == "X" || Case3 == "O" || Case6 == "X" || Case6 == "O" || Case9 == "X" || Case9 == "O") && (Case3 == Case6 && Case6 == Case9 && Case3 == Case9))
            {
                Win = true;
                MessageWin();
            }
            //diagonal
            if ((Case1 == "X" || Case1 == "O" || Case5 == "X" || Case5 == "O" || Case9 == "X" || Case9 == "O") && (Case1 == Case5 && Case5 == Case9 && Case1 == Case9))
            {
                Win = true;
                MessageWin();
            }
            if ((Case3 == "X" || Case3 == "O" || Case5 == "X" || Case5 == "O" || Case7 == "X" || Case7 == "O") && (Case3 == Case5 && Case5 == Case7 && Case3 == Case7))
            {
                Win = true;
                MessageWin();
            }            
        }

        /// <summary>
        /// Send a match message and call the method to clear the playing field if the players want to keep playing.
        /// </summary>
        private void MessageNull()
        {
            if (MessageBox.Show("Bravo à vous deux mais c'est un match null\nVoulez-vous continuer ?", "Message de confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearedGround();
            }
            else
            {
                this.Close();
            }

        }

        /// <summary>
        /// Send a victory message and call the method to clear the playing field if the players want to keep playing.
        /// </summary>
        private void MessageWin()
        {
            string Player = "";
            cmdCase1.Visible = false;
            cmdCase2.Visible = false;
            cmdCase4.Visible = false;
            cmdCase3.Visible = false;
            cmdCase5.Visible = false;
            cmdCase6.Visible = false;
            cmdCase7.Visible = false;
            cmdCase8.Visible = false;
            cmdCase9.Visible = false;

            switch (CurrentPlayer)
            {
                case 1: Player = lblPlayer2.Text; int Point1 = Convert.ToInt16(lblScoreJ2.Text); lblScoreJ2.Text = (Point1+1).ToString(); break;
                case 2: Player = lblPlayer1.Text; int Point2 = Convert.ToInt16(lblScoreJ1.Text); lblScoreJ1.Text = (Point2 + 1).ToString(); break;
            }
            
            Winner = true;
            if (MessageBox.Show("Bravo joueur " + Player + " tu as gagné \nVoulez-vous continuer ?", "Message de confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearedGround();
                
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Reset the game except the number of each player and their name.
        /// </summary>
        private void ClearedGround()
        {
            clear = true;
            cmdCase1.Visible = true;
            cmdCase2.Visible = true;
            cmdCase4.Visible = true;
            cmdCase3.Visible = true;
            cmdCase5.Visible = true;
            cmdCase6.Visible = true;
            cmdCase7.Visible = true;
            cmdCase8.Visible = true;
            cmdCase9.Visible = true;
            Win = false;
            NbCaseUsed = 0;

            for(int i = 0; i < TabMorpion.Count(); i++)
            {
                TabMorpion[i] = null;
            }

            for (int i = 1; i <= 9; i++)
            {
                clear = true;
                switch (i)
                {
                    case 1: X = cmdCase1.Location.X; Y = cmdCase1.Location.Y; break;
                    case 2: X = cmdCase2.Location.X; Y = cmdCase2.Location.Y; break;
                    case 3: X = cmdCase4.Location.X; Y = cmdCase4.Location.Y; break;
                    case 4: X = cmdCase3.Location.X; Y = cmdCase3.Location.Y; break;
                    case 5: X = cmdCase5.Location.X; Y = cmdCase5.Location.Y; break;
                    case 6: X = cmdCase6.Location.X; Y = cmdCase6.Location.Y; break;
                    case 7: X = cmdCase7.Location.X; Y = cmdCase7.Location.Y; break;
                    case 8: X = cmdCase8.Location.X; Y = cmdCase8.Location.Y; break;
                    case 9: X = cmdCase9.Location.X; Y = cmdCase9.Location.Y; break;
                }
                this.Paint += new PaintEventHandler(Clear);
            }

            NbTour = 0;
            Winner = false;
            this.Refresh();
            this.Paint += new PaintEventHandler(MyPaint);
        }

        /// <summary>
        /// Draws the crosses for the player one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPaintCross(object sender, PaintEventArgs e)
        {
            if (cross)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawLine(PG, X+32, Y+32, X + 96, Y + 96);
                GM.DrawLine(PG, X+32, Y + 96, X + 96, Y+32);
                cross = false;
            }
        }

        /// <summary>
        /// Draws the circles for the player two.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPaintEllipse(object sender, PaintEventArgs e)
        {
            if (circle)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawEllipse(PG, X + 32, Y + 32, 64, 64);
                circle = false;
            }
        }

        /// <summary>
        /// Clears crosses and circles to replay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear(object sender, PaintEventArgs e)
        {
            if (clear)
            {
                Graphics GM;
                GM = e.Graphics;
                GM.DrawLine(PGC, X+ 32, Y+ 32, X + 32, Y + 32);
                GM.DrawLine(PGC, X+32, Y + 32, X + 32, Y+ 32);
                GM.DrawEllipse(PGC, X + 32, Y + 32, 64, 64);
                clear = false;
            }
        }
            
        /// <summary>
        /// Draws the grid of the Morpion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPaint(object sender, PaintEventArgs e)
        {
            Graphics G;
            G = e.Graphics;
            G.DrawLine(P, (Distance * 2), (Distance * 6), (Distance * 14), (Distance * 6));
            G.DrawLine(P, (Distance * 2), (Distance * 10), (Distance * 14), (Distance * 10));
            G.DrawLine(P, (Distance * 6), (Distance * 2), (Distance * 6), (Distance * 14));
            G.DrawLine(P, (Distance * 10), (Distance * 2), (Distance * 10), (Distance * 14));
        }
        #endregion private methods

    }
}
