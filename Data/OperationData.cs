using BalanceAPI.Context;
using BalanceAPI.Interfaces;
using BalanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Data
{
    public class OperationData : IOperation
    {
        //constructor
        public OperationData() { }

        public bool OperationExist()
        {
            return false;
        }

        //Value validation of Operation
        public bool IsOperationValid(Operation operation) {

            using (var context = new ApplicationDbContext())
            {
                var existingAccount = (from x in context.Accounts where x.AccountId == operation.AccountId select x).FirstOrDefault();             

                //account exist
                if(existingAccount == null)
                {
                    return false;
                }

                if(existingAccount.OverallBalance > operation.Value && operation.Value < 0)
                {
                    return true;
                }
                else if(operation.Value > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }

        //Creating an Operation objcet
        public Operation CreateOperation(int accountId, int value, int destinationAccountId) {

            Operation newOperation = new Operation();
            newOperation.AccountId = accountId;
            newOperation.Value = value;
            newOperation.DestinationAccountId = destinationAccountId;
            newOperation.DateOfOperation = DateTime.Now;

            if (IsOperationValid(newOperation))
            {
                return newOperation;
            }
            else { return null; }
          
        }

        // Adding Operation to database
        public void AddOperation(Operation operation) {
            if (IsOperationValid(operation))
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Add(operation);
                    context.SaveChanges();
                }
            }
        }

        // Get single Operation
        public Operation GetOperation(int accountId, int id) {

            using (var context = new ApplicationDbContext())
            {
                var query = (from x in context.Operations where (id == x.OperationId) && (accountId == x.AccountId) select x).FirstOrDefault();

                if (query != null)
                {
                    return query;
                }
                else
                {
                    return null;
                }
            }
        }

        // Get list of Operations from single account
        public List<Operation> GetOperations(int accountId)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = (from x in context.Operations where accountId == x.AccountId select x);

                if (query.Count() != 0)
                {
                    return query.ToList();
                }
                else
                { 
                    return null; 
                }
            }
        }

    }
}
