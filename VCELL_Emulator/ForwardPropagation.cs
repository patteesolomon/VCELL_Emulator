using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    internal class ForwardPropagation
    {
        Think ActivationTH = new Think();
        ActivationFunction ActivationFunctione = new ActivationFunction();
        //System.Action<ActivationFunction> MidAction = new System.Action<ActivationFunction>(Task.Run());
        #region
        float Monsterx, Monstery;
        object [] IndicesLock = new object[7]; // seven routine cap
        Action Action;
        Queue<object> Queue = new();
        SSheet_Anaylizer sSheet_;
        public Action Action11 { get => Action;
            set => Action = value; }

        #endregion
        public void Preactivation(float sum,
            float agsum,
             ActivationFunction Exe,
             object[] objects)// whether or not to exe
        {
            //Action action = new(ActivationTH,"",1, , Action.thing.THINK);

            var VartypesOfActivation = 
                Activator.CreateInstance(
                "agsum", "float", objects);
            int i = 0;
            foreach (IEnumerable<int> E in objects)
            {
                //action = new();
                //if (objects.GetType() ==
                //Action.GetType())
                //{
                //action = (Action)objects.GetValue
                //        ((int)IndicesLock[i]);
                //    E.GetEnumerator().MoveNext();
                 //   Queue.Enqueue(action);
                //}
                //else
                //{
                    // all super algos here
                    // Input class is needed
                    // as a parameter
                    //
                    //process hierarchy
                    // Forward
                    // Back
                    // Memory

                    // pane iteration
                    //sSheet_.Draw();
                    
                    // this comes last after every 
                    // pane iteration
                    //sSheet_.PaneDiv();
                   
                }
                ++i;
            }
                // done then weigh this shit
            // SuccessTime()
        };
        // successive layer being that of a Activation
        // Execution that becomes Evocation
        // this still goes to the Queue
        //public Action SuccessiveLayerToCall => Action11;
    }
