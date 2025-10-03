using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Observations
    {
        private int _IdObs;
        private string _LibObs;

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

        public int IdObs
        {
            get
            {
                return _IdObs;
            }
            set
            {
                _IdObs = value;
            }
        }

        public string LibObs
        {
            get
            {
                return _LibObs;
            }
            set
            {
                _LibObs = value;
            }
        }
    }
}
