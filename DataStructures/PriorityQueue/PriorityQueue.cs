using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    /// <summary>
    /// Priority Queue for C# .NET
    /// Min Heap or Max Heap will be created based on the func passed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        private List<T> _data;
        Func<T, T, bool> _func = null;

        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="func">Function that takes in the parent and child nodes of a heap respectively. Return true if child node is to be swapped with parent node. Else return false</param>
        public PriorityQueue(Func<T, T, bool> func)
        {
            _data = new List<T>();
            _func = func;
        }

        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="data">List of items to be initialized in the priority queue</param>
        /// <param name="func">Function that takes in the parent and child nodes of a heap respectively. Return true if child node is to be swapped with parent node. Else return false</param>
        public PriorityQueue(List<T> data, Func<T, T, bool> func)
        {
            _data = data;
            _func = func;
            BuildHeap();
        }

        public int Count => _data.Count;

        public bool Any()
        {
            return _data.Any();
        }

        public T Dequeue()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            if (_data.Count == 1)
            {
                var top = _data[0];
                _data.Clear();
                return top;
            }
            else
            {
                var top = _data[0];
                _data[0] = _data[_data.Count - 1];
                _data.RemoveAt(_data.Count - 1);
                Heapify(0, _data.Count);
                return top;
            }
        }

        public void Update()
        {
            BuildHeap();
        }

        private void Heapify(int i, int N)
        {
            var largest = i;
            var l = 2 * largest + 1;
            var r = 2 * largest + 2;

            if (l < N)
            {
                if (_func(_data[largest], _data[l]))
                    largest = l;
            }

            if (r < N)
            {
                if (_func(_data[largest], _data[r]))
                    largest = r;
            }

            if (largest != i)
            {
                var temp = _data[i];
                _data[i] = _data[largest];
                _data[largest] = temp;
                Heapify(largest, N);
            }
        }

        private void BuildHeap()
        {
            var N = _data.Count;
            for (int i = N / 2; i >= 0; i--)
            {
                Heapify(i, N);
            }
        }

        public void Enqueue(T input)
        {
            _data.Add(input);
            var index = _data.Count - 1;
            var parent = (int)Math.Floor((double)(index - 1) / 2);
            while (parent >= 0 && _func(_data[parent], _data[index]))
            {
                var temp = _data[parent];
                _data[parent] = _data[index];
                _data[index] = temp;

                if (parent <= 0)
                    break;

                index = parent;
                parent = (int)Math.Floor((double)(index - 1) / 2);
            }
        }
    }
}
