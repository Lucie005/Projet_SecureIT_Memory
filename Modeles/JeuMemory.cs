using System;
using System.Collections.Generic;

namespace SecurIT_Memory.Modeles
{
    public class JeuMemory
    {
        public List<Carte> Cartes { get; private set; }
        public int NbEssais { get; private set; } // Ajout du compteur d'essais

        public JeuMemory()
        {
            Cartes = new List<Carte>();
            NbEssais = 0;
        }

        public void InitialiserJeu(List<string> cheminsImages)
        {
            Cartes.Clear();
            NbEssais = 0; // Réinitialisation des essais
            int id = 0;

            foreach (string chemin in cheminsImages)
            {
                Cartes.Add(new Carte(id, chemin));
                Cartes.Add(new Carte(id, chemin));
                id++;
            }

            MelangerCartes();
        }

        private void MelangerCartes()
        {
            Random rng = new Random();
            int n = Cartes.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte value = Cartes[k];
                Cartes[k] = Cartes[n];
                Cartes[n] = value;
            }
        }

        // --- LOGIQUE DE JEU ---

        // Évalue si les deux cartes sont identiques
        public bool EvaluerPaire(Carte c1, Carte c2)
        {
            NbEssais++;

            if (c1.CheminImage == c2.CheminImage)
            {
                c1.Etat = EtatCarte.Trouvee;
                c2.Etat = EtatCarte.Trouvee;
                return true;
            }
            return false;
        }

        // Vérifie si toutes les cartes sont trouvées
        public bool VerifierVictoire()
        {
            return Cartes.TrueForAll(c => c.Etat == EtatCarte.Trouvee);
        }
    }
}