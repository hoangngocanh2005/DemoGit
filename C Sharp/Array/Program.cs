using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //khai báo biến: đếm bắt đầu từ 0 từ trái qua phải
            //int[] st_grades = { 7, 8, 9, 6, 7, 9, 5 };
            //Console.WriteLine("Do dai cua mang la: " + st_grades.Length);

            //int[] st_grades2;
            //int st_1 = st_grades[3];
            //int st_2 = st_grades[6];

            //Console.WriteLine(st_1);
            //Console.WriteLine(st_2);



            //

            int[] st_grades2;
            st_grades2 = new int[5];
            Console.WriteLine("Nhap vao gia tri cho cac phan tu cua mang");
            for (int i = 0; i < st_grades2.Length; i++)
            {
                
                Console.Write($"st_grades2[{i}]: ");
                st_grades2[i] = int.Parse(Console.ReadLine());
            }    

            for (int i = 0;i < st_grades2.Length; i++)
            {
                Console.WriteLine($"Gia tri cua phan tu {i} trong mang la: {st_grades2[i]}");
            }
        }
    }
}
