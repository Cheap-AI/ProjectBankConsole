using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BankAppModel;
using BankAppService;





#nullable enable
namespace BankAppMenu
{
    delegate void SelectMenu(int Switch);
    
    class Menu
    {
        
        //readonly IDictionary<int, string> MenuItemList = new Dictionary<int, string>();
        public static int MenuSwitch { get; set; }
        public MenuEnum Item = new MenuEnum();
        
        //BankAppSer
        public Menu()
        {
            Item = MenuEnum.NoChoice;
            MenuSwitch = -1;
            
        }
        
        public static void StartApp()
        {
            MenuSwitch = -1;
            Console.WriteLine("\n" +
                "___________________________________________");
            Console.WriteLine($"Hello {Globals.Customer} :)\n" +
                "\n" +
                "0. Log in/Log out\n" +
                "1. Register\n" +
                "2. Open a New Account\n" +
                "3. Close Account\n" +
                "4. Withdraw\n" +
                "5. Deposit\n" +
                "6. Make a Transfer\n" +
                "7. Pay Loan Installment\n" +
                "8. Display List of Accounts\n" +
                "9. Display Transactions for an Account\n" 
                );
            if (Globals.LoginStatus)
            {
                Console.WriteLine("\n" + $"Logged in as {Globals.LoginID}" + "\n");
            }
            Console.WriteLine("__________________________________________ \n");

            Console.WriteLine("Please Enter the Number that matches your option");
            

            Menu.GetChoice();
            
            switch (MenuSwitch)
            {
                case 0:

                    
                    CustomerServiceLayer.Authenticate();

                    System.Threading.Thread.Sleep(1000);
                    break;

                case 1:
                    Console.WriteLine("Setting up for Register...");

                    CustomerServiceLayer.Register();
                    //Registered
                    System.Threading.Thread.Sleep(1000);
                    Menu.StartApp();
                    break;
                case 2:
                    CustomerServiceLayer.VerifyUser();

                    Console.WriteLine("Setting up for Open a New Account..");

                    //RegisterUser.Register();
                    AccountServiceLayer.CreateAccount();

                    System.Threading.Thread.Sleep(1000);
                    Menu.StartApp();
                    

                    break;
                case 3:
                    CustomerServiceLayer.VerifyUser();

                    AccountServiceLayer.DeleteAccount();
                    Console.WriteLine("Setting up for Close Account..");

                    Thread.Sleep(1000);
                    Menu.StartApp();
                    break;
                case 4:
                    CustomerServiceLayer.VerifyUser();

                    Console.WriteLine("Setting up for Withdraw..");

                    AccountServiceLayer.Withdraw();

                    Menu.StartApp();
                    break;
                case 5:
                    CustomerServiceLayer.VerifyUser();

                    Console.WriteLine("Setting up for Deposit..");

                    AccountServiceLayer.Deposit();

                    Menu.StartApp();
                    break;
                case 6:
                    Console.WriteLine("Setting up for Transfer..");

                    AccountServiceLayer.TransferFund();

                    Thread.Sleep(1000);

                    Menu.StartApp();
                    break;
                case 7:
                    Console.WriteLine("Setting up Pay Loan Installment..");
                    AccountServiceLayer.PayLoan();

                    Menu.StartApp();
                    break;
                case 8:
                    CustomerServiceLayer.VerifyUser();

                    Console.WriteLine("Setting up Display List of Accounts..");
                    AccountServiceLayer.DisplayAccounts();

                    System.Threading.Thread.Sleep(1000);
                    Menu.StartApp();
                    break;
                case 9:
                    CustomerServiceLayer.VerifyUser();

                    
                    Console.WriteLine("Setting up Transactions for an account..");
                    TransactionServiceLayer.DisplayTransactions();
                    Thread.Sleep(1000);

                    Menu.StartApp();
                    break;


                default:
                    Console.WriteLine("\nYou typed an invalid option number..");
                    Menu.StartApp();
                    break;

            }
        }
        public static void GetChoice()
        {
            
            Console.Write("Type a number:  "); // or Console.Write("Type any number:  "); to enter number in the same line
            try
            {
                Menu.MenuSwitch = Int32.Parse(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("\n" + e.Message);

            }
            finally
            {
                if (MenuSwitch == -1)
                {
                    GetChoice();
                }
            }
        }
    }
}
