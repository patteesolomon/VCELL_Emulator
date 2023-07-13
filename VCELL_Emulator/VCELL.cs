using System.Collections.Generic;

/// <summary>
/// Todos
/// remember to use Euler's formula
/// to create an ideal way of
/// prismatic formations
/// </summary>
namespace VCELL_Emulator
{
    public class VCELL
    {
        #region stats
        private string name1;
        private float agility;
        private float speed2;
        private float jump_strength2; // not a base stat
        private int intel;

        public string GetName () => name1;
        void SetName1(string s) =>
            name1 = s;

        private int pNum; // this is just a node count
        //default is 4 a Tetrahedron class add one then its a pentahedron
        public VNode one, two, three, four;
        public VNode []vry;
        public CustLinkedList prism =
            new (); // for save data


        public VNode[] Vry { get => vry; 
            set => vry = value; }

        public VTree Me {get; set;}
        #endregion

        public VCELL()
        {
            name1 = "def";

            //one.data = GetName1();
        }

        public VCELL(VNode[] vry)
        {
            this.vry = vry;
        }
        public VCELL(int pNum, VNode[] vry)
        {
            this.pNum = pNum;
            this.vry = vry;
            
        }
        public VCELL(string name,
            int pNum2, int pNums,
            VNode[] vry)
        {
            // prop

            SetName1(name);
            pNum = pNum2;
            this.pNum = pNums;
            this.vry = vry;
        }

        // calls
        public void Init_PrismataSystem()
        {
            VNode[] restOfNodes = Me.GetVaccumNodes1().ToArray(); // get this done
            for (int i = 0; i < restOfNodes.Length; ++i)
            {
                Me.Prismatize(restOfNodes[i]);
            }
        }

        public void AddNodes(VNode [] VC)
        {
            List<VNode> arre = new()
            {
                Capacity = VC.Length
            };
            var o = VC.Length + arre.Count;

            for (int i = 0; i < o; i++)
            {
                if(VC[i] != null)
                {
                    Vry[Vry.Length + i] = VC[i];
                }
            }
        }

        public void Add(VNode vNode)
        {
            Vry.SetValue(vNode,Vry.Length + 1);
        }
    }
}
