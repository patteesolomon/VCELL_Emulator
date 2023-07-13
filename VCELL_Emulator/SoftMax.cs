using System.Collections;

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

        public double[] FindMax(int ie)
        {
            double me = (double)in1 + (double)in2 + (double)in3;
            ArrayList ec = new ArrayList();
            ec.Add(in1r);
            ec.Add(in2r);
            ec.Add(in3r);
            ArrayList stufs = new ArrayList();
            stufs.Add(in1);
            stufs.Add(in2);
            stufs.Add(in3);

            double iter1;
            double iter2;
            double iter3;
            ArrayList itrs = new ArrayList();

            for(int i = 0; ec.Count > i; i++)
            {
                foreach (double v2 in stufs)
                {
                    ec[i] = v2 / me;
                }
                itrs.Add(ec[i]);
            }
            return (double[])itrs[ie];
        }
    }
}