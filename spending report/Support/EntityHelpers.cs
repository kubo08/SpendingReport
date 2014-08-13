using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using SpendingReportEntity;
using entity = SpendingReportEntity;
using XmlObjects;
using XMLParser.Data;
using data = XMLParser.Data;
using XMLParser;

namespace Support
{
    public static class EntityHelpers
    {
        public static Import SaveData(Import bankPayments)
        {            
            Import ImportWithPocessedTransactions;

            try
            {
                using (var context = new SpendingContext())
                {
                    if (!bankPayments.Account.Bank.BankID.HasValue)
                    {
                        return null;
                    }

                    ImportWithPocessedTransactions = new Import
                    {
                        Account = bankPayments.Account,
                        From = bankPayments.From,
                        To = bankPayments.To,
                        Transactions = new List<Payment>()
                    };

                    entity.Bank bank = context.Banks.FirstOrDefault(t => t.BankCode == bankPayments.Account.Bank.BankID);
                    foreach (var transaction in bankPayments.Transactions)
                    {
                        if (IsTransactionExist(context, transaction))
                        {
                            continue;
                        }
                        Entry newTransaction = new Entry
                        {
                            ConstantSymbol = transaction.ConstantSymbol,
                            VariableSymbol = transaction.VariableSymbol,
                            SpecificSymbol = transaction.SpecificSymbol,
                            Reference = transaction.Reference,
                            DateAvailable = transaction.DateAvailable,
                            DatePosted = transaction.DatePosted,
                            Memo = transaction.Description,
                            Name = transaction.TransactionName,
                            DateAdded=DateTime.Now,
                            AmountInfo = new entity.AmountInfo
                            {
                                Amount = Math.Abs(transaction.TransactionAmount.Amount),
                                Currency = transaction.TransactionAmount.Currency,
                            },
                            BankAccount = new entity.BankAccount
                            {
                                AccountNumber = (long?) transaction.BankAccount.AccountID,
                                //BankCode = (short?) transaction.BankAccount.BankID,
                                IBAN = transaction.BankAccount.IBan,
                                Bank = transaction.BankAccount.Bank.BankID.HasValue ? GetBank(context, transaction.BankAccount.Bank.BankID.Value) : null
                            },
                            //Bank = GetBank(context, transaction.BankName.Localise())
                        };
                        if (transaction.TransactionAmount.Type != XMLParser.Data.AmountType.NotDefined)
                        {
                            newTransaction.AmountInfo.Type = transaction.TransactionAmount.Type == XMLParser.Data.AmountType.Credit
                                ? GetTransactionType(context, "Credit")
                                : GetTransactionType(context, "Debit");
                        }
                        else
                        {
                            newTransaction.AmountInfo.Type = transaction.TransactionAmount.Amount < 0
                                ? GetTransactionType(context, "Debit")
                                : GetTransactionType(context, "Credit");
                        }
                        bank.Entries.Add(newTransaction);
                        //context.Entries.Add(newTransaction);
                        ImportWithPocessedTransactions.Transactions.Add(transaction);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return ImportWithPocessedTransactions;
        }

        /// <summary>
        /// Checks if transaction allready exists in the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        private static bool IsTransactionExist(SpendingContext context, Payment transaction)
        {
            var date = transaction.DateAvailable;            
            var item =
                context.Entries.Where(
                    t =>
                        t.AmountInfo.Amount == transaction.TransactionAmount.Amount && t.Name == transaction.TransactionName &&
                        t.Memo == transaction.Description &&
                        t.DateAvailable == date);
            return item.Any();
        }

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static entity.Type GetTransactionType(SpendingContext context, string type)
        {
            return context.Types.FirstOrDefault(
                item => item.TypeName.ToLower().Trim() == type.ToLower().Trim());
        }

        private static entity.Bank GetBank(SpendingContext context, string Name)
        {
            return context.Banks.FirstOrDefault(
                item => item.Name.ToLower().Trim() == Name.ToLower().Trim());
        }

        private static entity.Bank GetBank(SpendingContext context, ushort bankCode)
        {
            return context.Banks.FirstOrDefault(
                item => item.BankCode == bankCode);
        }

        public static IEnumerable<Entry> GetTransactions()
        {
            using (var context = new SpendingContext())
            {
                return context.Entries.ToList();
            }
        }
    }
}