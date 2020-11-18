using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DataStructure
{
    public class Conccurent
    {
        public static void Run()
        {
            var s = new ConcurrentStack<int>();

            Task tPush = Task.Factory.StartNew(() => {
                for (int i = 0; i < 100; i ++)
                {
                    s.Push(i);
                    Thread.Sleep(100);
                }
            });

            Task tPop = Task.Factory.StartNew(() => {
                int n = 0;
                int result;
                while(n < 100)
                {
                    System.Console.WriteLine(string.Join(" ", s));
                    if (s.TryPop(out result))
                    {
                        Console.WriteLine("POP >>> " + result);
                        n++;
                    }

                    Thread.Sleep(150);
                }
            });

            Task.WaitAll(tPush, tPop);
        }
    }
}