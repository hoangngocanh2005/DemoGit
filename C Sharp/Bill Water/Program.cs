using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Water
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.OutputEncoding = Encoding.UTF8;
                // Declare constants for water prices
                const double PRICE_LEVEL_1 = 5.973;
                const double PRICE_LEVEL_2 = 7.052;
                const double PRICE_LEVEL_3 = 8.699;
                const double PRICE_LEVEL_4 = 15.929;
                const double PRICE_FOR_AGENCIES = 9.955;
                const double PRICE_FOR_PRODUCTION = 11.615;
                const double PRICE_FOR_BUSINESS = 22.068;

                // Input information from the user
                Console.WriteLine("Enter the number of customers:");
                int numberOfCustomers = Convert.ToInt32(Console.ReadLine());

                // Declare arrays to store information of each customer
                string[] customerNames = new string[numberOfCustomers];
                double[] previousWaterConsumption = new double[numberOfCustomers];
                double[] currentWaterConsumption = new double[numberOfCustomers];
                int[] customerTypes = new int[numberOfCustomers];
                double[] waterUsage = new double[numberOfCustomers];
                double[] waterBills = new double[numberOfCustomers];
                int[] numberOfFamilyMembers = new int[numberOfCustomers];
                // Input information for each customer
                for (int i = 0; i < numberOfCustomers; i++)
                {
                    Console.WriteLine($"Enter information for customer {i + 1}:");
                    Console.WriteLine("Customer's name:");
                    customerNames[i] = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Customer type (1 - Household, 2 - Administrative agency, 3 - Production unit, 4 - Business service):");
                        customerTypes[i] = int.Parse(Console.ReadLine());
                        if (customerTypes[i] < 1 || customerTypes[i] > 4)
                        {
                            Console.WriteLine("Error: Invalid customer type! Please enter again.");
                        }

                    } while (customerTypes[i] < 1 || customerTypes[i] > 4);
                    if (customerTypes[i] == 1)
                    {
                        Console.WriteLine("Enter the number of family members:");
                        numberOfFamilyMembers[i] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Previous water meter reading:");
                    previousWaterConsumption[i] = double.Parse(Console.ReadLine());
                    Console.WriteLine("Current water meter reading:");
                    currentWaterConsumption[i] = double.Parse(Console.ReadLine());

                    // Check water consumption and prompt for re-entry if it's negative
                    while (currentWaterConsumption[i] < previousWaterConsumption[i])
                    {
                        Console.WriteLine("Error: Current water meter reading must be greater than or equal to the previous reading. Please enter again.");
                        Console.WriteLine("Current water meter reading:");
                        currentWaterConsumption[i] = double.Parse(Console.ReadLine());
                    }

                    // Calculate water usage and corresponding water bill for each customer
                    waterUsage[i] = currentWaterConsumption[i] - previousWaterConsumption[i];
                    switch (customerTypes[i])
                    {
                        case 1: // Household
                            double householdWaterUsagePerMember = waterUsage[i] / numberOfFamilyMembers[i];
                            if (householdWaterUsagePerMember <= 10)
                                waterBills[i] = householdWaterUsagePerMember * PRICE_LEVEL_1;
                            else if (householdWaterUsagePerMember <= 20)
                                waterBills[i] = householdWaterUsagePerMember * PRICE_LEVEL_2;
                            else if (householdWaterUsagePerMember <= 30)
                                waterBills[i] = householdWaterUsagePerMember * PRICE_LEVEL_3;
                            else
                                waterBills[i] = householdWaterUsagePerMember * PRICE_LEVEL_4;
                            break;
                        case 2: // Administrative agency
                            waterBills[i] = waterUsage[i] * PRICE_FOR_AGENCIES;
                            break;
                        case 3: // Production unit
                            waterBills[i] = waterUsage[i] * PRICE_FOR_PRODUCTION;
                            break;
                        case 4: // Business service
                            waterBills[i] = waterUsage[i] * PRICE_FOR_BUSINESS;
                            break;
                        default:
                            Console.WriteLine("Error: Invalid customer type!");
                            break;
                    }
                    // VAT, Environmental tax
                    waterBills[i] = waterBills[i] * 1.2;
                }

                // Sort in descending order by total bill
                for (int i = 0; i < numberOfCustomers - 1; i++)
                {
                    for (int j = i + 1; j < numberOfCustomers; j++)
                    {
                        if (waterBills[i] < waterBills[j])
                        {
                            // Swap information of two customers
                            double tempWaterBill = waterBills[i];
                            waterBills[i] = waterBills[j];
                            waterBills[j] = tempWaterBill;

                            string tempCustomerName = customerNames[i];
                            customerNames[i] = customerNames[j];
                            customerNames[j] = tempCustomerName;

                            double tempPreviousWaterConsumption = previousWaterConsumption[i];
                            previousWaterConsumption[i] = previousWaterConsumption[j];
                            previousWaterConsumption[j] = tempPreviousWaterConsumption;

                            double tempCurrentWaterConsumption = currentWaterConsumption[i];
                            currentWaterConsumption[i] = currentWaterConsumption[j];
                            currentWaterConsumption[j] = tempCurrentWaterConsumption;

                            int tempCustomerType = customerTypes[i];
                            customerTypes[i] = customerTypes[j];
                            customerTypes[j] = tempCustomerType;

                            double tempWaterUsage = waterUsage[i];
                            waterUsage[i] = waterUsage[j];
                            waterUsage[j] = tempWaterUsage;
                        }
                    }
                }

                // Display water bills information for each customer
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("   Customer Name    |   Previous Reading   |   Current Reading   |   Water Usage   |   Total Bill   ");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                for (int i = 0; i < numberOfCustomers; i++)
                {
                    Console.WriteLine($"{customerNames[i],20} | {previousWaterConsumption[i],19} | {currentWaterConsumption[i],19} | {waterUsage[i],14} | {waterBills[i],14}");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------");

                // Search for a customer
                Console.WriteLine("Enter the name of the customer to search:");
                string nameToSearch = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < numberOfCustomers; i++)
                {
                    if (customerNames[i].Equals(nameToSearch, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Customer '{nameToSearch}' found:");
                        Console.WriteLine($"  - Previous reading: {previousWaterConsumption[i]}");
                        Console.WriteLine($"  - Current reading: {currentWaterConsumption[i]}");
                        Console.WriteLine($"  - Water usage: {waterUsage[i]}");
                        Console.WriteLine($"  - Total bill: {waterBills[i]}");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"No customer with the name '{nameToSearch}' found.");
                }

                Console.ReadKey();
            }
        }
    }
}
