﻿using System;
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
        int playplayer = 0;
        float Distance = 32;
        
        Pen P = new Pen(Color.Black, 5);
        Pen PG = new Pen(Color.Black, 10);
        float X;
        float Y;
        bool start = true;
        bool cross = false;
        bool circle = false;

        public Morpion()
        {
            
            playplayer = 1;
            player = new Player(2, 2);
            InitializeComponent();
            player.ShowDialog();
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
            Choice(button);
        }

        private void Choice(Control button)
        {
            button.Visible = false;

            X = button.Location.X;
            Y = button.Location.Y;


            switch (playplayer)
            {
                case 1: cross = true; this.Paint += new PaintEventHandler(MyPaintCross); playplayer = 2; break;
                case 2: circle = true; this.Paint += new PaintEventHandler(MyPaintEllipse); playplayer = 1;  break;
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
    }
}
