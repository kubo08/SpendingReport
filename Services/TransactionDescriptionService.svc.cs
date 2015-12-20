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

        public IEnumerable<TransactionCategoriesModel> GetAllTransactionCategories(bool withNames = true)
        {
            using (var context = new SpendingReportEntities())
            {
                IList<TransactionCategory> categories;
                if (withNames)
                    categories = context.TransactionCategories.Include("CategoryNames").ToList();
                else
                {
                    categories = context.TransactionCategories.ToList();
                }
                var result = new List<TransactionCategoriesModel>();
                foreach (var transactionCategory in categories)
                {
                    var desc = transactionCategory.EntityToModel();
                    result.Add(desc);
                }
                return result;
            }
        }

        public TransactionCategoriesModel GetTransactionCategoriesById(int id)
        {
            using (var context = new SpendingReportEntities())
            {
                var category = context.TransactionCategories.FirstOrDefault(i => i.Id == id);
                var result = category.EntityToModel();
                return result;
            }
        }

        public bool AddTransactionCategory(CategoryModel model)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    TransactionCategory category = null;
                    var name = new CategoryName()
                    {
                        Description = model.Description
                    };
                    context.CategoryNames.Add(name);
                    if (model.Id != 0)
                    {
                        category = context.TransactionCategories.FirstOrDefault(i => i.Id == model.Id);
                    }
                    if (category == null)
                    {
                        category = context.TransactionCategories.FirstOrDefault(i => i.Name == model.Name) ??
                                      CreateTransactionCategory(context);
                    }
                    category.Name = model.Name;

                    category.CategoryNames.Add(name);
                    context.SaveChanges();

                    //todo: async
                    UpdateCategories(model.Description, category.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in add transaction description!", ex);
            }
        }

        private TransactionCategory CreateTransactionCategory(SpendingReportEntities context)
        {
            var category = new TransactionCategory();
            context.TransactionCategories.Add(category);
            return category;
        }

        public void UpdateAllCategories()
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var categories = context.TransactionCategories;
                    foreach (var transactionCategory in categories)
                    {
                        UpdateCategories(transactionCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in update categories!", ex);
            }
        }

        private void UpdateCategories(TransactionCategory transactionCategory)
        {
            foreach (var category in transactionCategory.CategoryNames)
            {
                UpdateCategories(category.Description, transactionCategory.Id);
            }
        }

        private void UpdateCategories(string Description, int transactionCategoryID)
        {
            using (var context = new SpendingReportEntities())
            {
                TransactionCategory transactionCategory;
                try
                {
                    transactionCategory =
                        context.TransactionCategories.SingleOrDefault(i => i.Id == transactionCategoryID);
                }
                catch (Exception ex)
                {
                    throw new Exception("There are more transaction descriptions with id: " + transactionCategoryID, ex);
                }
                var transactions = GetTransactionsByCategory(Description, context);
                foreach (var transaction in transactions)
                {
                    if (!transaction.TransactionCategories.Contains(transactionCategory))
                    {
                        transaction.TransactionCategories.Add(transactionCategory);
                    }

                }
                context.SaveChanges();
            }
        }

        private IEnumerable<Entry> GetTransactionsByCategory(string description, SpendingReportEntities context)
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
