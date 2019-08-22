using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var inp = new int[] { 2, -1, -5, 0, -2, 1, 2, -2 };
            var dp = new int[inp.Length];
            dp[0] = inp[0];

            for (int i = 1; i < inp.Length; i++)
            {
                var temp = inp[i] + dp[i - 1];
                if (temp > inp[i])
                {
                    dp[i] = temp;
                }
                else
                {
                    dp[i] = inp[i];
                }
            }

            var maximum = dp[0];
            for (int i = 1; i < dp.Length; i++)
            {
                if (maximum < dp[i])
                    maximum = dp[i];
            }
            Console.WriteLine(maximum);


            //var queue = new QueueUsingStack();
            //queue.EnQueue(1);
            //queue.EnQueue(2);
            //var a = (int)queue.DeQueue();
            //queue.EnQueue(3);

            //a = (int)queue.DeQueue();
            //a = (int)queue.DeQueue();
            //queue.DeQueue();

            //var stack = new StackUsingQueue();
            //stack.Push(1);
            //stack.Push(2);
            //var a = (int)stack.Pop();
            //var length = stack.Count;

            //stack.Push(3);
            //stack.Push(4);

            //a = (int)stack.Pop();
            //a = (int)stack.Pop();
            //a = (int)stack.Pop();
            //a = (int)stack.Pop();

            //var queue = new QueueUsingLinkedList();
            //queue.EnQueue(1);
            //queue.EnQueue(2);
            //var a = (int)queue.DeQueue();
            //queue.EnQueue(3);

            //a = (int)queue.DeQueue();
            //a = (int)queue.DeQueue();
            //queue.DeQueue();

            //var stack = new StackUsingLinkedList();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);

            //var length = stack.Length;
            //var a = (int)stack.Pop();
            //a = (int)stack.Pop();
            //a = (int)stack.Pop();
            //a = (int)stack.Pop();
            //a = (int)stack.Pop();

            //SinglyLinkedList<int> a = new SinglyLinkedList<int>();
            //a.AddFirst(1);
            //a.AddLast(3);
            ////a.InsertAfterFirstMatch(2, 3);
            //a.InsertBeforeFirstMatch(3, 2);
            //a.PrintAll();
            //a.DeleteValue(3);
            //a.PrintAll();

            //var a = new DoublyLinkedList<int>();
            //a.AddLast(3);
            //a.AddLast(2);
            //a.AddLast(1);
            //a.DeleteValue(3);
            //a.PrintAll();

            //var a = new CircularLinkedList<int>();
            //a.AddFirst(3);
            //a.PrintAll();
            //a.AddFirst(2);
            //a.PrintAll();
            //a.AddFirst(1);
            //a.PrintAll();
        }
    }
}
