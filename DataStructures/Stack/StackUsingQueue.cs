using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class StackUsingQueue : IStack
    {
        private IQueue queue1;
        private IQueue queue2;

        public StackUsingQueue()
        {
            queue1 = new QueueUsingLinkedList();
            queue2 = new QueueUsingLinkedList();
        }

        #region Efficient Pop
        public void Push(object value)
        {
            queue1.EnQueue(value);
            while(queue2.Count > 0)
            {
                queue1.EnQueue(queue2.DeQueue());
            }
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        public object Pop()
        {
            return queue2.DeQueue();            
        }

        public int Count
        {
            get
            {
                return queue1.Count + queue2.Count;
            }
        }
        #endregion

        #region Efficient Push
        //public int Count
        //{
        //    get
        //    {
        //        return queue1.Count;
        //    }
        //}

        //public void Push(object value)
        //{
        //    queue1.EnQueue(value);
        //}

        //public object Pop()
        //{
        //    if (queue1.Count == 0)
        //        throw new InvalidOperationException();

        //    while(queue1.Count > 1)
        //    {
        //        queue2.EnQueue(queue1.DeQueue());
        //    }

        //    var result = queue1.DeQueue();
        //    var temp = queue1;
        //    queue1 = queue2;
        //    queue2 = temp;
        //    return result;
        //}
        #endregion
    }
}
