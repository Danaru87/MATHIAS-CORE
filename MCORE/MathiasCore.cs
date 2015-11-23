using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCORE
{
    public class MathiasCore
    {
        private string user { get; set; }
        private string password { get; set; }

        public bool CONNECTED { get; set; }

        public MathiasCore()
        {
        }

        public bool Connect(string _login, string _password)
        {
            if (_login.Equals("matAdmin") && _password.Equals("m4t4dm!n"))
            {
                CONNECTED = true;
            }
            else { CONNECTED = false; }

            return CONNECTED;
        }



    }
}
