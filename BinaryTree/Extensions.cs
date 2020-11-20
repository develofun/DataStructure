using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Extensions
    {
        public int GetMaxDepth<T>(BinaryTreeNode<T> node)
        {
            if (node == null) return -1;

            return 1 + Math.Max(GetMaxDepth(node.Left), GetMaxDepth(node.Right));
        }

        public int GetNodeCount<T>(BinaryTreeNode<T> node) 
        {
            if (node == null) return 0;

            return 1 + GetNodeCount(node.Left) + GetNodeCount(node.Right);
        }

        public bool FindTreePath<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> target, List<BinaryTreeNode<T>> path)
        {
            if (root == null) return false;

            path.Add(root);

            if (root == target) return true;
            if (FindTreePath(root.Left, target, path) || FindTreePath(root.Right, target, path)) return true;
            
            path.RemoveAt(path.Count - 1);
            return false;
        }
    }

    public class BinaryTreeExTest
    {
        // public static void Run()
        // {
        //     var path = new List<BinaryTreeNode<char>>();
        //     bool found = tree.FindTreePath(root, target, path);

        //     if (found)
        //     {
        //         foreach(var node in path)
        //         {
        //             System.Console.Write($"{node.Data} ");
        //         }
        //     }
        // }
    }
}