using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Models;
using SpendingReport.remote.TransactionDescriptionService;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
{
    public class DescriptionsController : Controller
    {
        public ActionResult Index()
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = GetAllDescriptions(svc);
                return View(model);
            }
        }

        public ActionResult PaymentDescriptions()
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = GetAllDescriptions(svc);
                return View(model);
            }
        }

        public ActionResult AddPaymentDescription(int? DescriptionId)
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var model = new SingleDescriptionViewModel();
                if (DescriptionId.HasValue)
                {
                    var description = svc.GetTransactionDescriptionsById(DescriptionId.Value);
                    model.Name = description.Name;
                    ;
                }
                return View("NewDescription", model);
            }
        }

        public ActionResult CreateDescription(SingleDescriptionViewModel viewModel)
        {
            using (var svc = new TransactionDescriptionServiceClient())
            {
                var item = new DescriptionModel
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };
                svc.AddTransactionDescription(item);
                var model = GetAllDescriptions(svc);
                return View("Index", model);
            }


        }

        private TransactionDescriptionsViewModel GetAllDescriptions(TransactionDescriptionServiceClient svc)
        {
            var model = new TransactionDescriptionsViewModel
            {
                Descriptions = new List<TransactionDescriptionsModel>()
            };
            var descriptions = svc.GetAllTransactionDescriptions();
            model.Descriptions = descriptions;

            return model;
        }

    }
}
