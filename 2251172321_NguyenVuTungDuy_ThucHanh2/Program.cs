using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2251172321_NguyenVuTungDuy_ThucHanh2
{
    internal class Program
    {
        static Queue<int> buffer = new Queue<int>();
        static int max = 200;

        static SemaphoreSlim empty = new SemaphoreSlim(200); 
        static SemaphoreSlim full = new SemaphoreSlim(0);    

        static object lockBuffer = new object();

        static Random random = new Random();

        static void Producer(object idObj)
        {
            int id = (int)idObj;

            while (true)
            {
                Thread.Sleep(random.Next(500, 1500)); 

                int value = random.Next(1, 100); 

                empty.Wait();

                lock (lockBuffer)
                {
                    buffer.Enqueue(value);
                    Console.WriteLine($"P{id}: {value} - {DateTime.Now:HH:mm:ss}");
                }

                full.Release(); 
            }
        }
        static void Consumer(object idObj)
        {
            int id = (int)idObj;

            while (true)
            {
                Thread.Sleep(random.Next(800, 2000)); 

                full.Wait(); 

                int value;
                lock (lockBuffer)
                {
                    value = buffer.Dequeue(); 
                }

                empty.Release(); 

                int result = value * 2; 

                Console.WriteLine($"C{id}: {value} - {result} - {DateTime.Now:HH:mm:ss}");
            }

        }
        static void Main(string[] args)
        {
            int k = 2; 
            int h = 2; 
            for (int i = 1; i <= k; i++)
            {
                new Thread(Producer).Start(i);
            }

            for (int i = 1; i <= h; i++)
            {
                new Thread(Consumer).Start(i);
            }

            Thread.Sleep(Timeout.Infinite);
        }
    }
}