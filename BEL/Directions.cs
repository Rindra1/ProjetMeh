using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Directions
    {
        private int _IdDir;
        private string _LibDir;
        private int _IdEntite;
        private Services _Services;
        private Correspondants _Correspondants;
        
        

        public Correspondants Correspondant
        {
            get
            {
                return new Correspondants();
            }
            set
            {
                _Correspondants = value;
            }
        }

        public int IdDir
        {
            get
            {
                return _IdDir;
            }
            set
            {
                _IdDir = value;
            }
        }
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

        public string LibDir
        {
            get
            {
                return _LibDir;
            }
            set
            {
                _LibDir = value;
            }
        }

        public Services Services
        {
            get
            {
                return new Services();
            }
            set
            {
                _Services = value;
            }
        }
       
    }
}
