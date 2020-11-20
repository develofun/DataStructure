namespace DataStructure
{
    public class TreeNode
    {
        public object Data { get; set; }
        public TreeNode[] Links { get; set; }

        public TreeNode(object data, int maxDegree = 3)
        {
            Data = data;
            Links = new TreeNode[maxDegree];
        }
    }

    public class TreeNodeTest
    {
        public static void Run()
        {
            var a = new TreeNode("A");
            var b = new TreeNode("B");
            var c = new TreeNode("C");
            var d = new TreeNode("D");

            a.Links[0] = b;
            a.Links[1] = c;
            a.Links[2] = d;

            b.Links[0] = new TreeNode("E");
            b.Links[1] = new TreeNode("F");

            d.Links[0] = new TreeNode("G");

            foreach (var node in a.Links)
            {
                System.Console.WriteLine(node.Data);
            }
        }
    }
}