using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Part1_Programming_7388_HoangNgocAnh_BH01635_SE07202
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                String name = GetCustomerName();

                string choice = CustomerType();

                if (choice == "5")
                {
                    break;
                }

                Console.WriteLine("Enter the previous month's water number: ");
                int last_month;
                while (!int.TryParse(Console.ReadLine(), out last_month))
                {
                    Console.WriteLine("Error");
                    Console.Write("Please re-enter the previous month's water number: ");
                }

                Console.WriteLine("Enter this month's water number: ");
                int this_month;

                while (!int.TryParse(Console.ReadLine(), out this_month))
                {
                    Console.WriteLine("Error");
                    Console.Write("Please re-enter this month's water number: ");
                }

                while (this_month < last_month)
                {
                    Console.WriteLine("Error");
                    Console.Write("Please re-enter this month's water number: ");
                    this_month = int.Parse(Console.ReadLine());
                }

                int WaterConsumption = this_month - last_month;
                double Price = Calculate(this_month - last_month, choice);
                double Bill = GetBill(Price);
                double totalbill = TotalBill(Bill);

                Console.WriteLine();
                Console.WriteLine($"------{name}'s Water Bill------");

                Console.WriteLine("_______________________________________");
                Console.WriteLine("       Price        |    " + Price + " VND");
                Console.WriteLine("_______________________________________");
                Console.WriteLine("        Bill        |    " + Bill + " VND");
                Console.WriteLine("_______________________________________");
                Console.WriteLine("     Total Bill     |    " + totalbill + " VND");
                Console.WriteLine("_______________________________________");

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();

            }
        }

        static string GetCustomerName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static void Menu()
        {
            Console.WriteLine("Customer Type: ");
            Console.WriteLine("1. House hold customer");
            Console.WriteLine("2. Adminnistrative agencies, public services");
            Console.WriteLine("3. Production unit");
            Console.WriteLine("4. Business services");
            Console.WriteLine("5. Exit");
        }

        //Get the customer type

        static string CustomerType()
        {
            Console.Write("Enter your type: ");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Error");
                Console.Write("Please re-enter the customer type: ");
                choice = Console.ReadLine();
            }
            return choice;

        }
        static double Calculate(int WaterConsumption, string choice)
        {
            double Price = 0;
            switch (choice)
            {
                case "1":
                    if (WaterConsumption <= 10)
                    {
                        Price = WaterConsumption * 5.972;
                    }
                    else  if (WaterConsumption > 10 && WaterConsumption <= 20)
                    {
                        Price = ((WaterConsumption - 10) * 7.052) + 10 * 5.972;
                    }
                    else if (WaterConsumption > 20 && WaterConsumption <= 30)
                    {
                        Price = ((WaterConsumption - 10) * 8.699) + 10 * 7.052 + 10 * 5.972;
                    }
                    else
                    {
                        Price = ((WaterConsumption - 10) * 15.929) + 10 * 8.699 + 10 * 7.052 + 10 * 5.972;
                    }
                    break;
                case "2":
                    Price = WaterConsumption * 9.955;
                    break;
                case "3":
                    Price = WaterConsumption * 11.615;
                    break;
                case "4":
                    Price = WaterConsumption * 22.068;
                    break;
            }
            return Price;

        }
        static double GetBill(double Price)
        {
            double env = 0.1;
            double Bill = 0;
            Bill = Price * env + Price;
            return Bill;
        }
        static double TotalBill(double Bill)
        {
            double VAT = 0.1;
            double TotalBill = 0;
            TotalBill = Bill * VAT + Bill;
            return TotalBill;
        }
    }
}
