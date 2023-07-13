using System;
using System.Linq.Expressions;
namespace VCELL_Emulator
{
    public class LinkedIListIterator : IListIterator
    {
        private VNode position;
        private bool isAfterPrevious;
        private bool isAfterNext;
        private VNode first;
        private VNode last;

        public VNode GetFirst()
        {
            return first;
        }

        public void SetFirst(VNode value)
        {
            first = value;
        }

        public VNode GetLast()
        {
            return last;
        }

        public void SetLast(VNode value)
        {
            last = value;
        }

        /**
            Constructs an iterator that points to the front
            of the linked list.
        */
        public LinkedIListIterator()
                {
                    position = null;
                    isAfterNext = false;
                    isAfterPrevious = false;
                }

                public LinkedIListIterator(VNode f, VNode l)
                {
            SetFirst(f);
            SetLast(l);
                }

                public LinkedIListIterator(CustLinkedList d)
                {
            SetFirst(d.GetFirstNode());
            SetLast(d.GetLastNode());
                }
                /**
                    Moves the iterator past the next element.
                    @return the traversed element
                */

                public Object Next()
                {
                    if (!HasNext())
                    {
                        throw new Exception();
                    }
                    isAfterNext = true;
                    isAfterPrevious = false;

                position = first;

                return position.data;
                }

                /**
                    Tests if there is an element after the iterator position.
                    @return true if there is an element after the iterator position
                */
                public bool HasNext ()
                {
                    if (position == null)
                    {
                        return GetFirst() != null;
                    } else {
                        return position.next != null;
                    }
                }

                /**
        Moves the iterator before the previous element.
        @return the traversed element
   */
                public Object Previous ()
                {
                    if (!HasPrevious ())
                    {
                        throw new Exception ();
                    }
                    isAfterNext = false;
                    isAfterPrevious = true;

                    Object result = position.data;
                    position = position.previous;
                    return result;
                }

                /**
    Tests if there is an element before the iterator position.
    @return true if there is an element before the iterator position
*/
                public bool HasPrevious ()
                {
                    return position != null;
                }

                /**
    Adds an element before the iterator position
    and moves the iterator past the inserted element.
    @param element the element to add
 */

                public void AddFirst (Object element)
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

                public Object RemoveFirst()
                {
                    if (first == null)
                    {
                        throw new Exception();
                    }
                    Object element = first.data;
                    first = first.next;
                    if (first == null)
                    {
                        last = null;
                    }
                    return element;
                }

            public void AddLast (Object d)
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
                public void Add (Object element)
                {
                    if (position == null)
                    {
                        AddFirst(element);
                        position = GetFirst();
                    }
                    else if
                    (position == GetLast())
                    {
                        AddLast(element);
                        position = GetLast();
                    }
                    else
                    {
                    VNode newVNode = new VNode
                    {
                        data = element,
                        next = position.next
                    };
                        newVNode.next.previous = newVNode;
                        position.next = newVNode;
                        newVNode.previous = position;
                        position = newVNode;
                    }

                    isAfterNext = false;
                    isAfterPrevious = false;
                }

                /**
                    Removes the last traversed element. This method may
                    only be called after a call to the next() method.
                */
                /**
Removes the last traversed element. This method may
only be called after a call to the next() method.
*/
            public Object RemoveLast()
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
                public void Remove()
                {
                    VNode positionToRemove = LastPosition();

                    if (positionToRemove == GetFirst())
                    {
                        RemoveFirst();
                    }
                    else if (positionToRemove == GetLast())
                    {
                        RemoveLast();
                    }
                    else
                    {
                        positionToRemove.previous.next = positionToRemove.next;
                        positionToRemove.next.previous = positionToRemove.previous;
                    }

                    if (isAfterNext)
                    {
                        position = position.previous;
                    }

                    isAfterNext = false;
                    isAfterPrevious = false;
                }

                /**
                    Sets the last traversed element to a different value.
                    @param element the element to set
                */
                public void Set (Object element)
                {
                    VNode positionToSet = LastPosition();
                    positionToSet.data = element;
                }

                /**
                    Returns the last VNode traversed by this iterator, or
                    throws an IllegalStateException if there wasn't an immediately
                    preceding call to next or previous.
                    @return the last traversed VNode
                */
                private VNode LastPosition ()
                {
                    if (isAfterNext) {
                        return position;
                    } else if (isAfterPrevious) {
                        if (position == null) {
                            return GetFirst();
                        } else {
                            return position.next;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
        /**
        While not perfect with some understanding of
        positioning from the book and some diagrams.
        */
    }
}