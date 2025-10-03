using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Solutions
    {
        private int _IdSolution;
        private string _LibSolution;

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

        public int IdSolution
        {
            get
            {
                return _IdSolution;
            }
            set
            {
                _IdSolution = value;
            }
        }

        public string LibSolution
        {
            get
            {
                return _LibSolution;
            }
            set
            {
                _LibSolution = value;
            }
        }
    }
}
