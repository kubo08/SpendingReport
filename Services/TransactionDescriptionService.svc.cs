using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Services.Helpers;
using SpendingReport.Models;
using SpendingReportEntity4;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionDescriptionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionDescriptionService.svc or TransactionDescriptionService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionDescriptionService : ITransactionDescriptionService
    {

        public IEnumerable<TransactionDescriptionsModel> GetAllTransactionDescriptions()
        {
            using (var context = new SpendingReportEntities())
            {
                var descriptions = context.TransactionDescriptions.Include("DescriptionNames").ToList();
                var result = new List<TransactionDescriptionsModel>();
                foreach (var transactionDescription in descriptions)
                {
                    var desc = transactionDescription.EntityToModel();
                    result.Add(desc);
                }
                return result;
            }
        }

        public TransactionDescriptionsModel GetTransactionDescriptionsById(int id)
        {
            using (var context = new SpendingReportEntities())
            {
                var description = context.TransactionDescriptions.FirstOrDefault(i => i.Id == id);
                var result = description.EntityToModel();
                return result;
            }
        }

        public bool AddTransactionDescription(DescriptionModel model)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    TransactionDescription description = null;
                    var name = new DescriptionName
                    {
                        Description = model.Description
                    };
                    context.DescriptionNames.Add(name);
                    if (model.Id != 0)
                    {
                        description = context.TransactionDescriptions.FirstOrDefault(i => i.Id == model.Id);
                    }
                    if (description == null)
                    {
                        description = context.TransactionDescriptions.FirstOrDefault(i => i.Name == model.Name) ??
                                      createTransactionDescription(context);
                    }
                    description.Name = model.Name;

                    description.DescriptionNames.Add(name);
                    context.SaveChanges();

                    //todo: async
                    UpdateTransactions(model.Description, description.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in add transaction description!", ex);
            }
        }

        private TransactionDescription createTransactionDescription(SpendingReportEntities context)
        {
            var description = new TransactionDescription();
            context.TransactionDescriptions.Add(description);
            return description;
        }

        public void UpdateAllDescriptions()
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var descriptions = context.TransactionDescriptions;
                    foreach (var transactionDescription in descriptions)
                    {
                        UpdateTransactions(transactionDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in update descriptions!", ex);
            }
        }

        private void UpdateTransactions(TransactionDescription transactionDescription)
        {
            foreach (var description in transactionDescription.DescriptionNames)
            {
                UpdateTransactions(description.Description, transactionDescription.Id);
            }
        }

        private void UpdateTransactions(string Description, int transactionDescriptionID)
        {
            using (var context = new SpendingReportEntities())
            {
                TransactionDescription transactionDescription;
                try
                {
                    transactionDescription =
                        context.TransactionDescriptions.SingleOrDefault(i => i.Id == transactionDescriptionID);
                }
                catch (Exception ex)
                {
                    throw new Exception("There are more transaction descriptions with id: " + transactionDescriptionID, ex);
                }
                var transactions = GetTransactionsByDescription(Description, context);
                foreach (var transaction in transactions)
                {
                    if (!transaction.TransactionDescriptions.Contains(transactionDescription))
                    {
                        transaction.TransactionDescriptions.Add(transactionDescription);
                    }
                    
                }
                context.SaveChanges();
            }
        }

        private IEnumerable<Entry> GetTransactionsByDescription(string description, SpendingReportEntities context)
        {
            try
            {
                IOrderedQueryable<Entry> transactions = context.Entries.Where(
                    e => e.Memo.Contains(description) || e.Name.Contains(description))
                    .Include("DestinationAccount")
                    .Include("DestinationAccount.Bank")
                    .Include("AmountInfo")
                    .OrderBy(a => a.DatePosted);

                return transactions;

            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in getting all transactions.", ex);
            }
        }
    }
}
