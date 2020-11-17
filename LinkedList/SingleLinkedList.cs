namespace DataStructure
{
    public class SinglyLinkedListNode<T>
    {
        public T Data{ get; set; }
        public SinglyLinkedListNode<T> Next{ get; set; }
        private SinglyLinkedListNode<T> head;
        private SinglyLinkedListNode<T> tail;

        public SinglyLinkedListNode() {}

        public SinglyLinkedListNode(T data)
        {
            this.Data= data;
            this.Next = null;
        }

        public void Add(SinglyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else if (tail == null)
            {
                var current = head;
                while(current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            else
            {
                tail.Next = newNode;
            }

            tail = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            if (head == null || tail == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;

                while(current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;

            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;
            while(current != null)
            {
                cnt++;
                current = current.Next;
            }

            return cnt;
        }
    }

    public class SinglyLinkedListTest
    {
        public static void Run() 
        {
            var list = new SinglyLinkedListNode<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node, new SinglyLinkedListNode<int>(100));

            int count = list.Count();

            for (int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                System.Console.WriteLine(n.Data);
            }
        }
    }
}