using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class BalancedParanthesis
    {
        private char[] start = {'{', '(', '['};
        private char[] end = { '}', ')', ']' };
        private IStack _stack;

        public BalancedParanthesis()
        {
            _stack = new StackUsingArray();
        }

        //{{}}
        public bool IsBalanced(string input)
        {
            var result = true;
            foreach (var i in input)//i = '}'
            {
                if (start.Contains(i))
                    _stack.Push(i);

                else
                {
                    var val = (char)_stack.Pop();//{
                    var index = Array.IndexOf(end, i);//0
                    if (val == start[index])//{ == {
                        continue;                   
                    result = false;
                    break;                    
                }
            }
            return result;
        }
    }
}
