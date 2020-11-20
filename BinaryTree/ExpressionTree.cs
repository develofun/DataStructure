using System.Linq;

namespace DataStructure
{
    public class ExpressionTree
    {
        public Node2 Root { get; set; }

        // post order expression        
        public void Build(string[] tokens)
        {
            int index = tokens.Length - 1;
            Root = Build(tokens, ref index);
        }

        private Node2 Build(string[] tokens, ref int index)
        {
            Node2 node = new Node2(tokens[index]);

            if (tokens[index] == "+" || tokens[index] == "-" || tokens[index] == "*" || tokens[index] == "/")
            {
                --index;
                node.Right = Build(tokens, ref index);

                --index;
                node.Left = Build(tokens, ref index);
            }

            return node;
        }

        public decimal Evaluate(Node2 root)
        {
            if (root == null) return 0;

            decimal left = Evaluate(root.Left);
            decimal right = Evaluate(root.Right);

            switch (root.Data)
            {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/": return left / right;
            }

            return decimal.Parse(root.Data);
        }

        public void Inorder(Node2 node)
        {
            if (node == null) return;

            if (IsOperator(node.Data))
            {
                System.Console.Write("(");
            }

            Inorder(node.Left);
            System.Console.Write($"{node.Data} ");
            Inorder(node.Right);

            if (IsOperator(node.Data))
            {
                System.Console.Write(")");
            }
        }

        public void Postorder(Node2 node)
        {
            if (node == null) return;

            Postorder(node.Left);
            Postorder(node.Right);
            System.Console.Write($"{node.Data} ");
        }

        private string[] op = {"+", "-", "*", "/"};
        private bool IsOperator(string token)
        {
            return op.Contains(token);
        }
    }

    public class ExpressionTreeTest
    {
        public static void Run()
        {
            var postfix = "10 4 / 3 5 * +".Split(" ");

            var et = new ExpressionTree();
            et.Build(postfix);

            System.Console.Write("Inorder: ");
            et.Inorder(et.Root);
            System.Console.WriteLine();

            System.Console.Write("Postorder: ");
            et.Postorder(et.Root);
            System.Console.WriteLine();

            var result = et.Evaluate(et.Root);
            System.Console.WriteLine($"Result: {result}");
        }
    }
}