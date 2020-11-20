using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public partial class BST<T> where T: IComparable<T>
    {
        // nested class
        public class Node<P>
        {
            public P Data { get; set; }
            public Node<P> Left { get; set; }
            public Node<P> Right { get; set; }

            public Node(P data)
            {
                this.Data = data;
            }
        }

        private Node<T> root;

        public void Add(T data) 
        {
            if (root == null)
            {
                root = new Node<T>(data);
                return;
            }

            var node = root;
            while(node != null)
            {
                int cmp = data.CompareTo(node.Data);

                if (cmp == 0)
                {
                    throw new ApplicationException("Duplicate");
                }
                else if (cmp < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(data);
                        break;
                    }
                    
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(data);
                        break;
                    }
                    
                    node = node.Right;
                }
            }
        }

        public bool Search(T data) 
        { 
            var node = root;

            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);

                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public bool SearchRecursive(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node<T> node, T data)
        {
            if (node == null) return false;

            int cmp = data.CompareTo(node.Data);
            if (cmp == 0)
            {
                return true;
            }

            return cmp < 0 ? SearchRecursive(node.Left, data) : SearchRecursive(node.Right, data);
        }
        
        public bool Remove(T data) 
        { 
            var node = root;
            Node<T> prev = null;

            // find node to remove
            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);
                if (cmp == 0)
                {
                    break;
                }
                else if (cmp < 0)
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

            // not found
            if (node == null) return false;

            if (node.Left == null && node.Right == null) // child 0
            {
                if (prev.Left == node)
                {
                    prev.Left = null;
                }
                else
                {
                    prev.Right = null;
                }

                node = null;
            }
            else if (node.Left == null || node.Right == null) // child 1
            {
                var child = node.Left != null ? node.Left : node.Right;

                if (prev.Left == node)
                {
                    prev.Left = child;
                }
                else
                {
                    prev.Right = child;
                }

                node = null;
            }
            else // child 2
            {
                // get minimum value in right nodes
                // var pre = node;
                // var min = node.Right;
                // while (min.Left != null)
                // {
                //     pre = min;
                //     min = min.Left;
                // }

                // node.Data = min.Data;

                // if (pre.Left == min)
                // {
                //     pre.Left = min.Right;
                // }
                // else
                // {
                //     pre.Right = min.Right;
                // }

                // get maximum value in left nodes
                var pre = node;
                var max = node.Left;
                while (max.Right != null)
                {
                    pre = max;
                    max = max.Right;
                }

                node.Data = max.Data;

                if (pre.Right == max)
                {
                    pre.Right = max.Right;
                }
                else
                {
                    pre.Left = max.Right;
                }                
            }
            
            return true; 
        }

        public List<T> ToSortedList()
        {
            var list = new List<T>();
            Traversal(root, list);
            return list;
        }

        private void Traversal(Node<T> node, List<T> list)
        {
            if (node == null) return;

            Traversal(node.Left, list);
            list.Add(node.Data);
            Traversal(node.Right, list);
        }
    }

    public class BSTTest
    {
        public static void Run()
        {
            var bst = new BST<int>();
            bst.Add(6);
            bst.Add(7);
            bst.Add(2);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);
            bst.Add(4);

            // bool found = bst.Search(4);
            // System.Console.WriteLine(found);

            // var list = bst.ToSortedList();
            // PrintList(list);

            // bst.Remove(2);

            // PrintList(bst.ToSortedList());

            bst.LeastCommonAncestor(1, 4);            
        }

        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                System.Console.Write($"{item} ");
            }
            System.Console.WriteLine();
        }
    }
}