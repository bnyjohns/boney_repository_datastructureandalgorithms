using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class StackUsingLinkedList : IStack
    {
        private SinglyLinkedList<object> data;

        public StackUsingLinkedList()
        {
            data = new SinglyLinkedList<object>();
        }

        public void Push(object value)
        {
            data.AddLast(value);
        }

        public object Pop()
        {
            return data.DeleteLast();
        }

        public int Count
        {
            get
            {
                return data.Count;
            }            
        }
    }
}
