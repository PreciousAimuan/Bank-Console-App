using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQ20.Net_Week5_Task.Accountepo
{
    public class TransactionHistory
    {
        public decimal Amount {  get; set; }
        public DateTime Date { get; set; }
        public string Narration {  get; set; }

        /*public TransactionHistory(decimal amount, DateTime date)
        {
            _amount = amount;
            _date = date;
        }*/

        //public Transaction()
        //{

        //        Date = DateTime.Now; // Set the date to the current date and time
        //        Amount = 0;


        //}
    }

}
