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
        public Morpion()
        {
            player = new Player(2, 2);
            InitializeComponent();
            player.ShowDialog();
            this.Paint += new PaintEventHandler(MyPaint);
        }
        private void MyPaint(object sender, PaintEventArgs e)
        {
            Graphics G;
            float Distance = 32;
            Pen P = new Pen(Color.Black, 5);
            G = e.Graphics;

            G.DrawLine(P, (Distance * 2), (Distance * 6), (Distance * 14), (Distance * 6));
            G.DrawLine(P, (Distance * 2), (Distance * 10), (Distance * 14), (Distance * 10));
            G.DrawLine(P, (Distance * 6), (Distance * 2), (Distance * 6), (Distance * 14));
            G.DrawLine(P, (Distance * 10), (Distance * 2), (Distance * 10), (Distance * 14));
        }
    }
}
