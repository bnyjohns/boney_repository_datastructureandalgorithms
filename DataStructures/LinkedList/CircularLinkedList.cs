using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class CircularLinkedList<T> : LinkedList<T>
    {        
        public void AddFirst(T value)
        {
            var node = new LinkedListNode<T>(value);
            if(head == null)
            {
                head = node;
                node.Next = head;
                tail = node;
            }
            else
            {
                //var tail = head;
                //while(tail.Next != head)
                //{
                //    tail = tail.Next;
                //}
                //tail.Next = node;
                //node.Next = head;
                //head = node;

                tail.Next = node;
                node.Next = head;
                head = node;
            }
        }
    }
}
