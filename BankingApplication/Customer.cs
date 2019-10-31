using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppModel
{
    interface ICustomer
    {
        //bool IsVerified { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        
        List<IAccount> Accounts { get; set; }

        void Deposit();
        void Withdraw();


    }

    public class Customer : ICustomer
    {
        //public bool IsVerified { get; set; }

        public List<IAccount> Accounts { get; set; }
        
        public int Id { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }


        public Customer()
        {
        }

        public Customer(string ID, string Password)
        {
            //this.IsVerified = false;
            Accounts = new List<IAccount>();
            this.Name = Name;
            this.Password = Password;
        }
        public void Deposit() {
            Console.WriteLine("Deposit Complete");
        }
        public void Withdraw(){
            Console.WriteLine("Withdrawal Complete");
        }

    }
}
