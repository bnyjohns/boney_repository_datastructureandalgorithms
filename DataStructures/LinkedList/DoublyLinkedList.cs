using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class DoublyLinkedList<T> : LinkedList<T>
    {
        public void AddFirst(T value)
        {
            var node = new LinkedListNode<T>(value);
            if (head == null)
                head = node;
            else
            {
                head.Prev = node;
                node.Next = head;
                head = node;
            }
        }

        public void AddLast(T value)
        {
            var node = new LinkedListNode<T>(value);
            if (head == null)
                head = node;
            else
            {
                var lastElem = head;
                while(lastElem.Next != null)
                {
                    lastElem = lastElem.Next;
                }
                lastElem.Next = node;
                node.Prev = lastElem;
            }
        }

        public bool DeleteValue(T value)
        {
            var current = head;
            var deleted = false;
            while(current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;

                    if(ReferenceEquals(current, head))
                    {
                        head = current.Next;
                    }

                    deleted = true;
                    break;
                }
                current = current.Next;
            }
            return deleted;
        }
    }
}
