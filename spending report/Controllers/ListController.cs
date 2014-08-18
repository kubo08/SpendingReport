using System.Web.Mvc;
using Support;

namespace spending_report.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Transactions()
        {
            var transactions = Support.Support.GetTransactions();

            return View();
        }
    }
}