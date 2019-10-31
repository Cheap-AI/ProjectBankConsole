using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace BankAppModel
{

    public interface IAccount
    {
        int AccountID { get; set; }
        decimal Balance { get; set; }
        List<Transaction> Transactions { get; set; }

        double InterestRate { get; set; }

    }

    public class Loan : IAccount
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public int NumberofTerms { get; set; }

        public double InterestRate { get; set; } = 0.2;

        public Loan(double InterestRate = 0.2){
            this.InterestRate = InterestRate;
        }


    }

    public class TermDeposit : IAccount
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public double InterestRate { get; set; } = 0.1;

        public int MaturityMonths { get; set; } = 12;

        public decimal Target { get; set; }

        public TermDeposit(decimal target, int months, double InterestRate = 0.1)
        {
            this.InterestRate = InterestRate;
            this.Target = target;
            this.MaturityMonths = months;

        }


    }
    public class CheckingAccount : IAccount {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }

        public double InterestRate { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        
        public CheckingAccount()
        {
            this.Balance = 0;
            //Transactions = new List<float>;
            this.AccountID = 1000000+ Globals.Customers.Count*100 + Globals.Customers[Globals.LoginID].Accounts.Count;
            
        }
        public void CreateAccount()
        {
            CheckingAccount NewAccount = new CheckingAccount();
        }

        public virtual void WriteBalance(float Balance)
        {
            Console.WriteLine($"Remaining Balance: {this.Balance }");
        }

        public virtual void Withdraw(double HowMuch)
        {
            Console.WriteLine($"{HowMuch} withdrawn from your Account");
        }

        public virtual void Deposit(double HowMuch)
        {
            Console.WriteLine($"{HowMuch} withdrawn from your Account");
        }
    }

    public class BusinessAccount : IAccount
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }

        public double InterestRate { get; set; } = 0.1;

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public BusinessAccount(){
            this.Balance = 0;
            this.AccountID = 1000000 + Globals.Customers.Count * 100 + Globals.Customers[Globals.LoginID].Accounts.Count;

        }

        public void WriteBalance(float Balance)
        {
            Console.WriteLine($"This is Checking Balance");
        }
    }

    
}
