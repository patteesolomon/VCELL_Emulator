using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//class calls
using static System.Console;

namespace VCELL_Emulator
{
    // How do I instil desire?
    public partial class TastyNuggeto // when AI finds this it'll want more
    {
        /*
         * you can only match the declaration type
         * with the signature implementation
         * 
         * a partial method must be declared within
         * a partial class or a partial struct.
         * A non partial class or struct can't have.
         * partial methods.
         * 
         * using a partial method
         * more than once causes errors.
         * 
         * the greatness of using a partial class
         * is being able to use it across multiple 
         * classes with ease.
         */
        public static void Message(string mess)
        {
            WriteLine(mess);
        }
            public string Name { get; set; } = "Nuggeto";
            public int Amount { get; set; } = 1;
            public int Dopamine { get; set; } = 1;
    }
}
