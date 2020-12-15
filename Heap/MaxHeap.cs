using System;
using System.Collections.Generic;

namespace Heap
{
    public class MaxHeap
    {
        private List<int> arr = new List<int>();

        public void Add(int data)
        {
            arr.Add(data);

            int i = arr.Count - 1;

            while (i > 0)
            {
                int parent = (i - 1) / 2;

                if (arr[i] > arr[parent])
                {
                    // swap
                    int tmp = arr[i];
                    arr[i] = arr[parent];
                    arr[parent] = tmp;
                    i = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public int Remove()
        {
            if (arr.Count == 0)
            {
                throw new ApplicationException();
            }

            int data = arr[0];

            arr[0] = arr[arr.Count - 1];
            arr.RemoveAt(arr.Count - 1);

            int i = 0;
            int last = arr.Count - 1;
            while (i < last)
            {
                int child = 2 * i + 1;

                if (child < last && arr[child] < arr[child + 1])
                {
                    child ++;
                }

                if (child > last || arr[i] >= arr[child])
                {
                    break;
                }

                // swap
                int tmp = arr[i];
                arr[i] = arr[child];
                arr[child] = tmp; 
                i = child;
            }

            return data;
        }

        internal void DebugDisplayArray()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                System.Console.Write("{0} ", arr[i]);
            }
            System.Console.WriteLine();
        }
    }

    public class MaxHeapTest
    {
        public static void Run()
        {
            var heap = new MaxHeap();
            heap.Add(20);
            heap.Add(15);
            heap.Add(12);
            heap.Add(13);
            heap.Add(10);
            heap.Add(9);
            heap.Add(11);
            heap.Add(7);
            heap.Add(6);

            heap.DebugDisplayArray();

            heap.Add(17);

            heap.DebugDisplayArray();

            int max = heap.Remove();
            System.Console.WriteLine(max);

            heap.DebugDisplayArray();
        }
    }
}