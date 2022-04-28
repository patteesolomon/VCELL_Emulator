using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public class VNode
    {
        public string name;
        public object data; // this is vauge but it'll work for now.
                            // It should be the input data from the environment.
        public int statData; // this is for the stats to be read
        public VNode previous;
        public VNode next;

        private VNode RightChild;

        private VNode LeftChild;
        // unique address
        public string uAddr;

        private static readonly Random random = new();

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public VNode()
        {
            uAddr = RandomString(4);
            data = null;
            next = null;
            RightChild = null;
            LeftChild = null;
            previous = null;
        }

        public VNode(object d)
        {
            data = d;
            next = null;
            previous = null;
        }
        public void DeleteNode()
        {
            data = null;
            next = null;
        }

        public VNode GetNext()
        {
            return next;
        }

        public void SetNext(VNode n)
        {
            next = n;
        }

        public object GetData()
        {
            return data;
        }

        public VNode GetL()
        {
            return LeftChild;
        }

        public VNode GetR()
        {
            return RightChild;
        }

        public void SetL(VNode m)
        {
            LeftChild = m;
        }

        public void SetR(VNode m)
        {
            RightChild = m;
        }

        ~VNode()
        {
            Console.WriteLine("VNode" + this.name + " freed from The Vaccum");
        }
    }
}
