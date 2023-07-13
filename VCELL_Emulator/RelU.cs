using System;
using System.Collections.Generic;

namespace VCELL_Emulator
{
    public class RelU
    {
        private double inputx;
        private double inputy;

        public RelU(double x)
        {
            TRelU(x);
        }

        public RelU(double x, double add)
        {
            TRelU(x + add);
        }

        public double GetInputx()
        {
            return inputx;
        }

        public double GetInputy()
        {
            return inputy;
        }

        public void SetInputx(double value)
        {
            inputx = value;
        }

        double TRelU(double x)
        {
            return Math.Max(0, x);
        }
        ///
        /// derivative mode
        /// 0, 1
        /// sigmoid can do the rest for 
        /// the deep learning 
        /// or maybe something else
        
        static int TRelUFunc(int x)
        {
            if (x > 0)
            {
                return x;
            }
            return 0; // - 1 ?
        }
    }
}