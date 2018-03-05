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
    }
}
