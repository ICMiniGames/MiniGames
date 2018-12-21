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

        public FrmSolitaire()
        {
            player = new FrmPlayers(1, 1);
            
            cards = connectionDB.GetCard();
            Shuffle(cards);
            InitializeComponent();
            player.ShowDialog();
        }

        private void Solitaire_Load(object sender, EventArgs e)
        {
            string name = cards[1].GetLink();
            pictureBox31.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/"+cards[0].GetLink() + ".png");
            pictureBox6.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[1].GetLink() + ".png");
            pictureBox13.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[2].GetLink() + ".png");
            pictureBox19.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[3].GetLink() + ".png");
            pictureBox24.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[4].GetLink() + ".png");
            pictureBox28.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[5].GetLink() + ".png");
            pictureBox32.Image = Image.FromFile(@"C:/Projet/MiniGames/Code/MiniGames/MiniGames/bin/Debug/ImageCarte/" + cards[6].GetLink() + ".png");

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
            if (e.Button == MouseButtons.Left)
            {
                PictureBox.BringToFront();
                PictureBox.MouseMove += new MouseEventHandler(Card_MouseMove);
            }
        }
        private void Card_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                Control PictureBox = (Control)sender;
                PictureBox.Location = this.PointToClient(new Point(Cursor.Position.X - 20, Cursor.Position.Y - 20));
            }
        }

        private void Stack_Click(object sender, EventArgs e)
        {

        }
    }
}
