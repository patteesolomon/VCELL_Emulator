using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public class LVQ
    {
        short w1;
        short w2;
        short b1;
        short b2;

         int[][][]
            [][][]
            [][][] x;

        int [] y;

        int j = 0;

        // consider using data set models later on to influence
        // the input vectors and variables
        public static double W(double [][]Weights, double []Sample)
        {
            int D0 = 0;
            int D1 = 0;

            for (int i = 0; i <= Sample.Length; i++)
            {
                D0 += (int)Math.Pow(Sample[i] 
                    - Weights[0][i], 2);
                D1 += (int)Math.Pow(Sample[i] 
                    - Weights[1][i], 2);
            }

            if (D0 > D1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static void Update(double [][] Weights,
            double[] Sample, int J,
            int Alpha, int actual)
        {
            if(actual < J)
            {
                for (int i = 0; i < Weights.Length; i++)
                {
                     Weights[J][i] = Weights[J][i] + 
                        Alpha * (Sample[i] - Weights[J][i]);
                }
            }
            else
            {
                for (int i = 0; i < Weights.Length; i++)
                {
                     Weights[J][i] = Weights[J][i] - 
                        Alpha * (Sample[i] - Weights[J][i]);
                }
            }
        }

    }
}
