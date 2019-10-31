using System;
using System.Collections.Generic;
using System.Text;
using BankAppModel;

namespace BankAppMenu
{
    class CreateNewAccount
    {
        public static void Create()
        {
            Console.Write("Choose the account type: ");
            string InputAccountType = GetAccountType();

            if (InputAccountType == "1")
            {

            }
        }

        public static string GetAccountType()
        {
            Console.WriteLine("1. Checking Account \n" +
                "2. Business Account \n" +
                "Type 1 to create Checking Account and 2 to create Business account");
            string InputAccountType = Console.ReadLine();
            return InputAccountType;
        }
    }
}
