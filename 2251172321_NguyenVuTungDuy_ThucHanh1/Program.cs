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
        static int N ; 
        static int K ;
        static int X;
        static int[] A;
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
            do
            {
                Console.Write("Nhap N: ");
            }while (!int.TryParse(Console.ReadLine(), out N) );
            do
            {
                Console.Write("Nhap K: ");
            }while (!int.TryParse(Console.ReadLine(), out K) || K <= 1 || K>N);
            do
            {
                Console.Write("Nhap X: ");
            } while (!int.TryParse(Console.ReadLine(), out X));
            A = new int[N];
            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                A[i] = rnd.Next(1, 100); 
            }

            A[N - 1] = X;

            Console.WriteLine("Mang A:");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine(); 

            Thread[] threads = new Thread[K];

            int chunkSize = N / K;

            for (int i = 0; i < K; i++)
            {
                int start = i * chunkSize;
                int end = (i == K - 1) ? N : start + chunkSize;
                int threadId = i + 1;
                threads[i] = new Thread(() => TimSCP(threadId, start, end));
                threads[i].Start();
            }
            foreach (Thread t in threads) {t.Join();}
        }
    }
}
