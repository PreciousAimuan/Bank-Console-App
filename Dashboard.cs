using SQ20.Net_Week5_Task.Accountepo;
using SQ20.Net_Week5_Task.CustomerRepo;
using SQ20.Net_Week5_Task.Model;
using SQ20.Net_Week5_Task.Model.Customer;
using System.ComponentModel.DataAnnotations;

namespace SQ20.Net_Week5_Task
{
    public class Dashboard
    {
        public static void displayDashboard(Customer customer)
        {
            Console.WriteLine("|--------------------------------------------|");
            Console.WriteLine("                MY DASHBOARD");
            Console.WriteLine("|--------------------------------------------|");

            Console.WriteLine();

            Console.WriteLine("TO GET STARTED PRESS 1 TO CREATE ACCOUNT, 2 TO DEPOSIT, 3 TRANSFER,  4  FOR WITHDRAWAL, 5 FOR ACCOUNT BALANCE, 6 FOR ACCOUNT STATEMENT, 7 FOR ACCOUNT DETAILS");
            Console.Write("ENTER INPUT: ");
            var input = Console.ReadLine();

            while (input != null)
            {
                switch (input)
                {
                    case "1":

                        AccountService.CreateAccount(customer);
                        break;

                    case "2":

                        AccountService.DepositIntoAccount(customer);
                        break;

                    case "3":

                        AccountService.Transfer(customer);
                        break;

                    case "4":

                        AccountService.WithdrawFromAccount(customer);
                        break;

                    case "5":

                        AccountService.GetAccountBalance(customer);
                        break;

                    case "6":

                        AccountService.GetAccountStatement(customer);
                        break;

                    case "7":
                        AccountService.GetAccountDetails(customer);
                        break;

                    default:
                        Console.Write("RE-ENTER INPUT: ");
                        input = Console.ReadLine();
                        break;

                }

            }
                  
        }

    }
}
