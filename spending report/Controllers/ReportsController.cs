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
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }


    }
}
