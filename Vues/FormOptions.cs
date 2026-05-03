using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            this.Text = "Options du Jeu";
            this.Size = new Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 40);

            Label lblTitre = new Label { Text = "Taille de la grille :", ForeColor = Color.White, Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            this.Controls.Add(lblTitre);

            //  4x4
            RadioButton rb4x4 = new RadioButton { Text = "Classique : 4x4 (16 cartes)", ForeColor = Color.White, Location = new Point(30, 70), AutoSize = true };
            if (FormMenu.TailleGrilleChoisie == 16) rb4x4.Checked = true;
            this.Controls.Add(rb4x4);

            // 6x6
            RadioButton rb6x6 = new RadioButton { Text = "Difficile : 6x6 (36 cartes)", ForeColor = Color.White, Location = new Point(30, 110), AutoSize = true };
            if (FormMenu.TailleGrilleChoisie == 36) rb6x6.Checked = true;
            this.Controls.Add(rb6x6);

            Button btnValider = new Button { Text = "Valider", Location = new Point(85, 160), Size = new Size(100, 35), BackColor = Color.FromArgb(70, 130, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnValider.FlatAppearance.BorderSize = 0;
            btnValider.Click += (s, e) =>
            {
                FormMenu.TailleGrilleChoisie = rb6x6.Checked ? 36 : 16;
                this.Close();
            };
            this.Controls.Add(btnValider);
        }
    }
}