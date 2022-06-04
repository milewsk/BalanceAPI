using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Data
{
    public class AccountPreset
    {
  //       "Name": "jeden",
    //  "AccountType": "",
    //  "Code": "",
     // "ParentCode": ""


        public string Name { get; set; }
        public string AccountType { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }

        public AccountPreset()
        {

        }

        public AccountPreset(string name, string type, string code, string parentCode)
        {
            Name = name;
            AccountType = type;
            Code = code;
            ParentCode = parentCode;
        }
    }
}
