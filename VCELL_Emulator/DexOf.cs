using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    /// <summary>
    /// input, output, data saved from 
    /// lmem.json file, so on...
    /// </summary>
    public partial class DexOf
    {
        private VNode inMind;
        private VNode inMindC;
        private VNode inMindP;
        private LinkedList<VNode> varr;
        
        public VNode this[int index]
        {
            get
            {
                return Varr.ElementAt(index);
            }
            set
            {
                // currentN
                inMindC = Varr.ElementAt(index).
                    GetNext().next;

                inMind = Varr.ElementAt(index).next;

                // desired legs prev
                inMindP = Varr.ElementAt(index);

                //set
                Varr.ElementAt(index).SetNext(value);

                Varr.ElementAt(index).previous = inMindP;

                Varr.ElementAt(index).GetNext().next = inMindC;

                // element prev
                Varr.ElementAt(index).
                    previous.DeleteNode();
            }
        }

        public String this[string namev, int index]
        {
            get 
            { 
                return Varr.ToList().ElementAt(index).name; 
            }
            set 
            {
                Varr.ToList().ElementAt(index).name = namev;
            }
        }

        public VNode InMind { get => inMind; set => inMind = value; }
        public LinkedList<VNode> Varr { get => varr; set => varr = value; }
    }
}
