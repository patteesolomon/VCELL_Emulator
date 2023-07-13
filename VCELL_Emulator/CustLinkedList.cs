using System;
using System.Linq.Expressions;
namespace VCELL_Emulator
{
        public class CustLinkedList : LinkedIListIterator
        {
            private VNode first;
            private VNode last;
            // VNode
            public VNode GetFirstNode()
            {
                return first;
            }
            public VNode GetLastNode()
            {
                return last;
            }
            /**
        Constructs an empty linked list.
*/
            public CustLinkedList()
            {
                first = null;
                last = null;
            }
            /**
            Returns the first element in the linked list.
            @return the first element in the linked list
            */
            new public Object GetFirst()
            {
                if (first == null)
                {
                    throw new Exception();
                }
                return first.data;
            }

            new public Object GetLast()
            {
                if (last == null)
                {
                    throw new Exception ();
                }
                Object element = last.data;
                last = last.previous;
                if (last == null)
                {
                    first = null;
                }
                else
                {
                    last.next = null;
                }
                return element;
            }

            public new Object RemoveLast()
            {
                if (last == null)
                {
                    throw new Exception ();
                }
                Object element = last.data;
                last = last.previous;
                if (last == null)
                {
                    first = null; // List is now empty
                } else {
                    last.next = null;
                }

                return element;
            }

            public new void AddLast (Object d)
            {
            VNode newVNode = new VNode
            {
                data = d,
                next = null,
                previous = last
            };

            if (last == null)
            {
                first = newVNode;
                }
                else
                {
                    last.next = newVNode;
                }
                last = newVNode;
            }

            /**
            \   Removes the first element in the linked list.
                @return the removed element
            */
            public new Object RemoveFirst ()
            {
                if (first == null)
                {
                    throw new Exception ();
                }
                Object element = first.data;
                first = first.next;
                if (first == null)
                {
                    last = null;
                }
                return element;
            }

            /**
                Adds an element to the front of the linked list.
                @param element the element to add
            */
            public new void AddFirst (Object element)
            {
            VNode newVNode = new VNode
            {
                data = element,
                next = first,
                previous = null
            };
            if (first == null)
            {
                    last = newVNode;
                }
                else
                {
                    first.previous = newVNode;
                }
                first = newVNode;
            }

        /**
            Returns an iterator for iterating through this list.
            @return an iterator for iterating through this list
        */

        public LinkedIListIterator ListIterator()
        {
            return new LinkedIListIterator();
        }

        public void Reverse (LinkedIListIterator d)
        {
            d.Next();
            VNode stnoddo = first;
            VNode temp = null;
            VNode prev = null;
            VNode current = stnoddo;

            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            stnoddo = prev;
        }
    }
}