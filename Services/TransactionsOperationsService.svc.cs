using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpendingReportEntity;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionsOperationsServiceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionsOperationsServiceService.svc or TransactionsOperationsServiceService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionsOperationsService : ITransactionsOperationsService
    {
        public IEnumerable<Transaction> GetTransactionsByUserID(int UserID)
        {
            try
            {
                using (var context = new SpendingContext())
                {
                    var transactions =
                        context.Entries.Where(
                            e => e.SourceAccount.User.Id == UserID).Include("DestinationAccount").Include("DestinationAccount.Bank").Include("AmountInfo");
                    var result = new List<Transaction>();
                    foreach (var item in transactions)
                    {
                        var transaction = new Transaction();
                        transaction.Description = item.Memo;
                        var accountNumber = item.DestinationAccount.AccountNumber;
                        if (accountNumber != null && accountNumber != 0)
                        {
                            transaction.BankAccount.AccountNumber =
                                accountNumber.Value;
                            transaction.BankAccount.BankCode = item.DestinationAccount.Bank.BankCode;
                            transaction.BankAccount.BankName = item.DestinationAccount.Bank.Name;
                        }
                        transaction.TransacionAmount.Amount = item.AmountInfo.Amount;
                        transaction.TransacionAmount.Currency = item.AmountInfo.Currency;
                        transaction.TransacionAmount.PaymentType = item.PaymentType.Id;
                        transaction.TransacionAmount.TransactionType = item.AmountInfo.Type.Id;
                        result.Add(transaction);
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
