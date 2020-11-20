using System;
namespace DataStructure
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }
        
        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }

    public class Node2
    {
        public string Data { get; set; }

        public Node2 Left { get; set; }
        public Node2 Right { get; set; }
        
        public Node2(string data)
        {
            Data = data;
        }
    }

    public class QueueUsingLinkedList
    {
        private Node head = null;
        private Node tail = null;

        public void Enqueue(object data)
        {
            if (head == null)
            {
                head = new Node(data);
                tail = head;
            }
            else
            {
                tail.Next = new Node(data);
                tail = tail.Next;
            }
        }
        public object Dequeue()
        {
            if (head == null)
            {
                throw new ApplicationException("Empty");
            }

            object data = head.Data;
            
            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
            }

            return data;
        }
    }
}