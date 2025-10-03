using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Comptes
    {
        private int _IdLogin;
        private int _IdCor;
        private string _Pseudo;
        private string _Code;
        private string _Role;

        public string Role
        {
            get
            {
                return _Role;
            }
            set
            {
                _Role = value;
            }
        }

        public int IdLogin
        {
            get
            {
                return _IdLogin;
            }
            set
            {
                _IdLogin = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return _Pseudo;
            }
            set
            {
                _Pseudo = value;
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

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
    }
}
