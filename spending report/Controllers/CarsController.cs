using System.Collections.Generic;
using System.Web.Mvc;
using SpendingReport.Helpers;
using SpendingReport.Models.Cars;
using SpendingReport.remote.DriveService;

namespace SpendingReport.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            IList<Car> cars;
            using (var svc = new DriveServiceClient())
            {
                cars = svc.GetCarsByUserId(UserHelpers.GetCurrentUser());
            }
            return View(cars);
        }

        [HttpGet]
        public ActionResult NewCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCar(Car newCar)
        {
            using (var svc = new DriveServiceClient())
            {
                svc.AddNewCar(UserHelpers.GetCurrentUser(), newCar);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CarDetail(int Id)
        {
            Car car;
            using (var svc = new DriveServiceClient())
            {
                car = svc.GetCarById(Id);
            }
            return View(car);
        }
    }
}
