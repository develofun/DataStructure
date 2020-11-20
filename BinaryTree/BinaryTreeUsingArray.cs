using System;
namespace DataStructure
{
    public class BinaryTreeUsingArray
    {
        private object[] arr;
        public object Root { get { return arr[0]; } set { arr[0] = value; }}

        public BinaryTreeUsingArray(int capacity = 5)
        {
            arr = new object[capacity];
        }

        public void SetLeft(int parentIndex, object data)
        {
            int leftIndex = (parentIndex * 2) + 1;

            if (arr[parentIndex] == null || leftIndex >= arr.Length)
            {
                throw new ApplicationException("Error");
            }

            arr[leftIndex] = data;
        }

        public void SetRight(int parentIndex, object data)
        {
            int rightIndex = (parentIndex * 2) + 2;

            if (arr[parentIndex] == null || rightIndex >= arr.Length)
            {
                throw new ApplicationException("Error");
            }

            arr[rightIndex] = data;
        }

        public object GetParent(int childIndex)
        {
            if(childIndex == 0) return null;

            int parentIndex = (childIndex - 1) / 2;
            return arr[parentIndex];
        }

        public object GetLeft(int parentIndex)
        {
            int leftIndex = (parentIndex * 2) + 1;
            return arr[leftIndex];
        }

        public object GetRight(int parentIndex)
        {
            int rightIndex = (parentIndex * 2) + 2;
            return arr[rightIndex];
        }

        public void PrintTree()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("{0} ", arr[i] ?? "-");
            }

            System.Console.WriteLine();
        }
    }

    public class BinaryTreeUsingArrayTest
    {
        public static void Run()
        {
            var bt = new BinaryTreeUsingArray(7);
            bt.Root = "a";
            bt.SetLeft(0, "b");
            bt.SetRight(0, "c");
            bt.SetLeft(1, "d");
            bt.SetLeft(2, "f");

            bt.PrintTree();

            var data = bt.GetParent(5);
            System.Console.WriteLine(data);

            data = bt.GetLeft(2);
            System.Console.WriteLine(data);
        }
    }
}