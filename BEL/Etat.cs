using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Etat
    {
        private int _IdEtat;
        private string _LibEtat;

        private Etapes _Etapes;

        public Etapes Etapes
        {
            get
            {
                return new Etapes();
            }
            set
            {
                _Etapes = value;
            }
        }

        public int IdEtat
        {
            get
            {
                return _IdEtat;
            }
            set
            {
                _IdEtat = value;
            }
        }

        public string LibEtat
        {
            get
            {
                return _LibEtat;
            }
            set
            {
                _LibEtat = value;
            }
        }
    }
}
