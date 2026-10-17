
using System;
using System.Collections.Generic;

class Expense
{
    public string Description { get; set; }
    public string Category { get; set; }
    public double Amount { get; set; }

    public Expense(string description, string category, double amount)
    {
        Description = description;
        Category = category;
        Amount = amount;
    }
}

class ExpenseTracker
{
    private List<Expense> expenses = new List<Expense>();

    public void AddExpense()
    {
        try
        {
            Console.Write("Enter expense description: ");
            string description = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.");

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.");

            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            if (amount <= 0)
                throw new ArgumentException(
                    "Amount must be greater than zero.");

            expenses.Add(new Expense(description, category, amount));

            Console.WriteLine("Expense added successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric amount.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Add expense operation completed.");
        }
    }

    public void ViewExpenses()
    {
        try
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            Console.WriteLine("\n--- Expense List ---");

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(
                    $"Description: {expense.Description}, " +
                    $"Category: {expense.Category}, " +
                    $"Amount: Rs. {expense.Amount:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error displaying expenses: " + ex.Message);
        }
    }

    public void ShowTotal()
    {
        try
        {
            double total = 0;

            foreach (Expense expense in expenses)
            {
                total += expense.Amount;
            }

            Console.WriteLine($"Total Expenses: Rs. {total:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calculating total: " + ex.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        ExpenseTracker tracker = new ExpenseTracker();
        bool running = true;

        while (running)
        {
            try
            {
                Console.WriteLine("\n=== Expense Tracking Module ===");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. Show Total Expenses");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        tracker.AddExpense();
                        break;

                    case "2":
                        tracker.ViewExpenses();
                        break;

                    case "3":
                        tracker.ShowTotal();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine(
                            "Invalid choice. Please select 1 to 4.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application error: " + ex.Message);
            }
        }
    }
}
