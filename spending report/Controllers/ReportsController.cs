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

        public ActionResult PaymentDescriptions()
        {
            return View();
        }

        public ActionResult AddPaymentDescription(PaymentType viewModel)
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = new TransactionDescription
                {
                    Name = viewModel.TypeName,
                    Description = viewModel.Description
                };
                svc.AddTransactionDescription(model);
            }

            return View("PaymentDescriptions");
        }

    }
}
