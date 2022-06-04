using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Models
{
    public class Operation
    {
        public int OperationId { get; set; }

        public int Value { get; set; }

        public DateTime DateOfOperation { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public int DestinationAccountId { get; set; }
            
        public Operation() {
           
        }
    }
}
