using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int giaithua = 1;
            int i = 1;

            if (n < 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine("Giai thu cua so " + i + " la: " + n + "");
            }
        }
    }
}
