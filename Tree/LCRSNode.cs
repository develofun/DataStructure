namespace DataStructure
{
    public class LCRSNode
    {
        public object Data { get; set; }
        public LCRSNode LeftChild { get; set; }
        public LCRSNode RightSibling { get; set; }

        public LCRSNode(object data)
        {
            Data = data;
        }
    }

    public class LCRSNodeTest
    {
        public static void Run()
        {
            var a = new LCRSNode("A");
            var b = new LCRSNode("B");
            var c = new LCRSNode("C");
            var d = new LCRSNode("D");
            var e = new LCRSNode("E");
            var f = new LCRSNode("F");
            var g = new LCRSNode("G");

            a.LeftChild = b;
            b.RightSibling = c;
            c.RightSibling = d;
            b.LeftChild = e;
            e.RightSibling = f;
            d.LeftChild = g;

            if (a.LeftChild != null)
            {
                var tmp = a.LeftChild;
                System.Console.WriteLine(tmp.Data);

                while(tmp.RightSibling != null)
                {
                    tmp = tmp.RightSibling;
                    System.Console.WriteLine(tmp.Data);
                }
            }
        }
    }
}