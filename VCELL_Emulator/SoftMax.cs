using System;
using System.Collections;
using System.Linq;

namespace VCELL_Emulator
{
    public class SoftMax
    {
        public double in1 = 0;
        public double in2 = 0;
        public double in3 = 0;

        public double in1r = 0;
        public double in2r = 0;
        public double in3r = 0;

        public double findMax()
        {
            int me = in1 + in2 + in3;
            ArrayList ec = new ArrayList();
            ec.Add(in1r);
            ec.Add(in2r);
            ec.Add(in3r);
            ArrayList stufs = new ArrayList();
            stufs.Add(in1);
            stufs.Add(in2);
            stufs.Add(in3);

            foreach(var v in ec)
            {
                foreach(var v2 in stufs)
                v = v2 / me;
            }
        }
    }
}