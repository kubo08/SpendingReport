using System.Collections.Generic;
using System.Net.Mime;
using System.Web.Mvc;
using SpendingReport.remote.TransactionDescriptionService;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
{
    public class FilterController
    {
        public static TransactionFilterViewModel GetFilterModel()
        {
            var model = new TransactionFilterViewModel
            {
                CategoryItems = new List<SelectListItem>()
            };
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var items = svc.GetAllTransactionCategories(false);
                model.CategoryItems.Add(new SelectListItem { Text = "Select item...", Value = "-1" });
                foreach (var transactionCategoriesModel in items)
                {
                    model.CategoryItems.Add(new SelectListItem { Text = transactionCategoriesModel.Name, Value = transactionCategoriesModel.Id.ToString() });
                }
            }

            return model;
        }
    }
}