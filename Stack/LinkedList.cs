using System;
namespace DataStructure
{
    public class StackUsingLinkedList
    {
        private Node top = null;
        public bool IsEmpty { get { return top == null; } }

        public void Push(object data)
        {
            if (top == null)
            {
                top = new Node(data);
            }
            else
            {
                var node = new Node(data);
                node.Next = top;
                top = node;
            }
        }

        public object Pop()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Empty");
            }

            object data = top.Data;
            top = top.Next;
            return data;
        }

        public object Peek()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Empty");
            }

            return top.Data;
        }
    }
}