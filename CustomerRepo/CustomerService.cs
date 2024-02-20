using SQ20.Net_Week5_Task.Helper;
using SQ20.Net_Week5_Task.Model;
using SQ20.Net_Week5_Task.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQ20.Net_Week5_Task.CustomerRepo
{
    public class CustomerService
    {

        private static List<Customer> customers = new List<Customer>();

        public static void Register()
        {
            Customer customer = new Customer();

            // Validate and set FirstName
            while (true)
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstName) && !char.IsDigit(firstName[0]) && !char.IsLower(firstName[0]))
                {
                    customer.FirstName = firstName;
                    break;
                }
                Console.WriteLine("First Name should not start with a digit or a small letter.");
            }

            // Validate and set LastName
            while (true)
            {
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(lastName) && !char.IsDigit(lastName[0]) && !char.IsLower(lastName[0]))
                {
                    customer.LastName = lastName;
                    break;
                }
                Console.WriteLine("Last Name should not start with a digit or a small letter.");
            }

            // Validate and set Email
            while (true)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                if (Validation.IsValidEmail(email))
                {
                    customer.Email = email;
                    break;
                }
                Console.WriteLine("Invalid email format. Please try again.");
            }

            // Validate and set Password
            while (true)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if (Validation.IsStrongPassword(password))
                {
                    customer.Password = password;
                    break;
                }
                Console.WriteLine("Password should be minimum 6 characters that include alphanumeric and at least one special character (@, #, $, %, ^, &, !)");
            }


            // Initialize Accounts list
            customer.Accounts = new List<Account>();

            // Add customer to the list
            customers.Add(customer);

            Console.WriteLine("Registration successful.");

            Console.WriteLine("PRESS 2 TO LOGIN");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "2")
            {
                Login();
            }

        }

        public static Customer Login()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Customer customer = customers.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (customer != null)
            {
                Dashboard.displayDashboard(customer);
                //return customer;
            }
            else
            {
                Login();
                return null;
            }
            return customer;
        }

    }
}
