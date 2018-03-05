using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class QueueUsingStack : IQueue
    {
        private IStack stack1;
        private IStack stack2;

        public QueueUsingStack()
        {
            stack1 = new StackUsingLinkedList();
            stack2 = new StackUsingLinkedList();
        }

        public int Count
        {
            get
            {
                return stack1.Count + stack2.Count;
            }
        }

        #region Efficient DeQueue
        //public void EnQueue(object value)
        //{
        //    stack1.Push(value);
        //    while(stack2.Count > 0)
        //    {
        //        stack1.Push(stack2.Pop());
        //    }
        //    var temp = stack2;
        //    stack2 = stack1;
        //    stack1 = temp;
        //}

        //public object DeQueue()
        //{
        //    return stack2.Pop(); 
        //}
        #endregion

        #region Efficient EnQueue
        public void EnQueue(object value)
        {
            stack1.Push(value);
        }

        public object DeQueue()
        {
            while (stack1.Count > 1)
                stack2.Push(stack1.Pop());

            var result = stack1.Pop();
            var temp = stack2;
            stack2 = stack1;
            stack1 = temp;

            return result;
        }
        #endregion

        public object Peek()
        {
            throw new NotImplementedException();
        }
    }
}
