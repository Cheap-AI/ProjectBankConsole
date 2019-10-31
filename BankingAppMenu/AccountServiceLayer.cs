using System;
using System.Collections.Generic;
using System.Text;
using BankAppModel;

namespace BankAppMenu
{
    class AccountServiceLayer
    {
        public static void CreateAccount()
        {
            int UserChoice = PromptAccountType();

            if (UserChoice == 1)
            {
                Globals.Customers[Globals.LoginID].Accounts.Add(new CheckingAccount());
                Console.WriteLine($"Your checking account is created with id: {Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].AccountID}" + $": {Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count-1]}");
            }
            else if (UserChoice == 2)
            {
                Globals.Customers[Globals.LoginID].Accounts.Add(new BusinessAccount());
                Console.WriteLine($"Your checking account is created with id: {Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].AccountID}" + $": {Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1]}");

            }
            else if (UserChoice == 3)
            {
                Globals.Customers[Globals.LoginID].Accounts.Add(new Loan());
                Console.Write("Type the number of months after Loan has been issued: ");
                int NTerms = Int32.Parse(Console.ReadLine());

                Console.WriteLine("How much would you like to borrow? ");
                Console.Write(" ");
                decimal LoanAmount = Decimal.Parse(Console.ReadLine());
                Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].Balance = -LoanAmount;

                Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].Balance = (decimal) Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].Balance * (decimal) Math.Pow(1+(double)(Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].InterestRate/12), (double) NTerms);

                Console.WriteLine("Your loan has been issued!");
                Console.WriteLine($"Your balance is {Globals.Customers[Globals.LoginID].Accounts[Globals.Customers[Globals.LoginID].Accounts.Count - 1].Balance} after annual interest rate is charged");
                System.Threading.Thread.Sleep(1000);
            }
            else if (UserChoice == 4)
            {
                Console.Write("Type the number of months for CD: ");
                int NTerms = Int32.Parse(Console.ReadLine());

                Console.WriteLine("What is your target: ");
                Console.Write(": ");
                decimal target = Decimal.Parse(Console.ReadLine());
                Globals.Customers[Globals.LoginID].Accounts.Add(new TermDeposit(target, NTerms));

                decimal MonthlyDeposit = (decimal) target/NTerms;
                decimal interest = target * (decimal) 0.1;
                Console.WriteLine($"Ok! Deposit {MonthlyDeposit} each month for the next {NTerms} months for {interest} interest");
            }
            else
            {
                Globals.Customers[Globals.LoginID].Accounts.Add(new CheckingAccount());
                Console.WriteLine(Globals.Customers[Globals.LoginID].Accounts.Count);
                foreach(IAccount acc in Globals.Customers[Globals.LoginID].Accounts)
                {
                    Console.WriteLine($"{acc.AccountID}");
                }
            }
        }

        public static void DeleteAccount()
        {
            DisplayAccounts();
            Console.WriteLine("You can only delete account with balance of $0");
            Console.Write("Which account would you like to delete?");
            int selection = Int32.Parse(Console.ReadLine());

            if(Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance != 0)
            {
                Console.WriteLine("You cannot delete the account because it has a remaining balance :(");
                Console.WriteLine("Redirecting to menu...");
                System.Threading.Thread.Sleep(1000);

                Menu.StartApp();
            }
            else
            {
                Globals.Customers[Globals.LoginID].Accounts.RemoveAt(selection - 1);
                Console.WriteLine("Account deleted successfully!");
            }
        }

        public static int PromptAccountType()
        {
            Console.WriteLine("Here are available Account types" + "\n" + "1. Checking Account" + "\n" + "2. Business Account \n" + "3. Set up a loan \n" + "4.Set up Term Deposit");
            Console.Write("Please choose your account type here: ");
            var UserChoice = Int32.Parse(Console.ReadLine());

            return UserChoice;
        }

        public static void DisplayAccounts()
        {
            int i = 1;
            foreach(IAccount acc in Globals.Customers[Globals.LoginID].Accounts)
            {
                Console.WriteLine(i + ". " + acc.ToString() + " Accound Id: " + acc.AccountID + " Account Balance: " + acc.Balance);
                i++;
            }
        }

        public static void DisplayAccountOptions()
        {
            Console.WriteLine("1. ");
        }

        public static void Deposit()
        {
            decimal amount = -1;

            DisplayAccounts();
            Console.Write("Choose an account: ");
            int selection = Int32.Parse(Console.ReadLine());



            while (amount < 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Deposit amount: ");
                amount = Decimal.Parse(Console.ReadLine());
                
            }



            Transaction trans = new Transaction("Deposit", amount);

            Globals.Customers[Globals.LoginID].Accounts[selection - 1].Transactions.Add(trans);
            Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance += amount;
            Console.WriteLine("Transaction Complete!");
            System.Threading.Thread.Sleep(1000);

        }

        public static void Withdraw()
        {
            decimal amount = -1;
            bool overdraft = false;

            DisplayAccounts();
            Console.Write("Choose an account: ");
            int selection = Int32.Parse(Console.ReadLine());

            if (Globals.Customers[Globals.LoginID].Accounts[selection - 1] is BusinessAccount)
            {
                overdraft = true;
            }
            if (overdraft)
            {
                while (amount < 0)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Withdraw amount: ");
                    amount = Decimal.Parse(Console.ReadLine());

                }
            }
            else
            {
                while (amount < 0 || amount > Globals.Customers[Globals.LoginID].Accounts[selection-1].Balance)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Withdraw amount: ");
                    amount = Decimal.Parse(Console.ReadLine());

                }
            }

            

            Transaction trans = new Transaction("Withdraw", amount);




            Globals.Customers[Globals.LoginID].Accounts[selection - 1].Transactions.Add(trans);
            Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance -= amount;

            if(Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance < 0)
            {
                Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance = (1+ (decimal) Globals.Customers[Globals.LoginID].Accounts[selection - 1].InterestRate)* Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance;
                Console.WriteLine($"You made an overdraft. New balance is {Globals.Customers[Globals.LoginID].Accounts[selection - 1].Balance} after interest charge");
            }

            Console.WriteLine("Transaction Complete!");
            System.Threading.Thread.Sleep(1000);

        }

        public static void TransferFund()
        {
            DisplayAccounts();
            Console.Write("Which account would you transfer the fund from: ");
            int selectionFrom = Int32.Parse(Console.ReadLine());

            DisplayAccounts();
            Console.Write("Which account would youtransfer the fun to: ");
            int selectionTo = Int32.Parse(Console.ReadLine());

            Console.Write("Enter amount:");
            decimal amount = Decimal.Parse(Console.ReadLine());

            if(amount > Globals.Customers[Globals.LoginID].Accounts[selectionFrom - 1].Balance || selectionFrom == selectionTo)
            {
                Console.WriteLine("Your options are invalid. Please try again");
                TransferFund();
            }
            else
            {
                Globals.Customers[Globals.LoginID].Accounts[selectionFrom - 1].Transactions.Add(new Transaction("Transfer (Withdraw)", amount));
                Globals.Customers[Globals.LoginID].Accounts[selectionFrom - 1].Balance -= amount;

                Globals.Customers[Globals.LoginID].Accounts[selectionFrom - 1].Transactions.Add(new Transaction("Transfer (Deposit)", amount));
                Globals.Customers[Globals.LoginID].Accounts[selectionFrom - 1].Balance += amount;
            }

            Console.WriteLine("Transfer Complete! (Redirecting to the menu...)");
            System.Threading.Thread.Sleep(1000);
        }

        public static void PayLoan()
        {
            Console.WriteLine("Your Loan is forgiven!");
            
        }
    }
}
