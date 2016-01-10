using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Converter;
using SpendingReport.Helpers;
using SpendingReport.remote.DriveService;
using SpendingReport.Service.Models.Cars;
using SpendingReport.ViewModels.Cars;

namespace SpendingReport.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            IList<CarDetailViewModel> viewModel = new List<CarDetailViewModel>();
            using (var svc = new DriveServiceClient())
            {
                var car = svc.GetCarsByUserId(UserHelpers.GetCurrentUser());
                viewModel = car.EntityToModel();
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult NewCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCar(CarAttributes newCarAttributes)
        {
            using (var svc = new DriveServiceClient())
            {
                svc.AddNewCar(UserHelpers.GetCurrentUser(), newCarAttributes);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CarDetail(int Id)
        {
            CarDetailViewModel carViewModel;
            using (var svc = new DriveServiceClient())
            {
                carViewModel = svc.GetCarById(Id).EntityToModel();
            }
            return View(carViewModel);
        }
    }
}
