using System.Collections.Generic;
using System.Linq;
using SpendingReport.Models;
using entity = SpendingReportEntity4;

namespace Services.Helpers
{
    public static class Converters
    {
        public static TransactionCategoriesModel EntityToModel(this entity.TransactionCategory entity)
        {
            var description = new TransactionCategoriesModel
            {
                Category = new List<CategoryNameModel>(),
                Name = entity.Name,
                Id = entity.Id
            };
            foreach (var descriptionName in entity.CategoryNames)
            {
                var name = new CategoryNameModel
                {
                    Description = descriptionName.Description
                };
                description.Category.Add(name);
            }
            return description;
        }

        public static IList<Transaction> EntityToModel(this IOrderedQueryable<entity.Entry> item)
        {
            var result = item.Select(entry => entry.EntityToModel()).ToList();
            return result;
        }

        public static Transaction EntityToModel(this entity.Entry item)
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
            return transaction;
        }
    }
}