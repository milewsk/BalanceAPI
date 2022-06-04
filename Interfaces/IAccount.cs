using BalanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Interfaces
{
     interface IAccount
    {


        List<Account> GetAccounts(int userId);

        Account GetAccount(int id);

        int CalculateFinalState(int id);

        
    }
}
