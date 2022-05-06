using System;
namespace VCELL_Emulator
{
    public class RelU
    {
        private double inputx;

        public RelU(double x)
        {
            relU(x);
        }

        public RelU(double x, double add)
        {
            relU(x + add);
        }

        public double GetInputx()
        {
            return inputx;
        }

        public void SetInputx(double value)
        {
            inputx = value;
        }

        double relU(double x)
        {
            return Math.Max(0, x);
        }
        ///
        /// derivative mode
        /// 0, 1
        /// sigmoid can do the rest for 
        /// the deep learning 
        /// or maybe something else
    }
}