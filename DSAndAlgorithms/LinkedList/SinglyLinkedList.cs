using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class SinglyLinkedList<T> : LinkedList<T>
    {
        public bool DeleteValue(T value)
        {
            var current = head;
            LinkedListNode<T> prev = null;
            bool deleted = false;
            while(current != null)
            {
                if(EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (prev == null)
                        head = current.Next;
                    else                    
                        prev.Next = current.Next;

                    deleted = true;                     
                    break;
                }
                prev = current;
                current = current.Next;
            }
            return deleted;
        }

        public T DeleteLast()
        {
            if (head == null)
                throw new InvalidOperationException();

            var last = head;
            LinkedListNode<T> prev = null;

            while(last.Next != null)
            {
                prev = last;
                last = last.Next;
            }

            if (prev != null)
            {
                prev.Next = null;                
            }
            else //Only one element in the linked list that we delete
            {
                head = null;                
            }
            return last.Value;               
        }

        public T GetFirst(bool delete)
        {
            if (head == null)
                throw new InvalidOperationException();

            var first = head;
            if (delete)
                head = head.Next;
            return first.Value;
        }

        public int Count
        {
            get
            {
                if (head == null)
                    return 0;

                var current = head;
                var count = 1;
                while (current.Next != null)
                {
                    current = current.Next;
                    count++;
                }
                return count;
            }            
        }


        public void AddFirst(T value)
        {
            var node = new LinkedListNode<T>(value);
            node.Next = head;
            head = node;
        }

        public void AddLast(T value)
        {
            var node = new LinkedListNode<T>(value);
            if(head == null)
            {
                head = node;                
            }
            else
            {
                var lastNode = head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = node;                
            }            
        }
    } 
    
}
