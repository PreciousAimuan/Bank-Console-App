using SQ20.Net_Week5_Task.CustomerRepo;
using SQ20.Net_Week5_Task.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQ20.Net_Week5_Task
{
    public class StartMenu
    {
        public static void Authenticate()
        {
            Console.WriteLine("|--------------------------------------------|");
            Console.WriteLine("         WELCOME TO PRECIOUS' BANK");
            Console.WriteLine("|--------------------------------------------|");

            Console.WriteLine();

            Console.WriteLine("TO GET STARTED PRESS 1 TO REGISTER OR 2 TO LOGIN");
            Console.Write("ENTER INPUT: ");
            var input = Console.ReadLine();

            while (Validation.Choice(input) == false)
            {
                Console.WriteLine("RE-ENTER INPUT OF EITHER 1 OR 2");
                input = Console.ReadLine();
            }

            switch (input)
            {
                case "1":
                    CustomerService.Register();
                    break;

                case "2":
                    CustomerService.Login();
                    break;
            }

        }

    }
}
