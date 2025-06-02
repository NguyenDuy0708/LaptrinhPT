using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _2251172321_NguyenVuTungDuy_Thuchanh3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            Console.WriteLine("Server is running...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[8192];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                int[] numbers = data.Split(',').Select(int.Parse).ToArray();

                // Nhiệm vụ xử lý: đếm số nguyên tố
                int primeCount = numbers.Count(IsPrime);
                string result = $"Số lượng số nguyên tố trong mảng: {primeCount}";

                byte[] resultBytes = Encoding.UTF8.GetBytes(result);
                stream.Write(resultBytes, 0, resultBytes.Length);

                stream.Close();
                client.Close();
            }
        }
    }
}
