using System;
using System.Collections.Generic;
using System.Text;
using BankAppModel;

namespace BankAppMenu
{
    class TransactionServiceLayer
    {
        public static void DisplayTransactions()
        {
            AccountServiceLayer.DisplayAccounts();
            Console.Write("Choose an account: ");
            int selection = Int32.Parse(Console.ReadLine());


            
            foreach(Transaction trans in Globals.Customers[Globals.LoginID].Accounts[selection - 1].Transactions)
            {
                Console.WriteLine($"{trans.Action} of {trans.Amount} at {trans.DateTime}");
            }
        }
 
    }
}
