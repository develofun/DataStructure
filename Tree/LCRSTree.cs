using System.Collections.Generic;

namespace DataStructure
{
    public class LCRSTree
    {
        public LCRSNode Root { get; private set; }

        public LCRSTree(object rootData)
        {
            this.Root = new LCRSNode(rootData);
        }

        public LCRSNode AddChild(LCRSNode parent, object data)
        {
            if (parent == null) return null;

            LCRSNode child = new LCRSNode(data);

            if (parent.LeftChild == null)
            {
                parent.LeftChild = child;
            }
            else
            {
                var node = parent.LeftChild;
                while(node.RightSibling != null)
                {
                    node = node.RightSibling;
                }

                node.RightSibling = child;
            }

            return child;
        }

        public LCRSNode AddSibling(LCRSNode node, object data)
        {
            if (node == null) return null;

            while(node.RightSibling != null)
            {
                node = node.RightSibling;
            }

            var sibling = new LCRSNode(data);
            node.RightSibling = sibling;

            return sibling;
        }

        public void PrintLevelOrder()
        {
            var q = new Queue<LCRSNode>();
            q.Enqueue(this.Root);

            while(q.Count > 0)
            {
                var node = q.Dequeue();
                
                while(node != null)
                {
                    System.Console.Write($"{node.Data} ");

                    if (node.LeftChild != null)
                    {
                        q.Enqueue(node.LeftChild);
                    }

                    node = node.RightSibling;
                }
            }
        }

        public void PrintIndentTree()
        {
            PrintIndent(this.Root, 1);
        }

        public void PrintIndent(LCRSNode node, int indent)
        {
            if (node == null) return;

            string pad = " ".PadLeft(indent);
            System.Console.WriteLine($"{pad}{node.Data}");

            PrintIndent(node.LeftChild, indent + 1);

            PrintIndent(node.RightSibling, indent);
        }
    }

    public class LCRSTreeTest
    {
        public static void Run()
        {
            LCRSTree tree = new LCRSTree("a");
            var a = tree.Root;
            var b = tree.AddChild(a, "b");
            tree.AddChild(a, "c");
            var d = tree.AddSibling(b, "d");
            tree.AddChild(b, "e");
            tree.AddChild(b, "f");
            tree.AddChild(d, "g");

            tree.PrintIndentTree();

            tree.PrintLevelOrder();
        }
    }
}