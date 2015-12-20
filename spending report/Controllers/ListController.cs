using System.Web.Mvc;
using SpendingReport.Models;
using SpendingReport.Helpers;
using SpendingReport.remote.TransactionsOperationsService;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
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
            model.Filter = Filter.GetFilterModel();

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