using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro
{
    class Jugador
    {
        private string dIP;
        private bool car;
        public Jugador(string ip, bool tipoCarro )
        {            
            dIP = ip;
            car = tipoCarro;
        }
        public string dirIP
        {
            get { return dIP; }
            set { }
        }
    }
}
