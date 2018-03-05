using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IStack
    {
        int Count { get; }
        void Push(object value);
        object Pop();
    }
}
