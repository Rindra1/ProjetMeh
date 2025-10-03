using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Correspondants
    {
        private int _IdCor;
        private int _IdDir;
        private int _IdService;
        private string _NomCor;
        private string _PrenomCor;
        private string _TelCor;
        private string _EmailCor;

        private Projets _Projets;
        private Comptes _Login;
        private Services _Service;
        



        public Services Service
        {
            get
            {
                return new Services();
            }
            set
            {
                _Service = value;
            }

        }

        

        public Projets Projets
        {
            get
            {
                return new Projets();
            }
            set
            {
                _Projets = value;
            }
        }

        public Comptes Login
        {
            get
            {
                return new Comptes();
            }
            set
            {
                _Login = value;
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

        public int IdService
        {
            get
            {
                return _IdService;
            }
            set
            {
                _IdService = value;
            }
        }

        public string NomCor
        {
            get
            {
                return _NomCor;
            }
            set
            {
                _NomCor = value;
            }
        }

        public string PrenomCor
        {
            get
            {
                return _PrenomCor;
            }
            set
            {
                _PrenomCor = value;
            }
        }

        public string TelCor
        {
            get
            {
                return _TelCor;
            }
            set
            {
                _TelCor = value;
            }
        }

        public string EmailCor
        {
            get
            {
                return _EmailCor;
            }
            set
            {
                _EmailCor = value;
            }
        }
    }
}
