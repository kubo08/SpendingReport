using System.Web.Mvc;
using SpendingReport.Models;
using spending_report.Helpers;
using spending_report.remote.TransactionsOperationsService;
using spending_report.ViewModels;

namespace spending_report.Controllers
{
    public class ListController : Controller
    {
        public const int PAGESIZE = 10;

        [HttpGet]
        public ActionResult Transactions()
        {
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //"~/Scripts/jquery-ui-{version}.js"));
            var model = new TransactionsListModel();
            using (var svc = new TransactionsOperationsServiceClient())
            {
                TransactionsModel transactions = svc.GetTransactionsByUserID(1, 0, PAGESIZE);
                model.TransactionsList = transactions.ToPagedList(1, PAGESIZE);
                model.Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGESIZE
                };
            }


            return View("Transactions", model);
        }

        [HttpGet]
        public ActionResult TransactionsPaging(int Page, TransactionsListModel model)
        {
            using (var svc = new TransactionsOperationsServiceClient())
            {
                TransactionsModel transactions = svc.GetTransactionsByUserID(1, (Page - 1) * PAGESIZE, PAGESIZE);

                model.TransactionsList = transactions.ToPagedList(Page, PAGESIZE);
                model.Pager = new Pager
                {
                    CurrentPageIndex = Page
                };
            }

            return View("Transactions", model);
        }
    }
}