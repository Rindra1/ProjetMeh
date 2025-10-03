using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class District
    {
        private int _IdDistrict;
        private string _LibDistrict;
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

        public int IdDistrict
        {
            get
            {
                return _IdDistrict;
            }
            set
            {
                _IdDistrict = value;
            }
        }

        public string LibDistrict
        {
            get
            {
                return _LibDistrict;
            }
            set
            {
                _LibDistrict = value;
            }
        }
    }
}
