using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_tinh_tong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so n: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            int sum = 0;

            Console.WriteLine("Nhap gia tri cho cac phan tu trong mang: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"numbers[{i}]: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine($"Tong cac phan tu trong mang la: " + sum);
        }
    }
}
