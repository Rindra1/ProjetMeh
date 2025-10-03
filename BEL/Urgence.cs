using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Urgence
    {
        private int _IdUrgence;
        private string _LibUrgence;

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

        public int IdUrgence
        {
            get
            {
                return _IdUrgence;
            }
            set
            {
                _IdUrgence = value;
            }
        }

        public string LibUrgence
        {
            get
            {
                return _LibUrgence;
            }
            set
            {
                _LibUrgence = value;
            }
        }
    }
}
