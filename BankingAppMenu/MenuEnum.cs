using System;
using System.Collections.Generic;
using System.Text;


/* OPTIONS
Register
Open a new account
Close an account
Withdraw
Deposit
Transfer (between own accounts)
Pay Loan installment
Display list of accounts
Display transactions for an account
 */
namespace BankAppMenu
{
    public enum MenuEnum
    {
        Register = 1,
        OpenAccount,
        Withdraw,
        Deposit,
        Transfer,
        PayInstallment,
        DisplayAccounts,
        DisplayTransactions,
        NoChoice
    }
}
