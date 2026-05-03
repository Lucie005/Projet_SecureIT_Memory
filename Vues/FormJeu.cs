using SecurIT_Memory.Modeles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class FormJeu : Form
    {
        private JeuMemory _jeu;
        private PictureBox _premiereCarteCliquee;
        private PictureBox _secondeCarteCliquee;

        private Timer _timerDelai;
        private Timer _timerChrono;
        private int _tempsEcoule;

        private FlowLayoutPanel _panneauGrille;
        private Label _lblChrono;
        private Label _lblEssais;

        public FormJeu()
        {
            InitializeComponent();
            InitialiserComposantsManuellement();
            DemarrerNouvellePartie();
        }

        private void InitialiserComposantsManuellement()
        {
            this.Text = "SecurIT - Mission Memory";
            this.Size = new Size(600, 700);
            this.BackColor = Color.FromArgb(20, 20, 40);

            _lblChrono = new Label { Text = "Temps : 0s", ForeColor = Color.White, Location = new Point(20, 20), AutoSize = true };
            this.Controls.Add(_lblChrono);

            _lblEssais = new Label { Text = "Essais : 0", ForeColor = Color.White, Location = new Point(150, 20), AutoSize = true };
            this.Controls.Add(_lblEssais);

            _panneauGrille = new FlowLayoutPanel
            {
                Location = new Point(20, 60),
                Size = new Size(500, 550),
                AutoSize = false,
                WrapContents = true
            };
            this.Controls.Add(_panneauGrille);

            _timerDelai = new Timer { Interval = 1000 };
            _timerDelai.Tick += TimerDelai_Tick;

            _timerChrono = new Timer { Interval = 1000 };
            _timerChrono.Tick += (s, e) => { _tempsEcoule++; _lblChrono.Text = $"Temps : {_tempsEcoule}s"; };
        }

        private void DemarrerNouvellePartie()
        {
            _jeu = new JeuMemory();
            _tempsEcoule = 0;
            _lblEssais.Text = "Essais : 0"; // Remise à zéro de l'affichage

            List<string> toutesLesImages = new List<string>
            { "virus.png", "pare-feu.png", "crypto.png", "cadenas.png", "shield.png", "cloud.png", "hacker.png" };

            List<string> imagesAUtiliser = new List<string>();

            if (toutesLesImages.Count > 0)
            {
                int nbPaires = FormMenu.TailleGrilleChoisie / 2;

                for (int i = 0; i < nbPaires; i++)
                {
                    imagesAUtiliser.Add(toutesLesImages[i % toutesLesImages.Count]);
                }
            }

            _jeu.InitialiserJeu(imagesAUtiliser);
            GenererGrilleVisuelle();
            _timerChrono.Start();
        }

        private void GenererGrilleVisuelle()
        {
            _panneauGrille.Controls.Clear();

            int tailleCarte = (FormMenu.TailleGrilleChoisie == 36) ? 75 : 100;

            foreach (var carte in _jeu.Cartes)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(tailleCarte, tailleCarte),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile("Ressources/back.png"),
                    Tag = carte,
                    Cursor = Cursors.Hand,
                    BorderStyle = BorderStyle.FixedSingle
                };
                pb.Click += Carte_Click;
                _panneauGrille.Controls.Add(pb);
            }
        }

        private void Carte_Click(object sender, EventArgs e)
        {
            if (_timerDelai.Enabled) return;

            PictureBox pbCliquee = sender as PictureBox;
            Carte carteAssociee = pbCliquee.Tag as Carte;

            if (carteAssociee.Etat != EtatCarte.Cachee) return;

            new SoundPlayer("Ressources/clic.wav").Play();

            carteAssociee.Etat = EtatCarte.Revelee;
            pbCliquee.Image = Image.FromFile("Ressources/" + carteAssociee.CheminImage);

            if (_premiereCarteCliquee == null)
            {
                _premiereCarteCliquee = pbCliquee;
            }
            else
            {
                _secondeCarteCliquee = pbCliquee;
                VerifierPaire();
            }
        }

        private void VerifierPaire()
        {
            Carte c1 = _premiereCarteCliquee.Tag as Carte;
            Carte c2 = _secondeCarteCliquee.Tag as Carte;

            // Appel de la logique depuis le modèle JeuMemory
            bool paireTrouvee = _jeu.EvaluerPaire(c1, c2);

            // Mise à jour de l'affichage avec la donnée du modèle
            _lblEssais.Text = $"Essais : {_jeu.NbEssais}";

            if (paireTrouvee)
            {
                _premiereCarteCliquee = null;
                _secondeCarteCliquee = null;
                VerifierVictoire();
            }
            else
            {
                _timerDelai.Start();
            }
        }

        private void TimerDelai_Tick(object sender, EventArgs e)
        {
            _timerDelai.Stop();

            Carte c1 = _premiereCarteCliquee.Tag as Carte;
            Carte c2 = _secondeCarteCliquee.Tag as Carte;

            c1.Etat = EtatCarte.Cachee;
            c2.Etat = EtatCarte.Cachee;

            _premiereCarteCliquee.Image = Image.FromFile("Ressources/back.png");
            _secondeCarteCliquee.Image = Image.FromFile("Ressources/back.png");

            _premiereCarteCliquee = null;
            _secondeCarteCliquee = null;
        }

        private void VerifierVictoire()
        {
            // Appel de la logique depuis le modèle
            if (_jeu.VerifierVictoire())
            {
                _timerChrono.Stop();
                new SoundPlayer("Ressources/victoire.wav").Play();
                MessageBox.Show($"Félicitations Agent SecurIT !\nTemps : {_tempsEcoule}s\nEssais : {_jeu.NbEssais}", "Victoire !");
                this.Close();
            }
        }
    }
}