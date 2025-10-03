using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Projets
    {
        private int _IdProjet;
        private int _IdCor;
        private int _IdEnr;
        private string _Numero;
        private string _Titre;
        private string _Promoteur;
        private string _Source;
        private string _Type;
        private string _Capacite;
        private string _Test;

        public string Test 
        {
            get
            {
                return _Test;
            }
            set
            {
                _Test = value;
            }
        }


        public int IdEnr
        {
            get
            {
                return _IdEnr;
            }
            set
            {
                _IdEnr = value;
            }
        }

        public string Capacite
        {
            get
            {
                return _Capacite;
            }
            set
            {
                _Capacite = value;
            }
        }
        
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public string Promoteur
        {
            get
            {
                return _Promoteur;
            }
            set
            {
                _Promoteur = value;
            }
        }

        public string Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                _Numero = value;
            }
        }

        public string Titre
        {
            get
            {
                return _Titre;
            }
            set
            {
                _Titre = value;
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

        public int IdCor
        {
            get
            {
                return _IdCor;
            }
            set
            {
                _IdCor = value;
            }
        }
    }
}
