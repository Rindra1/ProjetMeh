using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Region
    {
        private int _IdRegion;
        private string _LibRegion;
        private int _IdProjet;

        
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
        
        public int IdRegion
        {
            get
            {
                return _IdRegion;
            }
            set
            {
                _IdRegion = value;
            }
        }

        public string LibRegion
        {
            get
            {
                return _LibRegion;
            }
            set
            {
                _LibRegion = value;
            }
        }
    }
}
