using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    interface IQueue
    {
        void EnQueue(object value);
        object DeQueue();
        object Peek();
        int Count { get; }
    }
}
