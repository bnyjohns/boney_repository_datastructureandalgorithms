using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode<T>
    {
        public TreeNode(int key, T data)
        {
            Key = key;
            Data = data;
        }
        public int Key { get; set; }
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
