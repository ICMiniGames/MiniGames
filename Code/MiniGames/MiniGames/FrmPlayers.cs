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
        ConnectionDB connection = new ConnectionDB();
        int NbUserBase;
        int NbUserMax;
        public int NbNamePlayers;
        /// <summary>
        /// This constructor initializes a new instance of the form of Players.
        /// </summary>
        /// <param name="NbUserBase"></param>
        /// <param name="NbUserMax"></param>
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

        /// <summary>
        /// List of the names of the players who play the game.
        /// </summary>
        /// <returns></returns>
        public List<string> NamePlayer()
        {
            List<string> listNamePlayers = new List<string>();
            listNamePlayers.Add(txtNameUser1.Text);
            if (txtNameUser2.Text != "") { listNamePlayers.Add(txtNameUser2.Text); }
            if (txtNameUser3.Text != "") { listNamePlayers.Add(txtNameUser3.Text); }
            if (txtNameUser4.Text != "") { listNamePlayers.Add(txtNameUser4.Text); }
            return listNamePlayers;
        }

        /// <summary>
        /// Method to change the number of users when the radio button changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            NbUserVisible(Convert.ToInt16(control.Name.Substring(8)));
        }

        /// <summary>
        /// Method to display the number of users requested by the radio buttons.
        /// </summary>
        /// <param name="Checked"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Event for the confirmation button when we have finished entering the names of the players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFinish_Click(object sender, EventArgs e)
        {
            bool NotSame = true;
            bool Same = VerifyNamePlayers();
            switch (NbUserMax)
            {
                case 1:
                    if (txtNameUser1.Text != "")
                    {
                        AddPlayerDB();
                        this.Close();
                    }
                    else
                    {
                        if (Same)
                        {
                            MessageBox.Show("Vous devez mettre un nom dans la case visible");
                        }
                    }
                    break; //Solitaire
                case 2:
                    if (txtNameUser1.Text != "" && txtNameUser2.Text != "")
                    {
                        AddPlayerDB();
                        this.Close();
                    }
                    else
                    {
                        if (Same)
                        {
                            MessageBox.Show("Vous devez mettre des noms dans les cases visible");
                        }
                    }
                    break; //Morpion
                case 3: break; //rien
                case 4:
                    if (cmdrUser1.Checked)
                    {
                        if (txtNameUser1.Text != "")
                        {
                            NotSame = false;
                            AddPlayerDB();
                            this.Close();
                        }
                    }
                    if (cmdrUser2.Checked)
                    {
                        if (txtNameUser1.Text != "" && txtNameUser2.Text != "")
                        {
                            NotSame = false;
                            AddPlayerDB();
                            this.Close();
                        }
                    }
                    if (cmdrUser3.Checked)
                    {
                        if (txtNameUser1.Text != "" && txtNameUser2.Text != "" && txtNameUser3.Text != "")
                        {
                            NotSame = false;
                            AddPlayerDB();
                            this.Close();
                        }
                    }
                    if (cmdrUser4.Checked)
                    {
                        if (txtNameUser1.Text != "" && txtNameUser2.Text != "" && txtNameUser3.Text != "" && txtNameUser4.Text != "")
                        {
                            NotSame = false;
                            AddPlayerDB();
                            this.Close();
                        }
                    }
                    if (NotSame)
                    {
                        if (Same)
                        {
                            MessageBox.Show("Vous devez mettre des noms dans les cases visible");
                        }
                    }
                    


                    break; //bataille
            }
            
        }
        /// <summary>
        /// Check the names of the players for the games.
        /// </summary>
        /// <returns></returns>
        private bool VerifyNamePlayers()
        {
            List<string> NamePlayers = new List<string>();
            NamePlayers.Add(txtNameUser1.Text);
            NamePlayers.Add(txtNameUser2.Text);
            NamePlayers.Add(txtNameUser3.Text);
            NamePlayers.Add(txtNameUser4.Text);

            NbNamePlayers = NamePlayers.Count();
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

        private void AddPlayerDB()
        {
            if(txtNameUser1.Text != "")
            {
                connection.InsertPlayer(txtNameUser1.Text);
            }
            if (txtNameUser2.Text != "")
            {
                connection.InsertPlayer(txtNameUser2.Text);
            }
            if (txtNameUser3.Text != "")
            {
                connection.InsertPlayer(txtNameUser3.Text);
            }
            if (txtNameUser4.Text != "")
            {
                connection.InsertPlayer(txtNameUser4.Text);
            }
        }
    }
}
