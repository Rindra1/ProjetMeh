using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class Services
    {
        private int _IdService;
        private int _IdDir;
        private string _LibService;
        private Correspondants _Correspondants;
        private List<Services> _ListeService;

        public List<Services> ListeService
        {
            get
            {
                return new List<Services>();
            }
            set
            {
                _ListeService = value;
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

        public string LibService
        {
            get
            {
                return _LibService;
            }
            set
            {
                _LibService = value;
            }
        }

        public Correspondants Correspondants
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
    }
}
