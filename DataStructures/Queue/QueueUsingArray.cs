using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class QueueUsingArray : IQueue
    {
        private object[] data;
        private int initialSize = 1;
        private int dynamicSize;
        int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public QueueUsingArray()
        {
            dynamicSize = initialSize;
            data = new object[dynamicSize];
        }

        public void EnQueue(object value)
        {
            if (count < dynamicSize)
                data[count] = value;
            else
            {                
                var temp = data;
                dynamicSize *= 2;
                data = new object[dynamicSize];
                temp.CopyTo(data, 0);
                data[count] = value;                
            }
            count++;
        }

        public object DeQueue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            var value = data[0];
            //Left Rotate
            for (int i = 0; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            data[count - 1] = null;         
            count--;
            return value;
        }

        public object Peek()
        {
            if (count == 0)
                throw new InvalidOperationException();

            return data[0];
        }
    }
}
