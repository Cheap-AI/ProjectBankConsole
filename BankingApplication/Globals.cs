using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppModel
{
    public static class Globals
    {
        public static Dictionary<string, Customer> Customers { get; set; } = new Dictionary<string, Customer>();
        public static bool LoginStatus = false;
        public static string LoginID = null;
        public static string Customer = "Customer";
    }
}
