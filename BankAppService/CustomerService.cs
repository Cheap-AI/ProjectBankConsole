﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BankAppModel;

namespace BankAppService
{

    class CustomerService
    {

        //Log in and out the user
        public static void Authenticate()
        {
            if (Globals.LoginStatus)
            {
                Globals.LoginStatus = false;
                Globals.LoginID = null;
                Console.WriteLine("You are logged out");
                
            }
            else
            {
                string RetrievedID = GetID();
                string RetrievedPassword = GetPassword();
                if (Globals.Customers.ContainsKey(RetrievedID) && Globals.Customers[RetrievedID].Password == RetrievedPassword)
                {
                    Globals.LoginStatus = true;
                    Globals.LoginID = RetrievedID;

                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            
            
        }


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
            Console.Write("Type your username: ");
            string InputID = Console.ReadLine();
            return InputID;
        }

        public static string GetPassword()
        {
            Console.Write("Type your password: ");
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
