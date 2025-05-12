using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2251172321_NguyenVuTungDuy_ThucHanh1
{
    internal class Program
    {
        static int N = 1000; 
        static int K = 3;
        static int[] A = new int[N];
        static object lockObj = new object();

        static List<(int ThreadId, int Value, DateTime Time)> results = new List<(int, int, DateTime)>();
        static bool CheckSCP(int n)
        {
            int can = (int)Math.Sqrt(n);
            return can * can == n;
        }
        static void TimSCP(int threadId, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (CheckSCP(A[i]))
                {
                    DateTime now = DateTime.Now;

                    lock (lockObj)
                    {
                        results.Add((threadId, A[i], now));
                    }

                    Console.WriteLine($"T{threadId}: {A[i]} : {now:HH:mm:ss}");
                }
                Thread.Sleep(1);
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next(1, 10000); 
            }

            Thread[] threads = new Thread[K];
            int chunkSize = N / K;

            for (int i = 0; i < K; i++)
            {
                int start = i * chunkSize;
                int end = (i == K - 1) ? N : (i + 1) * chunkSize;
                int threadId = i + 1;
                threads[i] = new Thread(() => TimSCP(threadId, start, end));
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

        }
    }
}
