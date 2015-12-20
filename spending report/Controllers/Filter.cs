using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
{
    public class Filter
    {
        public static TransactionFilterViewModel GetFilterModel()
        {
            var model = new TransactionFilterViewModel
            {
                CategoryItems = new List<SelectListItem>()
            };

            model.CategoryItems.Add(new SelectListItem { Text = "mobil", Value = "mobil" });
            model.CategoryItems.Add(new SelectListItem { Text = "bankomat", Value = "bankomat" });

            return model;
        }
    }
}