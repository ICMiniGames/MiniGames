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
    public partial class Player : Form
    {
        public Player(int NbUserBase, int NbUserMax)
        {
            InitializeComponent();

            switch (NbUserMax)
            {
                case 1: cmdrUser1.Enabled = true; break;

                case 2: cmdrUser1.Enabled = true; cmdrUser2.Enabled = true; break;

                case 3: cmdrUser1.Enabled = true; cmdrUser2.Enabled = true; cmdrUser3.Enabled = true; break;

                case 4: cmdrUser1.Enabled = true; cmdrUser2.Enabled = true; cmdrUser3.Enabled = true; cmdrUser4.Enabled = true; break;
            }

            switch (NbUserBase)
            {
                case 1: cmdrUser1.Checked = true; break;
                case 2: cmdrUser1.Enabled = false; cmdrUser2.Checked = true; break;
                case 3: cmdrUser1.Checked = true; break;
                case 4: cmdrUser1.Checked = true; break;
            }
        }

        private void cmdrUser1_CheckedChanged(object sender, EventArgs e)
        {
            NbUserVisible(1);
        }

        private void cmdrUser2_CheckedChanged_1(object sender, EventArgs e)
        {
            NbUserVisible(2);
        }

        private void cmdrUser3_CheckedChanged_1(object sender, EventArgs e)
        {
            NbUserVisible(3);
        }

        private void cmdrUser4_CheckedChanged_1(object sender, EventArgs e)
        {
            NbUserVisible(4);
        }

        private void NbUserVisible(int Checked)
        {
            switch (Checked)
            {
                case 1: lblNewUser2.Visible = false; lblNewUser3.Visible = false; lblNewUser4.Visible = false; txtNameUser2.Visible = false; txtNameUser3.Visible = false; txtNameUser4.Visible = false; break; //ajouter l'affichage des labels
                case 2: lblNewUser2.Visible = true; lblNewUser3.Visible = false; lblNewUser4.Visible = false; txtNameUser2.Visible = true; txtNameUser3.Visible = false; txtNameUser4.Visible = false; break;
                case 3: lblNewUser2.Visible = true; lblNewUser3.Visible = true; lblNewUser4.Visible = false; txtNameUser2.Visible = true; txtNameUser3.Visible = true; txtNameUser4.Visible = false; break;
                case 4: lblNewUser2.Visible = true; lblNewUser3.Visible = true; lblNewUser4.Visible = true; txtNameUser2.Visible = true; txtNameUser3.Visible = true; txtNameUser4.Visible = true; break;
            }
        }

       
    }
}
