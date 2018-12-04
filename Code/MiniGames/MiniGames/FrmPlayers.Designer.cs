namespace MiniGames
{
    partial class FrmPlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlayers));
            this.txtNameUser1 = new System.Windows.Forms.TextBox();
            this.txtNameUser4 = new System.Windows.Forms.TextBox();
            this.cmdrUser4 = new System.Windows.Forms.RadioButton();
            this.cmdrUser1 = new System.Windows.Forms.RadioButton();
            this.cmdrUser2 = new System.Windows.Forms.RadioButton();
            this.cmdrUser3 = new System.Windows.Forms.RadioButton();
            this.gpbNbUsers = new System.Windows.Forms.GroupBox();
            this.lblNewUser1 = new System.Windows.Forms.Label();
            this.txtNameUser3 = new System.Windows.Forms.TextBox();
            this.txtNameUser2 = new System.Windows.Forms.TextBox();
            this.lblNewUser4 = new System.Windows.Forms.Label();
            this.lblNewUser3 = new System.Windows.Forms.Label();
            this.lblNewUser2 = new System.Windows.Forms.Label();
            this.cmdFinish = new System.Windows.Forms.Button();
            this.gpbNbUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNameUser1
            // 
            this.txtNameUser1.Location = new System.Drawing.Point(12, 28);
            this.txtNameUser1.Name = "txtNameUser1";
            this.txtNameUser1.Size = new System.Drawing.Size(137, 20);
            this.txtNameUser1.TabIndex = 0;
            // 
            // txtNameUser4
            // 
            this.txtNameUser4.Location = new System.Drawing.Point(12, 159);
            this.txtNameUser4.Name = "txtNameUser4";
            this.txtNameUser4.Size = new System.Drawing.Size(137, 20);
            this.txtNameUser4.TabIndex = 1;
            this.txtNameUser4.Visible = false;
            // 
            // cmdrUser4
            // 
            this.cmdrUser4.AutoSize = true;
            this.cmdrUser4.Enabled = false;
            this.cmdrUser4.Location = new System.Drawing.Point(6, 88);
            this.cmdrUser4.Name = "cmdrUser4";
            this.cmdrUser4.Size = new System.Drawing.Size(83, 17);
            this.cmdrUser4.TabIndex = 4;
            this.cmdrUser4.Text = "4 utilisateurs";
            this.cmdrUser4.UseVisualStyleBackColor = true;
            this.cmdrUser4.CheckedChanged += new System.EventHandler(this.cmdrUser4_CheckedChanged_1);
            // 
            // cmdrUser1
            // 
            this.cmdrUser1.AutoSize = true;
            this.cmdrUser1.Enabled = false;
            this.cmdrUser1.Location = new System.Drawing.Point(6, 19);
            this.cmdrUser1.Name = "cmdrUser1";
            this.cmdrUser1.Size = new System.Drawing.Size(78, 17);
            this.cmdrUser1.TabIndex = 5;
            this.cmdrUser1.Text = "1 utilisateur";
            this.cmdrUser1.UseVisualStyleBackColor = true;
            this.cmdrUser1.CheckedChanged += new System.EventHandler(this.cmdrUser1_CheckedChanged);
            // 
            // cmdrUser2
            // 
            this.cmdrUser2.AutoSize = true;
            this.cmdrUser2.Enabled = false;
            this.cmdrUser2.Location = new System.Drawing.Point(6, 42);
            this.cmdrUser2.Name = "cmdrUser2";
            this.cmdrUser2.Size = new System.Drawing.Size(83, 17);
            this.cmdrUser2.TabIndex = 6;
            this.cmdrUser2.Text = "2 utilisateurs";
            this.cmdrUser2.UseVisualStyleBackColor = true;
            this.cmdrUser2.CheckedChanged += new System.EventHandler(this.cmdrUser2_CheckedChanged_1);
            // 
            // cmdrUser3
            // 
            this.cmdrUser3.AutoSize = true;
            this.cmdrUser3.Enabled = false;
            this.cmdrUser3.Location = new System.Drawing.Point(6, 65);
            this.cmdrUser3.Name = "cmdrUser3";
            this.cmdrUser3.Size = new System.Drawing.Size(83, 17);
            this.cmdrUser3.TabIndex = 7;
            this.cmdrUser3.Text = "3 utilisateurs";
            this.cmdrUser3.UseVisualStyleBackColor = true;
            this.cmdrUser3.CheckedChanged += new System.EventHandler(this.cmdrUser3_CheckedChanged_1);
            // 
            // gpbNbUsers
            // 
            this.gpbNbUsers.Controls.Add(this.cmdrUser1);
            this.gpbNbUsers.Controls.Add(this.cmdrUser4);
            this.gpbNbUsers.Controls.Add(this.cmdrUser3);
            this.gpbNbUsers.Controls.Add(this.cmdrUser2);
            this.gpbNbUsers.Location = new System.Drawing.Point(250, 26);
            this.gpbNbUsers.Name = "gpbNbUsers";
            this.gpbNbUsers.Size = new System.Drawing.Size(135, 111);
            this.gpbNbUsers.TabIndex = 8;
            this.gpbNbUsers.TabStop = false;
            this.gpbNbUsers.Text = "nombre d\'utilisateurs";
            // 
            // lblNewUser1
            // 
            this.lblNewUser1.AutoSize = true;
            this.lblNewUser1.Location = new System.Drawing.Point(12, 9);
            this.lblNewUser1.Name = "lblNewUser1";
            this.lblNewUser1.Size = new System.Drawing.Size(62, 13);
            this.lblNewUser1.TabIndex = 9;
            this.lblNewUser1.Text = "Utilisateur 1";
            // 
            // txtNameUser3
            // 
            this.txtNameUser3.Location = new System.Drawing.Point(12, 114);
            this.txtNameUser3.Name = "txtNameUser3";
            this.txtNameUser3.Size = new System.Drawing.Size(137, 20);
            this.txtNameUser3.TabIndex = 2;
            this.txtNameUser3.Visible = false;
            // 
            // txtNameUser2
            // 
            this.txtNameUser2.Location = new System.Drawing.Point(12, 72);
            this.txtNameUser2.Name = "txtNameUser2";
            this.txtNameUser2.Size = new System.Drawing.Size(137, 20);
            this.txtNameUser2.TabIndex = 3;
            this.txtNameUser2.Visible = false;
            // 
            // lblNewUser4
            // 
            this.lblNewUser4.AutoSize = true;
            this.lblNewUser4.Location = new System.Drawing.Point(12, 143);
            this.lblNewUser4.Name = "lblNewUser4";
            this.lblNewUser4.Size = new System.Drawing.Size(62, 13);
            this.lblNewUser4.TabIndex = 10;
            this.lblNewUser4.Text = "Utilisateur 4";
            this.lblNewUser4.Visible = false;
            // 
            // lblNewUser3
            // 
            this.lblNewUser3.AutoSize = true;
            this.lblNewUser3.Location = new System.Drawing.Point(12, 98);
            this.lblNewUser3.Name = "lblNewUser3";
            this.lblNewUser3.Size = new System.Drawing.Size(62, 13);
            this.lblNewUser3.TabIndex = 11;
            this.lblNewUser3.Text = "Utilisateur 3";
            this.lblNewUser3.Visible = false;
            // 
            // lblNewUser2
            // 
            this.lblNewUser2.AutoSize = true;
            this.lblNewUser2.Location = new System.Drawing.Point(12, 56);
            this.lblNewUser2.Name = "lblNewUser2";
            this.lblNewUser2.Size = new System.Drawing.Size(62, 13);
            this.lblNewUser2.TabIndex = 12;
            this.lblNewUser2.Text = "Utilisateur 2";
            this.lblNewUser2.Visible = false;
            // 
            // cmdFinish
            // 
            this.cmdFinish.Location = new System.Drawing.Point(250, 146);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(135, 33);
            this.cmdFinish.TabIndex = 13;
            this.cmdFinish.Text = "Confirmer";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // FrmPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 191);
            this.ControlBox = false;
            this.Controls.Add(this.cmdFinish);
            this.Controls.Add(this.lblNewUser2);
            this.Controls.Add(this.lblNewUser3);
            this.Controls.Add(this.lblNewUser4);
            this.Controls.Add(this.lblNewUser1);
            this.Controls.Add(this.gpbNbUsers);
            this.Controls.Add(this.txtNameUser2);
            this.Controls.Add(this.txtNameUser3);
            this.Controls.Add(this.txtNameUser4);
            this.Controls.Add(this.txtNameUser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPlayers";
            this.Text = "Player";
            this.gpbNbUsers.ResumeLayout(false);
            this.gpbNbUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameUser1;
        private System.Windows.Forms.TextBox txtNameUser4;
        private System.Windows.Forms.RadioButton cmdrUser4;
        private System.Windows.Forms.RadioButton cmdrUser1;
        private System.Windows.Forms.RadioButton cmdrUser2;
        private System.Windows.Forms.RadioButton cmdrUser3;
        private System.Windows.Forms.GroupBox gpbNbUsers;
        private System.Windows.Forms.Label lblNewUser1;
        private System.Windows.Forms.TextBox txtNameUser3;
        private System.Windows.Forms.TextBox txtNameUser2;
        private System.Windows.Forms.Label lblNewUser4;
        private System.Windows.Forms.Label lblNewUser3;
        private System.Windows.Forms.Label lblNewUser2;
        private System.Windows.Forms.Button cmdFinish;
    }
}