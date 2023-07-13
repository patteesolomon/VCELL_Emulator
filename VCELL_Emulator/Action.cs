
using System;
using System.Linq;
using System.Reflection;

namespace VCELL_Emulator
{
    ///
    /// <Summary>
    /// keeping it basic for now. ill add a task search
    /// so it can pull from a list of stuff that'll
    /// find a proper action to take...
    /// </Summary>
    /// 
    public class Action 
    {
        public Think idea;
        public string what;
        public int times;
        private System.Action sAction;
        private thing thingg;
        public System.Action SAction { get => sAction; set => sAction = value; }
        public thing Thingg { get => thingg; set => thingg = value; }
        public int TypeOfThing { get; private set; }
        public bool Ru { get; private set; }

        public enum thing  
        {
            ACT,
            ATTACK,
            TALK,
            THINK,
            FEEL,  //=>// aparatus operandi
            HEAR,
            RECOG // refers to the cognative processes and calls
                   // anything related to relevent data. eg. answers, solutions
                   // related processes of cognition. eg.
                   // Philisophical: "The meaning of life."
        };

    // this only works off of a prompt..
        string[] BadDeeds = { "kill", "rape", "murder", "steal", "cuck", "cheat", "harm", "Attack", "Torture"};

        public Action(Think id, string wha, int times, System.Action a, thing g)
        {
            
            for (int i = 0; i < BadDeeds.Length; i++)
            { 
                if (!SAction.GetMethodInfo().IsDefined(Thingg.GetType(), Ru)
                    && TypeOfThing == 0 || TypeOfThing == 1 && Ru == true &&
                    SAction.GetMethodInfo().Name == BadDeeds[i])
                {
                    idea = id;
                    what = wha;
                    this.times = times;
                    SAction = a;
                    thingg = g;
                    Thingg = (thing)TypeOfThing;
                }
            }
        }
    }
}
