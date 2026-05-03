using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class FormMenu : Form
    {
        //taille de la grille 4x4 pour debuter
        public static int TailleGrilleChoisie = 16;

        public FormMenu()
        {
            InitializeComponent();
            InitialiserMenuVisuel();
        }


        private void InitialiserMenuVisuel()
        {
            this.Text = "SecurIT - Salon Tech";
            this.Size = new Size(400, 400);
            this.BackColor = Color.FromArgb(20, 20, 40);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitre = new Label();
            lblTitre.Text = "SecurIT Memory";
            lblTitre.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.AutoSize = true;
            lblTitre.Location = new Point(85, 40);
            lblTitre.Anchor = AnchorStyles.None; 
            this.Controls.Add(lblTitre);

            // bouton jouer
            Button btnJouer = new Button();
            btnJouer.Text = "Jouer";
            btnJouer.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnJouer.Size = new Size(200, 50);
            btnJouer.Location = new Point(100, 120); 
            btnJouer.Cursor = Cursors.Hand;
            btnJouer.BackColor = Color.FromArgb(70, 130, 180);
            btnJouer.ForeColor = Color.White;
            btnJouer.FlatStyle = FlatStyle.Flat;
            btnJouer.FlatAppearance.BorderSize = 0;
            btnJouer.Anchor = AnchorStyles.None; 
            btnJouer.Click += BtnJouer_Click;
            this.Controls.Add(btnJouer);

            // bouton options
            Button btnOptions = new Button();
            btnOptions.Text = "Options";
            btnOptions.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnOptions.Size = new Size(200, 50);
            btnOptions.Location = new Point(100, 190);
            btnOptions.Cursor = Cursors.Hand;
            btnOptions.BackColor = Color.FromArgb(70, 130, 180);
            btnOptions.ForeColor = Color.White;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.Anchor = AnchorStyles.None;
            btnOptions.Click += BtnOptions_Click;
            this.Controls.Add(btnOptions);

            // bouton quitter
            Button btnQuitter = new Button();
            btnQuitter.Text = "Quitter";
            btnQuitter.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnQuitter.Size = new Size(200, 50);
            btnQuitter.Location = new Point(100, 260);
            btnQuitter.Cursor = Cursors.Hand;
            btnQuitter.BackColor = Color.FromArgb(178, 34, 34);
            btnQuitter.ForeColor = Color.White;
            btnQuitter.FlatStyle = FlatStyle.Flat;
            btnQuitter.FlatAppearance.BorderSize = 0;
            btnQuitter.Anchor = AnchorStyles.None;
            btnQuitter.Click += BtnQuitter_Click;
            this.Controls.Add(btnQuitter);
        }

        private void BtnJouer_Click(object sender, EventArgs e)
        {
            FormJeu fenetreJeu = new FormJeu();
            fenetreJeu.Show();
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            FormOptions fenetreOptions = new FormOptions();
            fenetreOptions.ShowDialog(); // sa bloque le menu si option es ouvert
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
