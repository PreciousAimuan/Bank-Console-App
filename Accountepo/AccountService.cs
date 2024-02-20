using SQ20.Net_Week5_Task.Helper;
using SQ20.Net_Week5_Task.Model;
using SQ20.Net_Week5_Task.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace SQ20.Net_Week5_Task.Accountepo
{
    public class AccountService
    {
        private static int _nextSavingsId = 1;
        private static int _nextCurrentId = 1;

        public static List<Account> accounts = new List<Account>();
        public static List<TransactionHistory> transactionHistory = new List<TransactionHistory>();

        public static List<Account> CreateAccount(Customer loggedInCustomer)
        {
            Console.WriteLine("Press 1 for Savings account or 2 for Current account:");
            var accountChoice = Console.ReadLine();
            while (Validation.Choice(accountChoice) == false)
            {
                Console.WriteLine("Enter 1 or 2");
                accountChoice = Console.ReadLine();
            }

            switch (accountChoice)
            {
                case "1":
                    var account = new Account
                    {
                        Id = _nextSavingsId,
                        AccountNumber = Validation.GenerateAccountNumber(),
                        Balance = 1000,
                        Type = AccountType.Savings
                    };
                    accounts.Add(account);
                    break;

                case "2":
                    account = new Account
                    {
                        Id = _nextCurrentId,
                        AccountNumber = Validation.GenerateAccountNumber(),
                        Balance = 0,
                        Type = AccountType.Current
                    };
                    accounts.Add(account);
                    break;
            }

            foreach (var item in accounts)
            {
                Console.WriteLine($"{loggedInCustomer.FirstName} {loggedInCustomer.LastName} {item.AccountNumber} {item.Balance} {item.Type}");
            }
            Console.WriteLine("Enter 1 to go back to dasboard or 2 to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();

            while (Validation.Choice(input) == false)
            {
                Console.WriteLine("Enter 1 or 2");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(loggedInCustomer);
            }
           /* else
            {
              
            }*/
            return accounts;
            
        }

        public static void DepositIntoAccount(Customer customer)
        {
            Console.WriteLine($"Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

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
            transactionHistory.Add(transaction);

            Console.WriteLine("Enter 1 to go back to dasboard or close the window exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }


        }

        public static void Transfer(Customer customer)
        {
            Console.WriteLine("Enter the account number for the account to transfer from:");
            string fromAccountNumber = Console.ReadLine();

            // Find the account to transfer from
            var fromAccount = accounts.FirstOrDefault(a => a.AccountNumber == fromAccountNumber);
            if (fromAccount == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine("Enter the account number for the account to transfer to:");
            string toAccountNumber = Console.ReadLine();

            // Find the account to transfer to
            var toAccount = accounts.FirstOrDefault(a => a.AccountNumber == toAccountNumber);
            if (toAccount == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            if (fromAccountNumber == toAccountNumber)
            {
                Console.WriteLine("Cannot transfer to the same account.");
                return;
            }

            Console.WriteLine($"Enter the amount to transfer from {fromAccountNumber} to {toAccountNumber}:");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
                return;
            }

            if (fromAccount.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            // Perform the transfer
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            Console.WriteLine($"Transfer of {amount} from account {fromAccountNumber} to account {toAccountNumber} successful.");

            // Record the transaction history
            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = $"Transfer to {toAccountNumber}"
            };
            transactionHistory.Add(transaction);

            Console.WriteLine("Enter 1 to go back to dasboard or close the window exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }
        }


        public static void WithdrawFromAccount(Customer customer)
        {
            

            Console.WriteLine($"Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Enter the amount to withdraw (current balance: {account.Balance}): ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
                return;
            }
            Console.Write("Enter Narration: ");
            var narration = Console.ReadLine();

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            account.Balance -= amount;
            Console.WriteLine($"Withdrawal of {amount} from account {accountNumber} successful. New balance: {account.Balance}");

            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = narration
            };
            transactionHistory.Add(transaction);

            Console.WriteLine("Enter 1 to go back to dasboard or close the window exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }
        }

        public static void GetAccountBalance(Customer customer)
        {
            Console.WriteLine("Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Current balance for account {accountNumber}: {account.Balance}");

            Console.WriteLine("Enter 1 to go back to dashboard or close the window to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }
        }


        public static void GetAccountStatement(Customer customer)
        {
            Console.WriteLine($"Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account statement for account {accountNumber}:");
            var table = new ConsoleTable("Account Number","Date", "Amount", "Narration");

            foreach (var transaction in transactionHistory)
            {
                 table.AddRow(account.AccountNumber, transaction.Date, transaction.Amount, transaction.Narration);
            }

            Console.WriteLine(table.ToString());

            Console.WriteLine($"Current balance for account {accountNumber}: {account.Balance}");

            Console.WriteLine("Enter 1 to go back to dashboard or close the window to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }
        }

        public static void GetAccountDetails(Customer customer)
        {
            Console.WriteLine($"Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account statement for account {accountNumber}:");
            var table = new ConsoleTable("FirstName", "LastName", "Account Number", "Account Type", "Account Balance");

            foreach (var item in accounts)
            {
                table.AddRow(customer.FirstName, customer.LastName, account.AccountNumber, account.Type, account.Balance);
            }

            Console.WriteLine(table.ToString());

            Console.WriteLine($"Current balance for account {accountNumber}: {account.Balance}");

            Console.WriteLine("Enter 1 to go back to dashboard or close the window to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Dashboard.displayDashboard(customer);
            }
        }






    }

}
