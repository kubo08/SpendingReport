using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Models;
using SpendingReport.remote.TransactionDescriptionService;
using SpendingReport.ViewModels;


namespace SpendingReport.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            var model = new ReportsViewModel
            {
                Filter = FilterController.GetFilterModel()
            };
            return View(model);
        }


    }
}
