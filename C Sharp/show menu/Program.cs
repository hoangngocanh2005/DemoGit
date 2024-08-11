using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace show_menu
{
    internal class Program
    {
        static void Show_menu()
        {
            Console.WriteLine("__________MENU__________");
            Console.WriteLine(" 1: Cong ");
            Console.WriteLine(" 2: Tru ");
            Console.WriteLine(" 3: Nhan ");
            Console.WriteLine(" 4: Chia ");
            Console.WriteLine(" 5: Thoat ");
        }

        static string GetChoice()
        {
            Console.Write("Nhap vao lua chon cua ban: ");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Vui long nhap lai");
                choice = Console.ReadLine();
            }
            return choice;
        }
        static double GetNumber(string message)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Vui long nhap lai: ");
            }
            return number;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                //Console.WriteLine("Wellcome to Calculator Program");
                //Console.WriteLine("==============================");

                //Gọi hàm Getchoice(), gán giá trị luachon = giá trị trả về của hàm GetChoice()
                Show_menu();

                //Kiểm tra, nếu luachon = 5 (thoat) thì kết thúc chương trình
                string luachon = GetChoice();
                if (luachon == "5")
                {
                    break;
                }
                //Console.WriteLine("Lua chon cua ban la: " + luachon);

                //Lấy num1 từ bàn phím bằng hàm GetChoice()
                double num1 = GetNumber("Nhap vao so thu nhat: ");

                //Console.WriteLine("So thu nhat la: " + num1);

                //Lấy num2 từ bàn phím bằng hàm GetChoice()
                double num2 = GetNumber("Nhap vao so thu hai: ");

                //Console.WriteLine("So thu 2 la: " + num2);

                double check = Calculator(luachon, num1, num2);
                Console.WriteLine("Ket qua la: " + check);
                Console.ReadLine();
            }
            
        }
        static double Calculator(string choice, double a, double b)
        {
            double result = 0;
            switch (choice)
            {
                case "1":
                    result = a + b;
                    break;
                case "2":
                    result = a - b;
                    break;
                case "3":
                    result = a * b;
                    break;
                case "4":
                    if (b == 0)
                    {
                        Console.WriteLine("Error");
                        break;
                    }
                    else
                    {
                        result = a / b;
                        Console.WriteLine("Ket qua la: " + result);
                    }
                    break;
            }
            return result;
        }
    }
}
