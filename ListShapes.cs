using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class ListShapes<T> : ICollection<T>
    {
        private DoublyNode head;
        private DoublyNode tail;

        private class DoublyNode
        {
            public DoublyNode _next;
            public DoublyNode _prev;
            public T _data;

            public DoublyNode(DoublyNode next, DoublyNode prev, T data)
            {
                _next = next;
                _prev = prev;
                _data = data;
            }
        }

        int ICollection<T>.Count => throw new NotImplementedException();

        bool ICollection<T>.IsReadOnly => throw new NotImplementedException();

        void ICollection<T>.Add(T item)
        {
            DoublyNode node = new DoublyNode(head, null, item);
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
