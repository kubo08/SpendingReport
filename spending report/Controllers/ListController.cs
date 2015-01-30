using System.Web.Mvc;
using PagedList;
using spending_report.Models;
using spending_report.remote.TransactionsOperationsService;

namespace spending_report.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Transactions()
        {
            var model = new TransactionsModel();
            using (var svc = new TransactionsOperationsServiceClient())
            {
                var transactions = svc.GetTransactionsByUserID(1);
                model.TransactionsList = transactions.ToPagedList(0, transactions.Length);
            }

            return View("Transactions", model);
        }
    }
}