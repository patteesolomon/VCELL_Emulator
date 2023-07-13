using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// google .Net Factory pattern and the Strategy pattern

/*
 Use a data flow to process it into 
a model that goes into a mapping function
that loads into something that will process it 
into an interface and fullfill the promisses met
then implement that into the source
 */

namespace VCELL_Emulator
{
    public class VTree : VNode
    {
        private bool UNPG; // true if you have unallocated node points given and stored in the vaccum
        private int nodeCount;
        private VNode FinalCurrent; // Final Core Of Recursion
        private List<VNode> CoreNodes; // middle nodes

        private List<VNode> CommonNodes; // anywhere else

        private List<VNode> VaccumNodes; // internal nodes that anything that doesn't fit the shape category
        // comes out later when the nodes increase in numbers. But only by 2

        private List<VNode> RootNodes; // always only 2 nodes ever

        private List<VNode> Links;

        IEnumerable VNCore; // idk

        public enum EDir
        {
            up = 0, // |
            dal = 1, // \
            left = 2, // <-
            dnl = 3, // /
            down = 4, // |
            dnr = 5, // \
            right = 6, // ->
            dar = 7, // /
        }

        public VTree(int nc, VNode starter) // no more null
        {
            starter.uAddr = "0000";
            starter.data = new byte[nc];
            starter.name = "one";
            starter.statData = 0;

            var TempNode = new VNode();
            _ = new VNode();
            VNode d = new VNode();
            int lastItem = GetRootNodes1().Capacity;

            TempNode.data = starter.data;
            //TempNode.SetL(null);
            //TempNode.SetR(null);

            // if tree is empty, create root node
            if (GetRootNodes1().Capacity == 0) // we need 2
            {
                GetRootNodes1().Add(TempNode);
                GetRootNodes1().Add(TempNode);
            }
            else
            {
                _ = GetRootNodes1()[0];
                d = GetRootNodes1()[lastItem];
            }
        }
        #region capmethods

        public enum ALLPRISMAFORMS
        {
            ADEPT,
            EX,
            OMNI,
            STRIDE,
            ARCH,
            KAISER,
            SACRED,
            ULTIMATE,
            MASTER
        }

        public Enum PrismaLvl
        {
            get; set;
        }
        public IEnumerable VNCore1 { get => VNCore; set => VNCore = value; }

        public bool GetUNPG1()
        {
            return UNPG;
        }

        public void SetUNPG1(bool value)
        {
            UNPG = value;
        }
        public int GetNodeCount()
        {
            return nodeCount;
        }

        public VNode GetFinalCurrent1()
        {
            return FinalCurrent;
        }

        public void SetFinalCurrent1(VNode value)
        {
            FinalCurrent = value;
        }

        public List<VNode> GetCoreNodes1()
        {
            return CoreNodes;
        }

        public void SetCoreNodes1(List<VNode> value)
        {
            CoreNodes = value;
        }

        public List<VNode> GetCommonNodes1()
        {
            return CommonNodes;
        }

        public void SetCommonNodes1(List<VNode> value)
        {
            CommonNodes = value;
        }

        public List<VNode> GetVaccumNodes1()
        {
            return VaccumNodes;
        }

        public void SetVaccumNodes1(List<VNode> value)
        {
            VaccumNodes = value;
        }

        public List<VNode> GetRootNodes1()
        {
            return RootNodes;
        }

        public void SetRootNodes1(List<VNode> value)
        {
            RootNodes = value;
        }

        public static VNode AddR(VNode inc)
        {
            return inc switch
            {
                null => new VNode(),
                _ => inc.previous,
            };
        }
        #endregion

