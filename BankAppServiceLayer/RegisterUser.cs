using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BankAppModel;

namespace BankAppServiceLayer
{

    class RegisterUser
    {

        
            

        //Open text file which contains the user/password data
        //Check if the username exists
        //Write the username and password to the file
        public static void Register()
        {
            string ID = GetID();
            if (Globals.Customers.ContainsKey(ID) || IsInvalidID(ID))
            {
                Console.WriteLine("Invalid or ID already exists");
            }
            else
            {
                string Password = GetPassword();
                Globals.Customers.Add(ID, new BankAppModel.Customer(ID, Password));

                Console.WriteLine("Registered User");
                Console.WriteLine($"User name : {ID}");
            }




        }

        public static string GetID()
        {
            Console.Write("What do you want as your username: ");
            string InputID = Console.ReadLine();
            return InputID;
        }

        public static string GetPassword()
        {
            Console.Write("What do you want as your password? : ");
            string InputPassword = Console.ReadLine();
            return InputPassword;
        }

        public static bool IsInvalidID(string ID)
        {
            var IsInvalid = false;
            var List = new List<char> { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '=', '+' };
            foreach (char ch in List)
            {
                if (ID.Contains(ch))
                {
                    IsInvalid = true;
                    break;
                }
            }


            return IsInvalid;
        }
    }
}
