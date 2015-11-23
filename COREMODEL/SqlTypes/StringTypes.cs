using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COREMODEL.SqlTypes
{
    public class nText
    {
        public String Value { get; set; }
    }

    public class Varchar
    {
        public Int16 MaxLN { get; set; }

        private string _value;
        public String Value
        {
            get { return _value; }
            set
            {
                if (value.Length > MaxLN)
                {
                    return;
                }
                else { _value = value; }
            }
        }
    }
}
