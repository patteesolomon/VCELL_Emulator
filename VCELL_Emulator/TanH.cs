using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    /// <summary>
    /// HyperBolic Tangent function
    /// : Use this to calculate the sprite 
    /// barrier of relevance
    /// </summary>
    internal class TanH
    {
        // h stands for iterations(highlights)
        // i is input
        // n is memory input
        // offx and y are from memory too
        // memory input = ?
        public TanH(int x,
            int y, int h, float n,
            int offx, int offy)
        {
            Calc(x,
             y,  h,  n,
             offx,  offy);
        }

        public static float Calc(int x, 
            int y, int h, float n, 
            int offx, int offy) => 
            (float)Math.Sin((double)
                (y + offy ^ h) - 
                (y + offy ^ h) / 
                n - (x + offx ^ h) + 
                (x + offx ^ h));
    }
}