        public static int PosMod(int a, int b, int left, int right, EDir dir)
        {
            switch(dir)
            {
                case EDir.up:
                    return Math.Abs(a + b);

                case EDir.dal:
                    return Math.Abs(left - a - b);

                case EDir.left:
                    return Math.Abs(left);

                case EDir.dnl:
                    return Math.Abs(left - a);

                case EDir.down:
                    return Math.Abs(b - a);

                case EDir.dnr:
                    return Math.Abs(right + b);

                case EDir.right:
                    return Math.Abs(right);

                case EDir.dar:
                    return Math.Abs(right + b - a);
            }
            if (left == 0)
            {
                left = a;
            }
            return a * b + left;
        }
        public static int Modulus(int a, int b ,int left)
        {
            int right = a;
            while (left < right)
            {
                int m = (left + right) / 2;
                if (a - m * b >= b)
                    left = m + 1;
                else
                    right = m;
            }
            return a - left * b;
        }
        public void Insert(VNode dataIn, int weher)
        {
            GetVaccumNodes1()[weher] = dataIn;

            Prismatize(GetFinalCurrent());
        }
        public void TraverseNodesAndCleanNulls()
        {
            VNode cpy = FinalCurrent;
            //find a way to traverse through the Core and Common Nodes
            do
            {
                if (cpy.GetL().data == null)
                {
                    cpy.GetL().DeleteNode();
                    //++nodeCount;
                }
                else if (cpy.GetR().data == null)
                {
                    cpy.GetR().DeleteNode();
                    //++nodeCount;
                }
                else if (cpy.GetNext().GetL().data == null)
                {
                    cpy.GetNext().GetL().DeleteNode();
                    //++nodeCount;
                }
                else if (cpy.GetNext().GetR().data == null)
                {
                    cpy.GetNext().GetL().DeleteNode();
                    //++nodeCount;
                }
                // root top and bottom finished..
                else
                {
                    // loop here all common Nodes
                    if (cpy.GetNext().data == null)
                    {
                        if (cpy.GetL().data == null)
                        {
                            //++nodeCount;
                        }
                        else if (cpy.GetR().data != null)
                        {
                            //++nodeCount;
                        }
                        //end
                        if (cpy.data == null)
                        {
                            cpy.DeleteNode();
                        }
                    }
                }
            } while (FinalCurrent != null);
        }
        public void TraverseCountAndCleanNonNulls()
        {
            // vars
            nodeCount = 0;
            VNode Fcpy = FinalCurrent;
            //find a way to traverse through the FinalCurrent Node 
            do
            {
                if (Fcpy.GetL().data != null)
                {
                    Fcpy.GetL().DeleteNode();
                    ++nodeCount;
                }
                else if (Fcpy.GetR().data != null)
                {
                    Fcpy.GetR().DeleteNode();
                    ++nodeCount;
                }
                else if (Fcpy.GetNext().GetL().data != null)
                {
                    Fcpy.GetNext().GetL().DeleteNode();
                    ++nodeCount;
                }
                else if (Fcpy.GetNext().GetR().data != null)
                {
                    Fcpy.GetNext().GetL().DeleteNode();
                    ++nodeCount;
                }
                // root top and bottom finished..
                else
                {
                    // loop here all common Nodes
                    if (Fcpy.GetNext().data != null)
                    {
                        if (Fcpy.GetL().data != null)
                        {
                            ++nodeCount;
                        }
                        else if (Fcpy.GetR().data != null)
                        {
                            ++nodeCount;
                        }
                        //end
                        if (Fcpy.data == null)
                        {
                            Fcpy.DeleteNode();
                        }
                    }
                }
            } while (this.FinalCurrent != null);
        }
        public bool LevelUpTime()
        {
            if (VaccumNodes.Capacity > 0)
            {
                return UNPG = true;
            }
            return UNPG = false;
        }
        public VNode GetFinalCurrent()
        {
            return FinalCurrent;
        }
        public void Prismatize(VNode finalCurrent) // puts the tree into a shape category
        {
            // vars
            int lastRoot = GetRootNodes1().Capacity;
            int lastItem = GetVaccumNodes1().Capacity;
            var Top = GetRootNodes1()[0];
            var Bottom = GetRootNodes1()[lastRoot];
            var parent = new VNode();
            if (GetVaccumNodes1().Count > 0) // prismform
            {
                for (var i = lastItem - 1; i >= 0; i--)
                {
                    GetCommonNodes1().Add(GetVaccumNodes1()[i]);
                    if (Top.GetL().data == null)
                    {
                        ++nodeCount;
                        Bottom.SetL(GetCommonNodes1()[i]);

                    }
                    else if (Top.GetR().data == null)
                    {
                        ++nodeCount;
                        Bottom.SetR(GetCommonNodes1()[i]);
                    }
                    else if (Bottom.GetL().data == null)
                    {
                        ++nodeCount;
                        Top.SetL(GetCommonNodes1()[i]);
                    }
                    else if (Bottom.GetR().data == null)
                    {
                        ++nodeCount;
                        Top.SetR(GetCommonNodes1()[i]);
                    }
                    // root top and bottom finished..
                    else
                    {
                        parent = GetCommonNodes1()[i]; // new set
                        // loop here all common Nodes
                        for (; i > 0; i--)
                        {
                            GetCoreNodes1().Add(parent);
                            if (parent.GetL().data == null)
                            {
                                ++nodeCount;
                                parent.SetL(GetCoreNodes1()[i]);
                            }
                            else if (parent.GetR().data == null)
                            {
                                ++nodeCount;
                                parent.SetR(GetCoreNodes1()[i]);
                            }
                            else
                            {
                                ++nodeCount;
                                parent = GetVaccumNodes1()[i];
                            }
                            //end
                            if (parent.data == null)
                            {
                                parent.DeleteNode();
                            }
                        }
                    }
                }
            }
            else // all back into the vaccum
            {
                for (var i = 0; i < lastItem; i++)
                {
                    GetVaccumNodes1()[i] = GetCommonNodes1()[i];
                }
            }

            // traverse and then connect the common leaves 
            // to the core leaves
            // or in this case the entire prismaform
            // 
            var d = GetRootNodes1().Capacity + GetCoreNodes1().Capacity + GetCommonNodes1().Capacity;
            // traverse and set
            // from the top root node  / 
            // to the bottom root node  / 
            // to the the bottom r and l / 
            // to the remaining commmon /
            // to the core nodes /
            // to the l then r of the root top
            // then the top again /
            for (int f = 0; d > f; f++)
            // 1 2 3
            {
                if (GetRootNodes1().Capacity != 0)
                {
                    Top = GetRootNodes1()[d];
                    
                    Links.Add(Top);

                    GetFinalCurrent1().SetNext(GetRootNodes1()[d]); // top
                    if (GetRootNodes1().Capacity == 1)
                    {
                        Bottom = GetRootNodes1()[lastItem];
                        Links.Add(Bottom);
                        GetFinalCurrent1().SetNext(GetRootNodes1()[d]); // bottom'
                        Links.Add(GetRootNodes1()[d]);
                        GetFinalCurrent1().SetL(GetRootNodes1()[d].GetL());
                        Links.Add(GetRootNodes1()[d].GetL());
                        GetFinalCurrent1().SetR(GetRootNodes1()[d].GetR());
                        Links.Add(GetRootNodes1()[d].GetR());
                    }

                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCommonNodes1()[d]);
                    Links.Add(GetCommonNodes1()[d]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCoreNodes1()[d]);
                    Links.Add(GetRootNodes1()[d]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity == 0)
                {
                    GetFinalCurrent1().SetNext(Top.GetL());
                    Links.Add(Top.GetL());
                    GetFinalCurrent1().SetNext(Top.GetR());
                    Links.Add(Top.GetR());
                    GetFinalCurrent1().SetNext(Top);
                    Links.Add(Top.GetNext());
                }
            }
            // ============================
            // THEN Reverse the flow of this traveresed/
            // connection flow from bottom to /
            // top then bottom again/
            // and overlay the two connection flows/
            // 3 2 1
            for (int g = 0; d < g; --d)
            {
                if (GetRootNodes1().Capacity != 0)
                {
                    Bottom = GetRootNodes1()[g];
                    // dont add anything twice for links
                    GetFinalCurrent1().SetNext(GetRootNodes1()[g]); // bottom
                    if (GetRootNodes1().Capacity == 1)
                    {
                        Top = GetRootNodes1()[0];
                        GetFinalCurrent1().SetNext(GetRootNodes1()[g]); // Top
                        GetFinalCurrent1().SetL(GetRootNodes1()[g].GetL());
                        Links.Add(GetRootNodes1()[g].GetL());
                        GetFinalCurrent1().SetR(GetRootNodes1()[g].GetR());
                        Links.Add(GetRootNodes1()[g].GetR());
                    }
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCommonNodes1()[g]);
                    Links.Add(GetCommonNodes1()[g]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCoreNodes1()[g]);
                    Links.Add(GetCoreNodes1()[g]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity == 0)
                {
                    GetFinalCurrent1().SetNext(Bottom.GetL());
                    Links.Add(Bottom.GetL());
                    GetFinalCurrent1().SetNext(Bottom.GetR());
                    Links.Add(Bottom.GetR());
                    GetFinalCurrent1().SetNext(Bottom);
                }

                //CoreNodes[0]; I'll use this for now
                VNCore1 = from s in Links
                             select new { 
                                 St = GetFinalCurrent()
                             }; //GetFinalCurrent();
                
            }

            //prismatime
            PrismaLvl = nodeCount switch
            {
                5 => ALLPRISMAFORMS.ADEPT,
                6 => ALLPRISMAFORMS.EX,
                7 => ALLPRISMAFORMS.OMNI,
                8 => ALLPRISMAFORMS.STRIDE,
                9 => ALLPRISMAFORMS.ARCH,
                10 => ALLPRISMAFORMS.KAISER,
                11 => ALLPRISMAFORMS.SACRED,
                12 => ALLPRISMAFORMS.ULTIMATE,
                13 => ALLPRISMAFORMS.MASTER,
                _ => null,
            };

            // deletion to garbage collection/
            for (int i = 0; i <= d; i++)
            {
                GetRootNodes1()[i].DeleteNode();
                GetCommonNodes1()[i].DeleteNode();
                GetCoreNodes1()[i].DeleteNode();
            }
            Top.DeleteNode();
            Bottom.DeleteNode();
            parent.DeleteNode();
        }
    }
}
