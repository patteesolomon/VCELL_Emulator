//#define meep
using System;
namespace VCELL_Emulator
{
    /**
    A list iterator allows access of a position in a linked list.
    This interface contains a subset of the methods of the
    standard java.util.ListIterator interface. The methods for
    backward traversal are not included.
*/
    public interface IListIterator
    {
        /**
            Moves the iterator past the next element.
            @return the traversed element
        */
        Object Next ();

        /**
            Tests if there is an element after the iterator position.
            @return true if there is an element after the iterator position
        */
        bool HasNext ();

        /**
            Adds an element before the iterator position
            and moves the iterator past the inserted element.
            @param element the element to add
        */
        void Add (Object element);

        /**
            Removes the last traversed element. This method may
            only be called after a call to the next() method.
        */
        void Remove ();

        /**
            Sets the last traversed element to a different value.
            @param element the element to set
        */
        void Set (Object element);
    }
}