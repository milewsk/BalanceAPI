using BalanceAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Models
{
    public class Account
    {
        public int AccountId { get; set; }
 
        public string Name { get; private set; }

        public string Code { get; private set; }

        public string AccountType { get; private set; }

        public int? InitialState { get; set; }

        public int OverallBalance { get;  set; }

        //User
        public int UserId { get;  set; }

        public User User { get; set; }

        //List of Operations
        public ICollection<Operation> Operations { get; set; }

        //Parent Account
       public string ParentCode { get; private set; }

        public Account()
        {
            

        }

        public Account(string name, string code, string parentCode, string accountType, int userId)
        {
            Name = name;
            Code = code;
            ParentCode = parentCode;
            AccountType = accountType;
            UserId = userId;
            InitialState = null;
            OverallBalance = 0;
        }
    }
}
