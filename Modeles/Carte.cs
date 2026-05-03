using System;

namespace SecurIT_Memory.Modeles 
{
    public enum EtatCarte
    {
        Cachee,
        Revelee,
        Trouvee
    }

    public class Carte
    {
        private int _id;
        private string _cheminImage;
        private EtatCarte _etat;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CheminImage
        {
            get { return _cheminImage; }
            set { _cheminImage = value; }
        }

        public EtatCarte Etat
        {
            get { return _etat; }
            set { _etat = value; }
        }

        public Carte(int id, string cheminImage)
        {
            _id = id;
            _cheminImage = cheminImage; 
            _etat = EtatCarte.Cachee; 
        }
    }
}