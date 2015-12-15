using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Services.Helpers;
using SpendingReport.Models;
using SpendingReportEntity4;
using BankAccount = SpendingReport.Models.BankAccount;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionsOperationsServiceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionsOperationsServiceService.svc or TransactionsOperationsServiceService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionsOperationsService : ITransactionsOperationsService
    {
        public TransactionsModel GetAllTransactions()
        {
            return GetTransactionsByUserID(null, 0, null);
        }

        public TransactionsModel GetTransactionsByUserID(int? userId, int skip, int? take)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    IOrderedQueryable<Entry> transactions;
                    if (userId.HasValue)
                    {
                        transactions =
                            context.Entries.Where(
                                e => e.SourceAccount.User.Id == userId)
                                .Include("DestinationAccount")
                                .Include("DestinationAccount.Bank")
                                .Include("AmountInfo")
                                .OrderBy(a => a.DatePosted);
                    }
                    else
                    {
                        transactions =
                            context.Entries
                                .Include("DestinationAccount")
                                .Include("DestinationAccount.Bank")
                                .Include("AmountInfo")
                                .OrderBy(a => a.DatePosted);
                    }
                    var resultTransactions = new List<Transaction>();
                    if (!take.HasValue)
                        take = transactions.Count();
                    foreach (var item in transactions.Skip(skip).Take(take.Value))
                    {
                        var transaction = item.EntityToModel();
                        resultTransactions.Add(transaction);
                    }
                    var result = new TransactionsModel
                    {
                        TotalItems = transactions.Count(),
                        Transactions = resultTransactions
                    };
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
