using System.Web.Mvc;
using System.Web.Optimization;
using PagedList;
using spending_report.Models;
using spending_report.remote.TransactionsOperationsService;

namespace spending_report.Controllers
{
    public class ListController : Controller
    {
        [HttpGet]
        public ActionResult Transactions()
        {
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //"~/Scripts/jquery-ui-{version}.js"));
            var model = new TransactionsModel();
            using (var svc = new TransactionsOperationsServiceClient())
            {
                var transactions = svc.GetTransactionsByUserID(1);
                model.TransactionsList = transactions.ToPagedList(1, 10);
                model.Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = 10
                };
                Session["Transactions"] = transactions;
            }


            return View("Transactions", model);
        }

        [HttpGet]
        public ActionResult TransactionsPaging(int Page, TransactionsModel model)
        {
            var transactions = (Transaction[])Session["Transactions"];

            model.TransactionsList = transactions.ToPagedList(Page, 10);
            model.Pager = new Pager
            {
                CurrentPageIndex = Page
            };

            return View("Transactions", model);
        }
    }
}