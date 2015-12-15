using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Models;
using spending_report.remote.TransactionDescriptionService;
using spending_report.ViewModels;


namespace spending_report.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }


    }
}
