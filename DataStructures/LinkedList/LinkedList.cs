using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class LinkedList<T>
    {
        protected LinkedListNode<T> head;
        protected LinkedListNode<T> tail;
        public void PrintAll()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public void Reverse()
        {
            if (head == null || head.Next == null)
                return;

            var prev = head;
            var current = head.Next;
            if (current != null)
                prev.Next = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;

                prev = current;
                current = next;
            }
            head = prev;
        }

        public T Middle()
        {
            if (head == null)
                return default(T);
            if (head.Next == null)
                return head.Value;
            if (head.Next.Next == null)
                return head.Next.Value;

            var ptr1 = head;
            var ptr2 = head.Next.Next;

            while (ptr2 != null)
            {
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;
                if (ptr2 != null)
                    ptr2 = ptr2.Next;
            }
            return ptr1.Value;
        }
    }
}
