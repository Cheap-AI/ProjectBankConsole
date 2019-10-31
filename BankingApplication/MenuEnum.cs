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
namespace BankAppModel
{
    public enum MenuEnum
    {
        Register,
        OpenAccount,
        Withdraw,
        Deposit,
        Transfer,
        PayInstallment,
        DisplayAccounts,
        DisplayTransactions
    }
}
