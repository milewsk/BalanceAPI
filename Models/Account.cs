using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        public string Name { get; set; };

    }
}
