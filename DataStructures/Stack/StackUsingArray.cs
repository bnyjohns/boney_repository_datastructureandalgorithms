using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class StackUsingArray : IStack
    {
        private object[] data;
        private int initialSize = 1;
        private int dynamicSize = 1;
        private int currentCount = 0;

        public StackUsingArray()
        {
            dynamicSize = initialSize;         
            data = new object[dynamicSize];                
        }

        public int Count
        {
            get
            {
                return currentCount;
            }
        }

        public void Push(object value)
        {
            if(currentCount < dynamicSize)
                data[currentCount] = value;
            else
            {
                var temp = data;
                dynamicSize *= 2;
                data = new object[dynamicSize];
                temp.CopyTo(data, 0);
                data[currentCount] = value;
            }
            currentCount++;
        }

        public object Pop()
        {
            if (currentCount < 1)
                throw new InvalidOperationException();
            else
            {
                var index = currentCount - 1;
                var value = data[index];
                data[index] = null;
                currentCount--;
                return value;
            }                
        }
    }
}
