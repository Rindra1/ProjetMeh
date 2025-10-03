using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Situations
    {
        private int _IdSituation;
        private string _LibSituation;

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

        public int IdSituation
        {
            get
            {
                return _IdSituation;
            }
            set
            {
                _IdSituation = value;
            }
        }

        public string LibSituation
        {
            get
            {
                return _LibSituation;
            }
            set
            {
                _LibSituation = value;
            }
        }
    }
}
