using System;
using System.Collections.Generic;
using System.Text;



namespace BankAppModel
{
    public interface ITransaction
    {
        System.DateTime DateTime { get; set; }
        string Action { get; set; }
        decimal Amount { get; set; }
        
    }

    public class Transaction : ITransaction
    {
        public System.DateTime DateTime { get; set; }

        public string Action { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string Action, decimal Amount){
            this.DateTime = System.DateTime.Now;
            this.Action = Action;
            this.Amount = Amount;
        }

    }
}
