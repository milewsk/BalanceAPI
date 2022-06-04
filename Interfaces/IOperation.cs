using BalanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Interfaces
{
    interface IOperation
    {

         bool IsOperationValid(Operation opeartion);        

         Operation CreateOperation(int accountId, int value, int destinationAccountId);
         void AddOperation(Operation operation);

         Operation GetOperation(int accountId, int id);
         List<Operation> GetOperations(int accountId);
    }
}
