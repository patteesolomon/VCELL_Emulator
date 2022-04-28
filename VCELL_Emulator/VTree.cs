using System;
using System.Collections.Generic;

namespace VCELL_Emulator
{
    public class VTree : VNode
    {
        private bool UNPG; // true if you have unallocated node points given and stored in the vaccum
        private int nodeCount;
        private VNode FinalCurrent = new();
        private List<VNode> CoreNodes; // middle nodes

        private List<VNode> CommonNodes; // anywhere else

        private List<VNode> VaccumNodes; // internal nodes that anything that doesn't fit the shape category
        // comes out later when the nodes increase in numbers. But only by 2

        private List<VNode> RootNodes; // always only 2

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

        public void Insert(VNode dataIn)
        {
            var TempNode = new VNode();
            _ = new VNode();
            _ = new VNode();
            int lastItem = GetRootNodes1().Capacity;

            TempNode.data = data;
            TempNode.SetL(null);
            TempNode.SetR(null);

            // if tree is empty, create root node
            if (GetRootNodes1().Capacity == 0) // we need 2
            {
                GetRootNodes1().Add(TempNode);
                GetRootNodes1().Add(TempNode);
            }
            else
            {
                _ = GetRootNodes1()[0];
                _ = GetRootNodes1()[lastItem];
            }

            GetVaccumNodes1().Add(dataIn);

            Prismatize();
        }

        public void TraverseCount()
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
        public void Prismatize() // puts the tree into a shape category
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
            for (int f = 0; d >= f; f++)
            // 1 2 3
            {
                if (GetRootNodes1().Capacity != 0)
                {
                    Top = GetRootNodes1()[d];
                    GetFinalCurrent1().SetNext(GetRootNodes1()[d]); // top
                    if (GetRootNodes1().Capacity == 1)
                    {
                        Bottom = GetRootNodes1()[lastItem];
                        GetFinalCurrent1().SetNext(GetRootNodes1()[d]); // bottom
                        GetFinalCurrent1().SetL(GetRootNodes1()[d].GetL());
                        GetFinalCurrent1().SetR(GetRootNodes1()[d].GetR());
                    }
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCommonNodes1()[d]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCoreNodes1()[d]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity == 0)
                {
                    GetFinalCurrent1().SetNext(Top.GetL());
                    GetFinalCurrent1().SetNext(Top.GetR());
                    GetFinalCurrent1().SetNext(Top);
                }
            }
            // ============================
            // THEN Reverse the flow of this traveresed/
            // connection flow from bottom to /
            // top then bottom again/
            // and overlay the two connection flows/
            // 3 2 1
            for (int g = 0; d <= g; --d)
            {
                if (GetRootNodes1().Capacity != 0)
                {
                    Top = GetRootNodes1()[g];
                    GetFinalCurrent1().SetNext(GetRootNodes1()[g]); // bottom
                    if (GetRootNodes1().Capacity == 1)
                    {
                        Top = GetRootNodes1()[0];
                        GetFinalCurrent1().SetNext(GetRootNodes1()[g]); // Top
                        GetFinalCurrent1().SetL(GetRootNodes1()[g].GetL());
                        GetFinalCurrent1().SetR(GetRootNodes1()[g].GetR());
                    }
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCommonNodes1()[g]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity != 0)
                {
                    GetFinalCurrent1().SetNext(GetCoreNodes1()[g]);
                }
                if (GetRootNodes1().Capacity == 0 && GetCommonNodes1().Capacity == 0 && GetCoreNodes1().Capacity == 0)
                {
                    GetFinalCurrent1().SetNext(Bottom.GetL());
                    GetFinalCurrent1().SetNext(Bottom.GetR());
                    GetFinalCurrent1().SetNext(Bottom);
                }
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
