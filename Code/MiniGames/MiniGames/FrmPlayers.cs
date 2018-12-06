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
    public partial class FrmPlayers : Form
    {
        int NbUserBase;
        int NbUserMax;

        public FrmPlayers(int NbUserBase, int NbUserMax)
        {
            InitializeComponent();

            this.NbUserBase = NbUserBase;
            this.NbUserMax = NbUserMax;

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

        public List<string> NamePlayer()
        {
            List<string> listNamePlayers = new List<string>();
            listNamePlayers.Add(txtNameUser1.Text);
            listNamePlayers.Add(txtNameUser2.Text);
            return listNamePlayers;
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

        public int NbUserVisible(int Checked)
        {
            int NbEnabled = 0;
            switch (Checked)
            {
                case 1: NbEnabled = 1; lblNewUser2.Visible = false; lblNewUser3.Visible = false; lblNewUser4.Visible = false; txtNameUser2.Visible = false; txtNameUser3.Visible = false; txtNameUser4.Visible = false; break; //ajouter l'affichage des labels
                case 2: NbEnabled = 2; lblNewUser2.Visible = true; lblNewUser3.Visible = false; lblNewUser4.Visible = false; txtNameUser2.Visible = true; txtNameUser3.Visible = false; txtNameUser4.Visible = false; break;
                case 3: NbEnabled = 3; lblNewUser2.Visible = true; lblNewUser3.Visible = true; lblNewUser4.Visible = false; txtNameUser2.Visible = true; txtNameUser3.Visible = true; txtNameUser4.Visible = false; break;
                case 4: NbEnabled = 4; lblNewUser2.Visible = true; lblNewUser3.Visible = true; lblNewUser4.Visible = true; txtNameUser2.Visible = true; txtNameUser3.Visible = true; txtNameUser4.Visible = true; break;
            }

            return NbEnabled;
        }

        private void cmdFinish_Click(object sender, EventArgs e)
        {
            bool Same = VerifyNamePlayers();
            switch (NbUserMax)
            {
                case 1: break; //Solitaire
                case 2:
                    if (NbUserMax == 2 && NbUserBase == 2)
                    {
                        if (txtNameUser1.Text != "" && txtNameUser2.Text != "")
                        {
                            this.Close();
                        }
                        else
                        {
                            if (Same)
                            {
                                MessageBox.Show("Vous devez mettre des noms dans les cases visible");
                            }
                        }
                    }
                    break; //Morpion
                case 3: break; //rien
                case 4: break; //bataille
            }
            
        }

        private bool VerifyNamePlayers()
        {
            List<string> NamePlayers = new List<string>();
            NamePlayers.Add(txtNameUser1.Text);
            NamePlayers.Add(txtNameUser2.Text);
            NamePlayers.Add(txtNameUser3.Text);
            NamePlayers.Add(txtNameUser4.Text);

            int NbNamePlayers = NamePlayers.Count();
            string Name1 = txtNameUser1.Text;
            string Name2 = txtNameUser2.Text;
            string Name3 = txtNameUser3.Text;
            string Name4 = txtNameUser4.Text;
            bool Same = false;

            if (Name2 == "")
            {
                Name2 = null;
                NbNamePlayers--;
            }
            if (Name3 == "")
            {
                Name3 = null;
                NbNamePlayers--;
            }
            if (Name4 == "")
            {
                Name4 = null;
                NbNamePlayers--;
            }

            switch (NbNamePlayers)
            {
                case 1: break;
                case 2: if (Name1 == Name2) { Same = true; } break;
                case 3: if (Name1 == Name2 || Name1 == Name3 || Name2 == Name3) { Same = true; } break;
                case 4: if (Name1 == Name2 || Name1 == Name3 || Name1 == Name4 || Name2 == Name3 || Name2 == Name4 || Name3 == Name4) { Same = true; } break;
            }

            if (Same)
            {
                MessageBox.Show("Vous de pouvez pas utiliser deux fois le même nom");
                txtNameUser1.Clear();
                txtNameUser2.Clear();
                txtNameUser3.Clear();
                txtNameUser4.Clear();
                Same = false;
            }
            else
            {
                Same = true;
            }
            return Same;
        }
    }
}
