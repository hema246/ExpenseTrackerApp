using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Transactions;

namespace ExpenseTrackerApp
{

    class Tracker
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
        public Transaction Type { get; set; }


    }

    class Details
    {
        List<Tracker> tracker = new List<Tracker>();
        public double Income { get; set; }
        public double Expenses { get; set; }
        public void AddTransactions()
        {
            Console.WriteLine("Enter the title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();

            double amount = 0;

            Console.WriteLine("Enter the amount:");
            Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Date in the format(dd/mm/yyyy):");
            DateTime date=Convert.ToDateTime(Console.ReadLine());

            if (amount >= 0)
            {
                Income += amount;
            }
            else
            {
                Expenses += Math.Abs(amount);
            }
            tracker.Add(new Tracker { Title = title, Description = description, Amount = amount, Date = date });
            Console.WriteLine("Transaction Added");
        }
        public void ViewExpenses() 
        {
            Console.WriteLine("Expenses:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Tracker t in tracker)
            {
                if (t.Amount< 0)
                {
                    Console.WriteLine($"{t.Title}\t{t.Description}\t{t.Amount}\t{t.Date}");
                }
            }
        }
        public void ViewIncome()
        {
            foreach (Tracker t in tracker)
            {
                if (t.Amount >= 0)
                {
                    Console.WriteLine($"{t.Title}\t{t.Description}\t{t.Amount}\t{t.Date}");
                }
            }
        }
        public void CheckBalance()
        {
            double Balance = Income - Expenses;
            Console.WriteLine("Available Balance:"+ Balance);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("****** EXPENSE TRACKER APP *****");
            do
            {
                Console.WriteLine("1. Add transactions");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. Check Available Balance");

                Details details = new Details();
                try
                {
                    Console.WriteLine("Enter the choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                details.AddTransactions();
                                break;
                            }
                        case 2:
                            {
                                details.ViewExpenses();
                                break;
                            }
                        case 3:
                            {
                                details.ViewIncome();
                                break;
                            }
                        case 4:
                            {
                                details.CheckBalance();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Enter a Valid Option!");
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter in correct format");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }while(true);
        }
    }
}