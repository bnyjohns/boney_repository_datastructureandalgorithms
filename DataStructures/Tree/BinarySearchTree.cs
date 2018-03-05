using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearchTree<T>
    {
        public TreeNode<T> Add(TreeNode<T> root, Tuple<int, T> data)
        {
            return InsertNodeUsingIteration(root, data);
        }

        public void InOrderTraverseAndPrint(TreeNode<T> root)
        {
            if(root != null)
            {
                InOrderTraverseAndPrint(root.Left);
                Console.WriteLine(root.Key);
                InOrderTraverseAndPrint(root.Right);
            }
        }

        public TreeNode<T> Search(int key, TreeNode<T> root)
        {
            if (root == null)
                return null;

            if (key < root.Key)
                return Search(key, root.Left);
            else if (key > root.Key)
                return Search(key, root.Right);
            else if (key == root.Key)
                return root;
            
            return null;            
        }

        //private TreeNode<T> InsertNodeUsingRecursion(TreeNode<T> node, Tuple<int,T> data)
        //{
        //    if (node == null)
        //        return new TreeNode<T>(data.Item1, data.Item2);
        //    else
        //    {
        //        if (node.Key > data.Item1)
        //            node.Left = InsertNode(node.Left, data);
        //        else if (node.Key < data.Item1)
        //            node.Right = InsertNode(node.Right, data);

        //        return node;
        //    }
        //}

        private TreeNode<T> InsertNodeUsingIteration(TreeNode<T> node, Tuple<int, T> data)
        {
            var nodeToInsert = new TreeNode<T>(data.Item1, data.Item2);
            if (node == null)
                return nodeToInsert;
            else
            {                
                while(true)
                {                   
                    if(nodeToInsert.Key < node.Key)
                    {
                        if (node.Left == null)
                        {
                            node.Left = nodeToInsert;
                            break;
                        }                            
                        else
                            node = node.Left;
                    }
                    else if(nodeToInsert.Key > node.Key)
                    {
                        if (node.Right == null)
                        {
                            node.Right = nodeToInsert;
                            break;
                        }
                        else
                            node = node.Right;
                    }                    
                }
                return nodeToInsert;                
            }
        }
    }
}
