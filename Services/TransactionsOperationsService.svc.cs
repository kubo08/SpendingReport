using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SpendingReport.Models;
using SpendingReportEntity4;
using BankAccount = SpendingReport.Models.BankAccount;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionsOperationsServiceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionsOperationsServiceService.svc or TransactionsOperationsServiceService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionsOperationsService : ITransactionsOperationsService
    {
        public TransactionsModel GetTransactionsByUserID(int userId, int skip, int take)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var transactions =

                        context.Entries.Where(
                            e => e.SourceAccount.User.Id == userId).Include("DestinationAccount").Include("DestinationAccount.Bank").Include("AmountInfo").OrderBy(a => a.DatePosted);
                    var resultTransactions = new List<Transaction>();
                    foreach (var item in transactions.Skip(skip).Take(take))
                    {
                        var transaction = new Transaction();
                        transaction.Description = item.Memo;
                        transaction.Name = item.Name;
                        transaction.DateAvailable = item.DateAvailable;
                        transaction.DatePosted = item.DatePosted;
                        transaction.SpecificSymbol = item.SpecificSymbol.ToString();
                        transaction.VariableSymbol = item.VariableSymbol.ToString();
                        transaction.ConstantSymbol = item.ConstantSymbol.ToString();
                        var accountNumber = item.DestinationAccount.AccountNumber;
                        var bankAccount = new BankAccount();
                        if (accountNumber != null && accountNumber != 0)
                        {
                            bankAccount.AccountNumber =
                                accountNumber.Value;
                            if (item.DestinationAccount.Bank != null)
                            {

                                bankAccount.BankCode = item.DestinationAccount.Bank.BankCode;
                                bankAccount.BankName = item.DestinationAccount.Bank.Name;
                            }
                            transaction.BankAccount = bankAccount;
                        }
                        transaction.BankAccount = bankAccount;
                        var transactionAmount = new TransactionAmount();
                        transactionAmount.Amount = item.AmountInfo.Amount;
                        transactionAmount.Currency = item.AmountInfo.Currency;
                        if (item.PaymentType != null)
                            transactionAmount.PaymentType = item.PaymentType.Name;
                        transactionAmount.TransactionType = item.AmountInfo.Type.TypeName;
                        transaction.TransacionAmount = transactionAmount;
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
