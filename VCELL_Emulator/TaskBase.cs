//#define an

using System;
using System.Collections; // do this in order to use ArrayList
                          // and other cool things 
using System.Collections.Generic;
using System.Linq;


namespace VCELL_Emulator
{
    public partial class TaskBase
    {
        public MemoryBank Memories = new ();
        delegate void presetTaskLookup(Action task);
        delegate void presetThinkLookup(Think task);
        public Action EAction { get; set; }
        public Predicate<Action> ishappen;
        public Think Think { get; set; }
        public Action<int, Action> Calls
        { get => action; set => action = value; }
        public System.Action SysAction 
        { get => sysAction1; set => sysAction1 = value; }

        System.Action sysAction1;
        Action<int, Action> action; // arraylistdemo
        enum Thang
        {
            ACT,
            ATTACK,
            TALK,
            THINK,
            FEEL,
            HEAR,
            RECOG
        };
        public TaskBase this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }
        public static T TempA<T>(Func<T> action)
        {
            return action();
        }

        #if (true)
        #else
        #endif

        public Action FetchAction(int e)
        {
            #region bloat

            int[] nums = { 1, 3, 5, 6, -2, 4 };

            //method syntax
            var nummeth = nums.Where
                (x => (x % 2 == e)).OrderBy(x => x);

            var positiveNums = from n in nums
                               where n > 0
                               select n; // using linq u can select
                                         // and order data from 
                                         // different data types and
                                         // use them accordingly
            var acsPosNums = from n in nums // data 
                             orderby n ascending // sort/arg
                             select n; // selection
            string[] bmw = { "whef.", "omg", "Gud Car", "meh" };

            var cars = from v
                   in bmw
                       group v
                       by v.Substring(v.LastIndexOf('.'));

            foreach (var ec in cars)
            {
                Console.WriteLine("Group Name = " + ec.Key);
            }

            foreach (var vefer in acsPosNums)
            {
                Console.WriteLine(vefer);
            }

            var domeOfSins = from s in bmw
                             select new
                             {
                                 r = s[0],
                                 rName = s.ToString()
                             };
            #if (true)
            #endif


            #endregion

            return this[e].EAction;
        }

        public Think FetchThought(int e)
        {
            return this[e].Think;
        }

        public Action GrabPresetTaskList(int e)
        {
            List<Action> redundants = new ();
            int redundaC = 0;

            // presets
            Action[] tasks =
            {
                new Action(Think, "test", 1, sysAction1, Action.thing.ACT)
                {
                idea = MemoryThinkTank
                (e, ea: Memories), what = "Walk_Around", times = 1,
                //thang.ACT
                }
            };

            Action[] actions = tasks.Where
                (s => s.times > 13).ToArray();


            foreach (Action action in tasks)
            {
                redundants.Add(action);
                ++redundaC;
            }

            redundants.Clear();
            Console.WriteLine(redundaC + " : "
                + "redundancies cleared");
            return tasks[e]; // predicate delagate checks for
            // relevant data or criterion
        }

        public static Think MemoryThinkTank(int e, MemoryBank ea)
        {
            return ea.MemTup[e].thinke;
        }

        #region basic funcions
        public static void ArrayListDemo()
        {
            ArrayList arrayList = new()
            {
                "me"
            };

            arrayList.Insert(1, "efm");

            arrayList.Reverse();
            foreach (var j in arrayList)
            {
                Console.WriteLine(j);
            }
        }
        #endregion
    }
}
//#endif