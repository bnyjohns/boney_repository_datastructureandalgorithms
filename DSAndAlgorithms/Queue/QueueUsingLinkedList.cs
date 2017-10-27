using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class QueueUsingLinkedList : IQueue
    {
        private SinglyLinkedList<object> data;

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public QueueUsingLinkedList()
        {
            data = new SinglyLinkedList<object>();
        }

        public void EnQueue(object value)
        {
            data.AddLast(value);
        }

        public object DeQueue()
        {
            return data.GetFirst(true);
        }

        public object Peek()
        {
            return data.GetFirst(false);
        }
    }
}
