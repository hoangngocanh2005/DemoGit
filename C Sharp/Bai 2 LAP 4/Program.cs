using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2_LAP_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine(".............menu............ ");
                Console.WriteLine(" 1: Cong ");
                Console.WriteLine(" 2: Tru ");
                Console.WriteLine(" 3: Nhan ");
                Console.WriteLine(" 4: Chia ");
                Console.WriteLine(" 5: Thoat");

                Console.WriteLine(" nhap lua chon cua ban");
                int n = Convert.ToInt32(Console.ReadLine());

                double num1, num2;
                switch (n)
                {

                    case 1:

                        Console.WriteLine("Nhap so thu nhat: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Nhap so thu hai: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Ket qua la: " + (num1 + num2));
                        break;

                    case 2:

                        Console.WriteLine("Nhap so thu nhat: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Nhap so thu hai: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Ket qua la: " + (num1 - num2));
                        break;

                    case 3:

                        Console.WriteLine("Nhap so thu nhat: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Nhap so thu hai: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Ket qua la: " + (num1 * num2));
                        break;

                    case 4:

                        Console.WriteLine("Nhap so thu nhat: ");
                        num1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Nhap so thu hai: ");
                        num2 = Convert.ToDouble(Console.ReadLine());

                        if (num2 == 0)
                        {
                            Console.WriteLine("Khong chia duoc.");
                        }
                        else
                        {
                            Console.WriteLine("Ket qua la: " + (num1 / num2));

                        }
                        break;
                    case 5:
                        Console.WriteLine("thoat chuong trinh");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("lua chon khong hop le, vui long nhap lai ");
                        break;
                }
                Console.WriteLine("Bam mot phim bat ky de tiep tuc");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
