using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public partial class TaskBase
    {
        public MemoryBank Memories = new MemoryBank();
        delegate void presetTaskLookup(Action task);
        delegate void presetThinkLookup(Think task);
        Action Action { get; set; }
        Think Think { get; set; }
        public TaskBase this[int index]
        {
            get { return this[index]; }
            set 
            {
                this[index] = value;
            }
        }

        public Action FetchAction(int e)
        {
        # region bloat
            int[] nums= { 1 , 3 ,5 ,6, -2, 4};

            //method syntax
            var nummeth = nums.Where(x => (x % 2 == e)).OrderBy(x => x);
        
            var positiveNums = from n in nums
                               where n > 0
                               select n; // using linq u can select and order data from 
        // different data types and use them accordingly
            var acsPosNums = from n in nums // data 
                             orderby n ascending // sort/arg
                             select n; // selection
            string[] bmw = {"whef.", "omg", "Gud Car", "meh"};

            var cars = from v 
                   in bmw
                   group v 
                   by v.Substring(v.LastIndexOf('.'));

            foreach (var ec in cars)
            {
               Console.Writeline("Group Name = " + ec.Key);
               foreach (var ec in cars)
               {
                  Console.Writeline("\t" + ec);
               }
            }

            foreach (var vefer in acsPosNums)
            {
                Console.WriteLine(vefer);
            }
        #endregion

            return this[e].Action;
        }

        public Think FetchThought(int e)
        {
            return this[e].Think;
        }

        public Action grabPresetTaskList(int e)
        {
            Action[] tasks =
            {
                new Action() { idea = memoryThinkTank
                (e, ea: Memories), what = "Walk_Around", times = 1, /*(Action.thing.ACT)0*/},

            };
            Action[] actions = tasks.Where(s => s.times > 13).ToArray();

            String[] stall = tasks.Where(s => s.what == "still"|"stall"|"wait"|"processing"|" "|""|"waiting").FirstOrDefault();

            String doing = tasks.Where(s => s.times == 20).FirstOrDefault();
            
            List<Action> redundants;
            int redundaC;
            foreach(Action action in tasks)
            {
                redundants.Add(action);
                ++redundaC;
            }
            redundants.Clear();
            Console.WriteLine(redundaC + " : "+"redundancies cleared");
            return tasks[e];
        }

        public static Think memoryThinkTank(int e, MemoryBank ea)
        {
            return ea[e].e;
        }

        #region basic af funcions
        public static void Walk()
        {
            
        }
        #endregion
    }
}
