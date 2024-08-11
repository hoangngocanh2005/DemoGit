using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tính_tiền_nước
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Water Billing System!");

            // Input customer details
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter last month's water meter readings: ");
            double lastMonthReading = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter this month's water meter readings: ");
            double thisMonthReading = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter customer type (1: Household, 2: Administrative agency, 3: Production units, 4: Business services): ");
            int customerType = Convert.ToInt32(Console.ReadLine());

            int numberOfPeople = 0;
            if (customerType == 1)
            {
                Console.Write("Enter number of people in the household: ");
                numberOfPeople = Convert.ToInt32(Console.ReadLine());
            }

            // Calculate consumption
            double consumption = thisMonthReading - lastMonthReading;

            // Calculate bill based on customer type and consumption
            double rate = 0;
            double environmentFees = 0;

            if (customerType == 1) // Household customer
            {
                if (numberOfPeople <= 1)
                {
                    if (consumption <= 10)
                    {
                        rate = 5.973;
                    }
                    else if (consumption <= 20)
                    {
                        rate = 7.052;
                    }
                    else if (consumption <= 30)
                    {
                        rate = 8.699;
                    }
                    else
                    {
                        rate = 15.929;
                    }
                }
                else // More than 1 person
                {
                    rate = 15.929; // Rate for over 30 m3/people/month
                }
            }
            else if (customerType == 2) // Administrative agency, public services
            {
                rate = 9.955;
            }
            else if (customerType == 3) // Production units
            {
                rate = 11.615;
            }
            else if (customerType == 4) // Business services
            {
                rate = 22.068;
            }
            else
            {
                Console.WriteLine("Invalid customer type entered.");
                Environment.Exit(0);
            }

            // Calculate environment protection fees
            environmentFees = rate * 0.1;

            // Calculate total water bill
            double totalBill = (rate + environmentFees) * consumption;

            // Output the bill details
            Console.WriteLine("\nCustomer Name: " + customerName);
            Console.WriteLine("Last Month's Water Meter Readings: " + lastMonthReading);
            Console.WriteLine("This Month's Water Meter Readings: " + thisMonthReading);
            Console.WriteLine("Amount of Consumption: " + consumption);
            Console.WriteLine("Total Water Bill: " + totalBill.ToString("C")); // Display as currency

            Console.WriteLine("\nThank you for using the Water Billing System!");

            // Pause to view results before closing console window
            Console.ReadLine();
        }
    }
}
