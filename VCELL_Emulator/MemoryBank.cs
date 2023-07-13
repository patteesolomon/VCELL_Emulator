using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VCELL_Emulator
{
    public class MemoryBank: VNode
    {
        public List <VNode> MemTup = new List<VNode>(50); // size of Overallmemory
        
        delegate void VNodeDelegate(VNode vNodeD);
        private void Load()
        {
            StreamReader reader = new StreamReader(@"C:*\\VCELL_Emulator\VCELL_Emulator\MemSav0.json");
            JsonReader jreader;
            // this is the Reading function
            reader.ReadToEnd();
            using (jreader = new JsonTextReader(reader))
            {
                // a re-noding function would go here.
                MemTup.Clear();
                
                string json = reader.ReadToEnd();
                List<VNode> items = 
                    JsonConvert.DeserializeObject<List<VNode>>(json);
                MemTup = items;
            }
            // now close 
            reader.Close();
            jreader.Close();
        }

        private void Save()
        {
            StreamWriter writer = new StreamWriter(@"C:*\\VCELL_Emulator\VCELL_Emulator\MemSav0.json");
            JsonWriter jwriter;
            // this is the Writing function
            using (jwriter = new JsonTextWriter(writer))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jwriter, MemTup);
            }
            writer.Close();
            jwriter.Close();
        }

        private async void MethodRem(VNode[] m, Stack<Task> ts, int w)
        {
            await Recall(m, ts, w);
            Console.WriteLine("Recalling..." + PlaceF().ToString());
        }

        private object PlaceF()
        {
            return this.MemTup[0].ToString();
        }

        private Task PlaceF(int e) // change to VNode
        {
            return Task.Run(() => { Thread.Sleep(5000); return 1; });
        }

        private Task Recall(VNode[] m, Stack<Task> ts, int w)
        {
            /// 
            /// pull the nodes
            Load();
            /// find the Node(s) needed.
            bool tar = MemTup.Contains(m[w]);
            if (tar != true)
            {
                ts.First().Dispose();
                return ts.First();
            }
            else
            {
                /// put that b on the stack of cmds
                /// unboxing time
                var cem = m[w].data;
                Task meUp = Task.Run(() => cem);

                ts.Push(meUp);
                PlaceBack(ts);
                return PlaceF(w);
            }
        }

        private static Stack<Task> PlaceBack(Stack<Task> e)
        {
            return e;
        }
    }
}
