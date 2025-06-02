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
        static object lockBuffer = new object(); 
        static Random random = new Random();

        static void Producer(object idObj)
        {
            int id = (int)idObj;
            while (true)
            {
                Thread.Sleep(random.Next(500, 1500)); 
                int value = random.Next(1, 100);  

                lock (lockBuffer)
                {
                    buffer.Enqueue(value); 
                    Console.WriteLine($"P{id}: {value} - {DateTime.Now:HH:mm:ss}");
                }
            }
        }
        static void Consumer(object idObj)
        {
            int id = (int)idObj;
            while (true)
            {
                int value = -1;

                lock (lockBuffer)
                {
                    if (buffer.Count > 0)
                    {
                        value = buffer.Dequeue();  
                    }
                }

                if (value != -1)
                {
                    Thread.Sleep(random.Next(800, 2000)); 
                    int result = value * 2;  
                    Console.WriteLine($"C{id}: lay {value} - {result} - {DateTime.Now:HH:mm:ss}");
                }
                else
                {
                    Thread.Sleep(random.Next(800, 2000));
                }
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Nhap k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Nhap h: ");
            int h = int.Parse(Console.ReadLine());

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