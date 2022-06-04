using BalanceAPI.Context;
using BalanceAPI.Interfaces;
using BalanceAPI.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BalanceAPI.Data
{
    public class AccountsData : IAccount
    {
        public AccountsData() { }

        public List<Account> GetAccounts(int userId)
        {
            using(var context = new ApplicationDbContext())
            {
                var query = (from x in context.Accounts where userId == x.UserId select x);

                if (query.Count() > 0)
                {
                    return query.ToList();
                }
                else { return null; }
            }
        }

        public Account GetAccount(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                try { 
                    var query = (from x in context.Accounts where x.AccountId == id select x).First();
                    return query;
                }
                catch(ArgumentNullException e)
                {  
                    throw e;
                }      
            }
        }

        public Account GetAccount(string code, string email)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var user = (from y in context.Users where email == y.Email select y).FirstOrDefault();
                    var query = (from x in context.Accounts where x.Code == code && user.Email == email select x).First();
                    return query;
                }
                catch (ArgumentNullException e)
                {
                    throw e;
                }
            }
        }

        public int CalculateFinalState(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var OperationsList = (from x in context.Operations where x.AccountId == id select x.Value).ToList();

                //if empty
                if(OperationsList.Count() == 0)
                {
                    return 0;
                }

                var sumOfOperations = OperationsList.Sum(o => { return o; });

                if(sumOfOperations < 0)
                {
                    return -1;
                }

                return sumOfOperations;
            }
        }

        public bool isOperationValid(int AccountId, int value)
        {
            int finalState = CalculateFinalState(AccountId);

            if(value > 0)
            {

            }
            

            return true;
        }

        public bool InitialAllAccounts(string email)
        {
            List<AccountPreset> accountPresets = JsonSerializer.Deserialize<List<AccountPreset>>(File.ReadAllText(@"./InitialAccounts.json"));

            using (var context = new ApplicationDbContext())
            {
                var findUser = (from x in context.Users where x.Email == email select x).FirstOrDefault();

                if(findUser.Email != null)
                {
                    foreach(AccountPreset ap in accountPresets)
                    {
                        Account newAccount = new Account(ap.Name, ap.Code, ap.ParentCode, ap.AccountType, findUser.UserId);
                        context.Add<Account>(newAccount);
                        context.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool StartAccount(int initialValue, Account account)
        {
            

            return false;
        }

    }

    
}
