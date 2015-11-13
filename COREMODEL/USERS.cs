using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COREMODEL
{

    public class USERS
    {
        public String FIRSTNAME { get; set; }
        public String LASTNAME { get; set; }
        public String USERNAME { get; set; }
        public String PASSWD { get; set; }

        public Int64 ID { get { return _id; } }

        public State STATE { get { return _state; } }

        private State _state { get; set; }
        private Int64 _id { get; set; }
    }
}
