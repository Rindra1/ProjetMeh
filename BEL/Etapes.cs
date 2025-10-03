using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Etapes
    {
        private int _IdEtape;
        private int _IdProjet;
        private string _LibEtape;
        private string _Urgence;
        private string _Obs;
        private string _Solution;
        private string _Situation;
        private string _Contrainte;
        private string _Etat;
        private string _Debut;
        private string _Fin;

        public string Debut
        {
            get
            {
                return _Debut;
            }
            set
            {
                _Debut = value;
            }
        }

        public string Situation
        {
            get
            {
                return _Situation;
            }
            set
            {
                _Situation = value;
            }
        }


        public string Fin
        {
            get
            {
                return _Fin;
            }
            set
            {
                _Fin = value;
            }
        }
        public int IdEtape
        {
            get
            {
                return _IdEtape;
            }
            set
            {
                _IdEtape = value;
            }
        }

        public string Urgence
        {
            get
            {
                return _Urgence;
            }
            set
            {
                _Urgence = value;
            }
        }

        public string Solution
        {
            get
            {
                return _Solution;
            }
            set
            {
                _Solution = value;
            }
        }

        public int IdProjet
        {
            get
            {
                return _IdProjet;
            }
            set
            {
                _IdProjet = value;
            }
        }

        public string Obs
        {
            get
            {
                return _Obs;
            }
            set
            {
                _Obs = value;
            }
        }

        public string Etat
        {
            get
            {
                return _Etat;
            }
            set
            {
                _Etat = value;
            }
        }

        public string Contrainte
        {
            get
            {
                return _Contrainte;
            }
            set
            {
                _Contrainte = value;
            }
        }

        public string LibEtape
        {
            get
            {
                return _LibEtape;
            }
            set
            {
                _LibEtape = value;
            }
        }
    }
}
