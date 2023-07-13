using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public class ActivationFunction
    {
        public static float Activation_function
            (bool i_derivative, float i_input)
        {
            if (false == i_derivative)
            {
                if (0 >= i_input)
                {
                    return (float)Math.Pow(2, i_input - 1);
                }
                else
                {
                    return (float)Math.Pow(2, -1 - i_input);
                }
            }
            else
            {
                if (0 >= i_input)
                {
                    return (float)((float)Math.Log(2) *
                        Math.Pow(2, i_input - 1));
                }
            }
            return 0;
        }
    }
}
