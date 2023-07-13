using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VCELL_Emulator
{
    partial class AI : VCELL
    {
        #region properties
        readonly bool meal; // good des, or bad des
        string name; // name of AI
        bool alive; // alive or dead
        int priorityLvl; // importance of task
        //VCELL AVCELL = new(); // Cpy?
        Type typeChek = typeof(DoThought);
        // self identitiy Influencers
        Id id = new();
        Ego ego = new();
        // 

        private VNode[] AddedNodes 
            = Array.Empty<VNode>(); // put stuff in here or in the constructor
        Stack<Action> tasks;
        private List<Action> savedActions;
        private List<Action> tempActions;
        Stack<Think> thoughts;
        MemoryBank MemoryBank;
        //public MemoryBank Memories =
        //new MemoryBank();
        //this will exist inside TaskBase

        delegate void VNodeDelegate(VNode vNodeD);
        public string Name { get => name; 
            set => name = value; }
        public bool Alive { get => alive;
            set => alive = value; }
        public int PriorityLvl { get => priorityLvl; 
            set => priorityLvl = value; }
        public VNode[] AddedNodes1 { get => AddedNodes;
            set => AddedNodes = value; }
        public Type Typey { get; set; }

        public bool Meal => meal;

        internal Id Id { get => id;
            set => id = value; }
        internal Ego Ego { get => ego;
            set => ego = value; }

        public Type GetTypeChek()
        {
            //Typey = Type.GetType("ass");
            return typeChek;
        }

        public void SetTypeChek(Type value)
        {
            typeChek = value;
        }

        public delegate void DoTask();
        public delegate void DoThought();
        //crafted delagate
        public delegate void InAction(Think Thought, Action action);
        #endregion

        public AI(string Inin, int NodesAdd, bool Active)
        {
            DoThought doThought = new(ActivateLoop);
            Name = Inin;
            // VCELL Time
            Alive = Active;
            meal = true; // you can only assign readonly vars using non-static constructors 
            if(Alive == false)
            {
                Console.WriteLine("I'm StillBorn...");
            }
            doThought(); //put this in different places
        }

        public void VInitializer()
        {
            Init_PrismataSystem();
        }

        public static string ChackValidabaidi(dynamic obj)
        {
            if (obj is VCELL fe)
            {
                return "Checkenn :" + fe.Me.name;
            }
            return "Not a VCELL";
        }
        public DoTask FocusAction(DoTask doTask)
        {
            if(doTask.GetInvocationList().Any())
            {
                // then continue
                {
                    Delegate emo = doTask;
                    // parse em and see what's inside
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        if (emo.Method.IsDefined(doTask.GetType()))
                        {
                            // then create a method of service
                           emo = InAction.CreateDelegate(emo.Method.GetType()
                               ,doTask.GetMethodInfo(),false);
                           doTask = (DoTask)emo.DynamicInvoke();
                        }
                    }
                }
            }
            return doTask;
        }

        private DoTask ExecuteAction(Action ina) // THIS just checks for what is saved
        {
            if (!ina.Equals(savedActions.BinarySearch(ina)))
            {
                tempActions.Add(savedActions.First());
                savedActions.Remove(savedActions.First());
            }
            return new DoTask(ExecuteAction(ina));
        }

        public void CallRoutine() // calls a set of actions
        {
            ExecuteAction(tasks.Pop()).Invoke();
        }

        public virtual void Thinking()
        {
            AsyncCallback callback; // whenever a routine is complete call this.
            AsyncCallback watch; // lookat a specific att

            Span<Think> spant = thoughts.ToArray();
            Think []Spant2 = InputData.Thoughts.ToArray();
            Init_PrismataSystem();

            switch(PriorityLvl)
            {
                case 0:
                    // Nothing to do. seek.. find...
                    foreach (var task in spant)
                    {
                        task.E(PriorityLvl); // property "stimTh" now altered
                                             // search for a task that is similar to it
                        if (tasks.Contains(task.InMind))
                        {
                            task.InMind.SAction.Invoke();

                            tasks.Push(task.InMind);
                            tasks.Pop();
                            thoughts.Pop();
                        }
                    }
                    break;
                case 1:
                    // tasks of what. Misc Stuff. Side qs.. Create tasks?

                    break;
                case 2:
                    // BORED AF time to do shit.
                    break;
                case 3:
                    // Stressed little
                    break;
                case 4:
                    // Very Stressed ATTACK TIME
                    break;
                case 5:
                    // COMBAT MODE
                    break;
                default:
                    // DO SHIT
                    // DeskTalk goes here.
                    // and timer.
                    break;
            }
        }

        public void ActivateLoop()
        {
            switch (Alive)
            {
                case true:
                    Thinking();
                    Action action = tasks.Peek();

                    //annonymous function. Monitor?

                    VNodeDelegate value = delegate (VNode vNode)
                    {
                        Console.WriteLine
                        ("bloop", action.ToString(),
                        vNode.name);
                    };
                    VNodeDelegate vNodeDelegate =
                        value;

                    bool canRun = tasks.TryPop(out action);
                    if (canRun != true)
                    {
                        ExecuteAction(action);
                    }// pop from the top
                    else
                    {
                        tasks.Pop();
                        ActivateLoop();
                    }
                break;
                case false:
                    Console.WriteLine("Im Dead.");
                break;
            }
        }

    }
    delegate bool FindVNode(VNode vNode);
    class AI_EXTENSION
    {
        // all this does is find nodes and put them in an array
        // and then shits out the array
        public static VNode[] Wereu(VNode[] vNodes,
            FindVNode del)
        {
            int i = 0;
            List<VNode> results = new();
            foreach (VNode vNode1 in vNodes)
            {
                if(del(vNode1))
                {
                    results[i] = vNode1;
                    i++;
                    Console.WriteLine(vNode1.name);
                }
            }
            return results.ToArray();
        }
    }
}
