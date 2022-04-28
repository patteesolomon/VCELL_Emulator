using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public class MemoryBank
    {
        public Action m;
        public Think e;
        public MemoryBank this[int e]
        {
            get { return this[e]; }
            set { this[e] = value; }
        }
    }
}
