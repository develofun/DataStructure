using System.Collections.Generic;
using DataStructure;

namespace BinarySearchTree
{
    public partial class BST<T>
    {        
        public static BinaryTreeNode<T> ConvertToBST(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            List<T> keys = new List<T>();
            ExtractKeys(root, keys);

            keys.Sort();

            int index = 0;
            ReplaceKeys(root, keys, ref index);
            return root;
        }

        private static void ExtractKeys(BinaryTreeNode<T> root, List<T> keys)
        {
            if (root == null) return;
            ExtractKeys(root.Left, keys);
            keys.Add(root.Data);
            ExtractKeys(root.Right, keys);
        }

        private static void ReplaceKeys(BinaryTreeNode<T> root, List<T> keys, ref int index)
        {
            if (root == null) return;
            ReplaceKeys(root.Left, keys, ref index);
            root.Data = keys[index];
            index++;
            ReplaceKeys(root.Right, keys, ref index);
        }
    }

    public class BSTConvertTest
    {
        public static void Run()
        {
            var root = new BinaryTreeNode<int>(3);
            root.Left = new BinaryTreeNode<int>(5);
            root.Left.Left = new BinaryTreeNode<int>(7);
            root.Left.Right = new BinaryTreeNode<int>(6);
            root.Right = new BinaryTreeNode<int>(9);
            root.Right.Right = new BinaryTreeNode<int>(8);

            var tree = BST<int>.ConvertToBST(root);
        }
    }
}