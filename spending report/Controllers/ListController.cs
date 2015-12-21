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
                TransactionsModel transactions = svc.GetTransactionsByUserID(1, -1, 0, PAGESIZE);
                model.TransactionsList = transactions.ToPagedList(1, PAGESIZE);
                model.Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGESIZE
                };
            }
            model.Filter = FilterController.GetFilterModel();

            return View("Transactions", model);
        }

        [HttpGet]
        public ActionResult TransactionsPaging(int Page, int? CategoryId)
        {
            if (!CategoryId.HasValue)
                CategoryId = -1;
            var model = new TransactionsListModel
            {
                Filter = FilterController.GetFilterModel()
            };
            model.Filter.TransactionCategory = CategoryId.ToString();
            using (var svc = new TransactionsOperationsServiceClient())
            {
                TransactionsModel transactions = svc.GetTransactionsByUserID(1, CategoryId.Value, (Page - 1) * PAGESIZE, PAGESIZE);

                model.TransactionsList = transactions.ToPagedList(Page, PAGESIZE);
                model.Pager = new Pager
                {
                    CurrentPageIndex = Page
                };
            }

            return View("Transactions", model);
        }

        [HttpPost]
        public ActionResult Transactions(TransactionsListModel model, TransactionFilterViewModel filter)
        {
            var id = int.Parse(filter.TransactionCategory);
            using (var svc = new TransactionsOperationsServiceClient())
            {
                TransactionsModel transactions = svc.GetTransactionsByUserID(1, id, 0, PAGESIZE);
                model.TransactionsList = transactions.ToPagedList(1, PAGESIZE);
                model.Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGESIZE
                };
            }
            model.Filter = FilterController.GetFilterModel();
            model.Filter.TransactionCategory = filter.TransactionCategory;

            return View("Transactions", model);
        }
    }
}