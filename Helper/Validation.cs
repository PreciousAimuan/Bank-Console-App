using SQ20.Net_Week5_Task.Accountepo;
using SQ20.Net_Week5_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace SQ20.Net_Week5_Task.Helper
{
    public class Validation
    {
       
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
        }

        public static bool Choice(string accountChoice)
        {
            return !string.IsNullOrEmpty(accountChoice) && Regex.IsMatch(accountChoice, @"^[1-2]{1}$");
        }
       /* public static bool Dash(string accountChoice)
        {
            return !string.IsNullOrEmpty(accountChoice) && Regex.IsMatch(accountChoice, @"^[1-7]{1}$");
        }*/
        public static bool IsTwo(string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[2]{1}$");
        }
        public static bool IsStrongPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@#$%^&!]).{6,}$");
        }

        public static string GenerateAccountNumber()
        {
            // Generate a random 9-digit account number
            Random random = new Random();
            long accountNumber = random.Next(100000000, 999999999);

            // Append the remaining 2 digits to make it an 11-digit number
            //accountNumber = accountNumber * 100 + (type == AccountType.Savings ? 1 : 2);

            return accountNumber.ToString();
        }

        public static void Deposit(Account account)
        {
            Console.Write("Enter amount to deposit: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
                return;
            }
            Console.WriteLine("Enter Narration: ");
            var narration = Console.ReadLine();

            account.Balance += amount;

            Console.WriteLine($"Deposit of {amount} successful. New balance: {account.Balance}");

            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = narration
            };
            

        }













































































































































































































































    }



}

