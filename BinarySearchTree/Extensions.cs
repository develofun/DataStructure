using System.Collections.Generic;
using DataStructure;

namespace BinarySearchTree
{
    public partial class BST<T>
    {
        // find Kth smallest number
        public void FindKthSmallest(int k)
        {
            int count = 0;
            FindKthSmallest(root, k, ref count);
        }

        private bool FindKthSmallest(Node<T> node, int k, ref int count)
        {
            if (node == null) return false;

            bool found = FindKthSmallest(node.Left, k, ref count);
            if (found) return true;

            count++;
            if (count == k)
            {
                System.Console.WriteLine(node.Data);
                return true;
            }

            return FindKthSmallest(node.Right, k, ref count);
        }

        // find Kth largest number
        public void FindKthLargest(int k)
        {
            int count = 0;
            FindKthLargest(root, k, ref count);
        }

        private bool FindKthLargest(Node<T> node, int k, ref int count)
        {
            if (node == null) return false;

            bool found = FindKthLargest(node.Right, k, ref count);
            if (found) return true;

            count++;
            if (count == k)
            {
                System.Console.WriteLine(node.Data);
                return true;
            }

            return FindKthLargest(node.Left, k, ref count);
        }

        // find node in InorderTraversal
        public void InorderSuccessor(T key)
        {
            Node<T> node = root;
            Node<T> prev = null;

            while (node != null)
            {
                int cmp = node.Data.CompareTo(key);
                if (cmp == 0)
                {
                    if (node.Right == null)
                    {
                        if (prev != null) 
                            System.Console.WriteLine(prev.Data);
                    }
                    else
                    {
                        node = node.Right;
                        while (node.Right != null)
                        {
                            node = node.Left;
                        }

                        System.Console.WriteLine(node.Data);
                    }

                    break;
                }
                else if (cmp > 0)
                {
                    prev = node;
                    node = node.Left;
                }
                else
                {
                    prev = node;
                    node = node.Right;
                }
            }
        }

        // find lowest common ancestor (LCA)
        public void LeastCommonAncestor(T a, T b)
        {
            Node<T> lca = LCA(root, a, b);

            if (lca != null)
            {
                System.Console.WriteLine(lca.Data);
            }
        }

        // Recursive LCA
        private Node<T> LCA(Node<T> node, T a, T b)
        {
            if (node == null) return null;

            if (a.CompareTo(node.Data) < 0 && b.CompareTo(node.Data) < 0)
            {
                return LCA(node.Left, a, b);
            }
            else if (a.CompareTo(node.Data) > 0 && b.CompareTo(node.Data) > 0)
            {
                return LCA(node.Right, a, b);
            }

            return node;
        }

        // Iterative LCA
        private Node<T> IterativeLCA(Node<T> node, T a, T b)
        {
            while (node != null)
            {
                if (a.CompareTo(node.Data) < 0 && b.CompareTo(node.Data) < 0)
                {
                    node = node.Left;
                }
                else if (a.CompareTo(node.Data) > 0 && b.CompareTo(node.Data) > 0)
                {
                    node = node.Left;
                }
                else
                {
                    break;
                }
            }

            return node;
        }
    }
}