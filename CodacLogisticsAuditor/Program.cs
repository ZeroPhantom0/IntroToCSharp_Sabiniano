/*
 * Codac Logistics Delivery & Fuel Auditor
 * ----------------------------------------
 * This console application tracks a driver's weekly fuel expenses,
 * validates total distance traveled, calculates fuel efficiency,
 * and determines if the driver stayed within budget.
 * 
 * Concepts Used:
 * - Data Types (string, int, double, decimal, bool)
 * - Input/Output (Console.ReadLine, String Interpolation)
 * - Validation using while loop
 * - 1D Array
 * - for loop and if/else logic
 */

using System;

class Program
{
    static void Main()
    {
        // string is used for text data (driver name)
        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();

        // decimal is used for money to avoid floating point rounding errors
        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = Convert.ToDecimal(Console.ReadLine());

        // double is used for distance because it can contain decimal values
        double totalDistance = 0;

        // Validation loop ensures distance is between 1 and 5000
        while (true)
        {
            Console.Write("Enter Total Distance Traveled this week (1 - 5000 km): ");
            totalDistance = Convert.ToDouble(Console.ReadLine());

            if (totalDistance >= 1.0 && totalDistance <= 5000.0)
            {
                break; // Exit loop if valid
            }
            else
            {
                Console.WriteLine("Invalid distance! Please enter a value between 1 and 5000.");
            }
        }

        // 1D array to store 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];

        decimal totalFuelSpent = 0;

        // for loop to collect 5 days of expenses
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = Convert.ToDecimal(Console.ReadLine());

            // accumulate total fuel spent
            totalFuelSpent += fuelExpenses[i];
        }

        // Calculate average daily expense
        decimal averageFuelExpense = totalFuelSpent / fuelExpenses.Length;

        // Calculate fuel efficiency
        double efficiency = totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        // if/else for efficiency rating
        if (efficiency > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (efficiency >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        // bool is used to check if budget is respected
        bool isUnderBudget = totalFuelSpent <= weeklyBudget;

        // ===== AUDIT REPORT =====
        Console.WriteLine("\n===== CODAC LOGISTICS WEEKLY AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine("\nFuel Expenses Breakdown:");

        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]}");
        }

        Console.WriteLine($"\nTotal Fuel Spent: {totalFuelSpent}");
        Console.WriteLine($"Average Daily Fuel Expense: {averageFuelExpense}");
        Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");
    }
}