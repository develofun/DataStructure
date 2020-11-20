using System.Collections.Generic;

namespace DataStructure
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree(T root)
        {
            Root = new BinaryTreeNode<T>(root);
        }

        // traversal

        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }

        private void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            System.Console.Write($"{node.Data} ");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            InorderTraversal(node.Left);
            System.Console.Write($"{node.Data} ");
            InorderTraversal(node.Right);
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            System.Console.Write($"{node.Data} ");
        }

        // iterative
        public void PreorderIterative()
        {
            if (Root == null) return;

            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(Root);

            while(stack.Count > 0)
            {
                var node = stack.Pop();

                System.Console.Write(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public void InorderIterative()
        {
            if (Root == null) return;

            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                while(node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();

                System.Console.Write(node.Data);

                node = node.Right;
            }
        }

        public void PostorderIterative()
        {
            if (Root == null) return;

            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while(node != null || stack.Count > 0)
            {
                while(node != null)
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }

                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();

                if (node.Right != null && stack.Count > 0 && node.Right == stack.Peek())
                {
                    var right = stack.Pop();
                    stack.Push(node);
                    node = right;
                }
                else
                {
                    System.Console.Write(node.Data);
                    node = null;
                }
            }
        }

        public void LevelorderTraversal()
        {
            var q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(Root);

            while(q.Count > 0)
            {
                var node = q.Dequeue();

                System.Console.Write("{0} ", node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public void LevelorderNewLine()
        {
            var q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(Root);
            q.Enqueue(null);

            while(q.Count > 0)
            {
                var node = q.Dequeue();

                if (node == null)
                {
                    System.Console.WriteLine();
                    if (q.Count > 0) q.Enqueue(null);
                    continue;
                }

                System.Console.Write("{0} ", node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }
    }

    public class BinaryTreeTest
    {
        public static void Run()
        {
            var bt = new BinaryTree<int>(1);

            bt.Root.Left = new BinaryTreeNode<int>(2);
            bt.Root.Right = new BinaryTreeNode<int>(3);
            bt.Root.Left.Left = new BinaryTreeNode<int>(4);
            bt.Root.Left.Right = new BinaryTreeNode<int>(5);
            bt.Root.Right.Left = new BinaryTreeNode<int>(6);

            bt.PreorderTraversal();
            System.Console.WriteLine();
            bt.InorderTraversal();
            System.Console.WriteLine();
            bt.PostorderTraversal();

            System.Console.WriteLine();
            bt.PostorderIterative();

            System.Console.WriteLine();
            bt.LevelorderTraversal();
            System.Console.WriteLine();
            bt.LevelorderNewLine();
        }
    }
}