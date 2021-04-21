using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3_QLSV3Layer
{
    class CBBItems
    {
        public int Value { get; set; }
        public String Text { get; set; }
        public override String  ToString()
        {
            return Text;
        }
    }
}
