using SQ20.Net_Week5_Task.Accountepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SQ20.Net_Week5_Task.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public List<TransactionHistory> Transactions { get; set; }

        


    }

    
}
