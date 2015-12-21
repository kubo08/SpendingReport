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
            return GetTransactionsByUserID(null, -1, 0, null);
        }

        public TransactionsModel GetTransactionsByUserID(int? userId, int categoryId, int skip, int? take)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var transactions = context.Entries
                        .Include("DestinationAccount")
                        .Include("DestinationAccount.Bank")
                        .Include("AmountInfo")
                        .OrderBy(a => a.DatePosted).ToList();
                    if (userId.HasValue)
                    {
                        transactions =
                            transactions.Where(e => e.SourceAccount.User.Id == userId).ToList();
                    }
                    if (categoryId > 0)
                    {
                        var category = context.TransactionCategories.SingleOrDefault(i => i.Id == categoryId);
                        transactions = transactions.Where(e => e.TransactionCategories.Contains(category)).ToList();
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
