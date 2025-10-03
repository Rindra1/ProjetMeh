using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Entites
    {
        private int _IdEntite;
        private string _LibEntite;

        private Directions _Directions;

        public int IdEntite
        {
            get
            {
                return _IdEntite;
            }
            set
            {
                _IdEntite = value;
            }
        }

        public string LibEntite
        {
            get
            {
                return _LibEntite;
            }
            set
            {
                _LibEntite = value;
            }
        }

        public Directions Directions
        {
            get
            {
                return new Directions();
            }
            set
            {
                _Directions = value;
            }
        }
    }
}
