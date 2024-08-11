using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM_Part1_Programming_7388_Hoàng_Ngọc_Anh_BH01635_SE07202
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfCustomer = 0;
            Console.WriteLine("Enter the number of customers: ");
            sizeOfCustomer = int.Parse(Console.ReadLine());

            string[] name = new string[sizeOfCustomer];
            double[] lastIndex = new double[sizeOfCustomer];
            double[] currentIndex = new double[sizeOfCustomer];
            int[] type = new int[sizeOfCustomer];
            int[] number = new int[sizeOfCustomer];
            double[] Consume = new double[sizeOfCustomer];
            double[] Money = new double[sizeOfCustomer];
            double[] amountowed = new double[sizeOfCustomer];

            for (int i = 0; i < sizeOfCustomer; i++)
            {
                Console.WriteLine("Enter customer information " + (i + 1));
                Console.WriteLine("Enter the customer's name: ");
                name[i] = Console.ReadLine();

                Console.WriteLine("Enter last month's water meter readings");
                lastIndex[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter this month's water meter readings");
                currentIndex[i] = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter customer type: 1. Household  2. Administrative agencies and public services  3. Production unit  4. Business service: ");
                type[i] = int.Parse(Console.ReadLine());

                if (type[i] == 1)
                {
                    Console.WriteLine("Enter number of people in household: ");
                    number[i] = int.Parse(Console.ReadLine());
                }

                Consume[i] = currentIndex[i] - lastIndex[i];
                double Ratio = WaterBill(type[i], (int)Consume[i], number[i]);
                Money[i] = Ratio * 1.2;
                amountowed[i] = Money[i];

                Console.WriteLine("Invoice for " + name[i] + ":");
                Console.WriteLine("Last month's water meter readings: " + lastIndex[i]);
                Console.WriteLine("This month's water meter readings: " + currentIndex[i]);
                Console.WriteLine("Consumption amount: " + Consume[i]);
                Console.WriteLine("Total water bill: " + Money[i]);
                Console.WriteLine("------------------------------------------");
            }

            Displayamountowed(name, amountowed, sizeOfCustomer);

            MakePayment(name, amountowed);

            BubbleSort(name, Money, lastIndex, currentIndex, Consume, sizeOfCustomer);

            DisplayCustomers(name, lastIndex, currentIndex, Consume, Money, sizeOfCustomer);


            Console.WriteLine("Enter the customer's name you want to search: ");
            string searchName = Console.ReadLine();
            SearchCustomer(name, lastIndex, currentIndex, Consume, Money, searchName, sizeOfCustomer);


        }

        static double WaterBill(int type, int Consume, int number)
        {
            double Bill = 0;

            switch (type)
            {
                case 1:
                    if (Consume < 10)
                        Bill = 5.973 * Consume;
                    else if (Consume < 20)
                        Bill = (5.973 * 10) + (7.052 * (Consume - 10));
                    else if (Consume < 30)
                        Bill = (5.973 * 10) + (7.052 * 10) + (8.699 * (Consume - 20));
                    else
                        Bill = (5.973 * 10) + (7.052 * 10) + (8.699 * 10) + (15.929 * (Consume - 30));
                    break;

                case 2:
                    Bill = 9.955 * Consume;
                    break;

                case 3:
                    Bill = 11.615 * Consume;
                    break;

                case 4:
                    Bill = 22.068 * Consume;
                    break;

                default:
                    Console.WriteLine("Invalid customer type. ");

                    break;
            }
            return Bill;
        }

        static void Displayamountowed(string[] name, double[] amountowed, int sizeOfCustomer)
        {
            Console.WriteLine("===========amount the customer needs to pay :=============");
            for (int i = 0; i < sizeOfCustomer; i++)
            {
                Console.WriteLine("Customer name:" + name[i] + "\tamount owed: " + amountowed[i]);
            }
        }

        static void MakePayment(string[] name, double[] amountowed)
        {
            Console.WriteLine("Do you want to make a payment? (yes/no): ");
            string response = Console.ReadLine();
            if (response.ToUpper() == "YES")
            {
                while (true)
                {
                    Console.WriteLine("Enter the customer's name you want to make a payment for: ");
                    string customerName = Console.ReadLine();

                    int index = Array.IndexOf(name, customerName);

                    if (index != -1)
                    {
                        Console.WriteLine("Enter the amount you want to pay: ");
                        double paymentAmount;
                        if (double.TryParse(Console.ReadLine(), out paymentAmount))
                        {
                            amountowed[index] -= paymentAmount;
                            Console.WriteLine("Payment successful. Updated remaining balance for " + customerName + ": " + amountowed[index]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for payment amount. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid customer name. Please enter a valid customer name.");
                    }
                }

            }
        }
        static void SearchCustomer(string[] name, double[] lastIndex, double[] currentIndex, double[] Consume, double[] Money, string searchName, int sizeOfCustomer)

        {
            for (int i = 0; i < sizeOfCustomer; i++)
            {
                if (name[i].Equals(searchName))
                {
                    Console.WriteLine("===========Customer found:=============");
                    Console.WriteLine("Customer name:" + name[i] + "\tLast month's water meter readings: " + lastIndex[i] + "\tThis month's water meter readings: " + currentIndex[i] + "\tConsumption amount: " + Consume[i] + "\tTotal water bill: " + Money[i]);

                }
            }

            Console.ReadKey();
        }

        static void DisplayCustomers(string[] name, double[] lastIndex, double[] currentIndex, double[] Consume, double[] Money, int sizeOfCustomer)
        {
            Console.WriteLine("===========Sorted list of customers:=============");
            for (int i = 0; i < sizeOfCustomer; i++)
            {
                Console.WriteLine("Customer name:" + name[i] + "\tLast month's water meter readings: " + lastIndex[i] + "\tThis month's water meter readings: " + currentIndex[i] + "\tConsumption amount: " + Consume[i] + "\tTotal water bill: " + Money[i]);
            }
        }
        static void BubbleSort(string[] name, double[] Money, double[] lastIndex, double[] currentIndex, double[] Consume, int sizeOfCustomer)
        {
            for (int i = 0; i < sizeOfCustomer - 1; i++)
            {
                for (int j = i + 1; j < sizeOfCustomer; j++)
                {
                    if (Money[i] < Money[j])
                    {
                        string nameTemp = name[i];
                        name[i] = name[j];
                        name[j] = nameTemp;

                        double MoneyTemp = Money[i];
                        Money[i] = Money[j];
                        Money[j] = MoneyTemp;

                        double LastIndexTemp = lastIndex[i];
                        lastIndex[i] = lastIndex[j];
                        lastIndex[j] = LastIndexTemp;

                        double CurrentIndexTemp = currentIndex[i];
                        currentIndex[i] = currentIndex[j];
                        currentIndex[j] = CurrentIndexTemp;

                        double ConsumeTemp = Consume[i];
                        Consume[i] = Consume[j];
                        Consume[j] = ConsumeTemp;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}