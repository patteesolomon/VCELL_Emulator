using System;

namespace VCELL_Emulator
{
    class Program
    {
        static void Main()
        {
            #region Am's brain
            dynamic dynamicvar = 233;
            int? Coup = null;
            int ava = Coup ?? 0; // null coalescing operator
            Console.WriteLine("Val :", dynamicvar);
            Console.WriteLine(GetTime());
            var myAnnon = new
            {
                name = "thing",
                age = 2,
                currentVer = 6.0
            };
            AI Am = new ("Am", 8, false);

            int? iex = null; // nullable
            bool? ClearedGateExam = null;

            if (ClearedGateExam == true)
            {
                Console.WriteLine("User Cleared Gate Exam.");
            }
            else if (ClearedGateExam == false)
            {
                Console.WriteLine("User failed Gate Exam.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("User did not file.");
                Console.ResetColor();
            }
            #endregion

            Console.WriteLine("Hello World!");
        }
        public static string GetTime() => "Current Time : -" 
            + DateTime.Now.ToString("F") +"\n"
            + DateTime.Now.ToString("gg") +"\n"
            + DateTime.Now.ToString("G");
    }
}
