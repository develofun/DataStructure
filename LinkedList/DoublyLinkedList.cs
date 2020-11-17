using System;
namespace DataStructure
{
    public class DoublyLinkedListNode<T>
    {
        public T Data{ get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        private DoublyLinkedListNode<T> head;

        public DoublyLinkedListNode() {}
        public DoublyLinkedListNode(T data): this(data, null, null) {}

        public DoublyLinkedListNode(T data,
            DoublyLinkedListNode<T> prev,
            DoublyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while(current != null && current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
                newNode.Prev = current;
                newNode.Next = null;                
            }
        }

        public void AddAfter(
            DoublyLinkedListNode<T> current,
            DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                if(head != null)
                {
                    head.Prev = null;
                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }

            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
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
                cnt ++;
                current = current.Next;
            }

            return cnt;
        }
    }

    public class DoublyLinkedListNodeTest
    {
        public static void Run()
        {
            var list = new DoublyLinkedListNode<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = list.GetNode(2);
            list.Remove(node);

            node = list.GetNode(1);
            list.AddAfter(node, new DoublyLinkedListNode<int>(100));

            int count = list.Count();

            for(int i = 0; i < count; i++)
            {
                var n = list.GetNode(i);
                System.Console.WriteLine(n.Data);
            }

            node = list.GetNode(count - 1);
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(node.Data);
                node = node.Prev;
            }
        }
    }
}