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
                (e, ea: Memories), what = "Walk_Around", times = 1},

            };
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
