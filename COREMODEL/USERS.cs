using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COREMODEL
{
    public enum State { DISCONNECTED, CONNECTED }
    public class USERS
    {
        public String FIRSTNAME { get; set; }
        public String LASTNAME { get; set; }
        public String USERNAME { get; set; }
        public String PASSWD { get; set; }

        public Int32 ID { get { return _id; } }
        
        public State STATE { get { return _state; } }

        private State _state { get; set; }
        private Int32 _id { get; set; }
    }
}
