using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Models;
using SpendingReport.remote.TransactionDescriptionService;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = GetAllCategories(svc);
                return View(model);
            }
        }

        public ActionResult PaymentCategories()
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = GetAllCategories(svc);
                return View(model);
            }
        }

        public ActionResult AddPaymentCategory(int? DescriptionId)
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = new SingleCategoryViewModel();
                if (DescriptionId.HasValue)
                {
                    var description = svc.GetTransactionCategoriesById(DescriptionId.Value);
                    model.Name = description.Name;
                    ;
                }
                return View("NewCategory", model);
            }
        }

        public ActionResult CreateCategory(SingleCategoryViewModel viewModel)
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var item = new CategoryModel
                {
                    Name = viewModel.Name,
                    Description = viewModel.Category
                };
                svc.AddTransactionCategory(item);
                var model = GetAllCategories(svc);
                return View("Index", model);
            }


        }

        public bool Updatecategories()
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                try
                {
                    svc.UpdateAllCategories();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private TransactionCategoriesViewModel GetAllCategories(TransactionDescriptionServiceClient svc)
        {
            var model = new TransactionCategoriesViewModel
            {
                Categories = new List<TransactionCategoriesModel>()
            };
            var descriptions = svc.GetAllTransactionCategories(true);
            model.Categories = descriptions;

            return model;
        }



    }
}
