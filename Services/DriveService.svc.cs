using System;
using System.Collections.Generic;
using System.Linq;
using Services.Converters;
using Services.Helpers;
using SpendingReportEntity4;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriveService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriveService.svc or DriveService.svc.cs at the Solution Explorer and start debugging.
    public class DriveService : IDriveService
    {
        public void AddNewCar(int userId, SpendingReport.Service.Models.Cars.CarAttributes carAttributes)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var currentUser = UserHelpers.GetUserByIDWithCars(userId);
                    if (currentUser == null)
                        throw new Exception("Používateľ nebol nájdený!");
                    var newCar = new Car
                    {
                        Name = carAttributes.Name,
                        TankSize = carAttributes.TankSize
                    };
                    currentUser.Cars.Add(newCar);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Nastaka chyba pri pridavani noveho auta!", ex);
            }
        }

        public IList<SpendingReport.Service.Models.Cars.Car> GetCarsByUserId(int userId)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var cars = context.Cars.Where(i => i.UserId == userId).ToList();
                    return cars.EntityToModel();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured in getting cars!", ex);
            }
        }

        public SpendingReport.Service.Models.Cars.Car GetCarById(int Id)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var car = context.Cars.SingleOrDefault(i => i.Id == Id);
                    car.Trips.Add(context.Trips.Where(i => i.CarId == Id).OrderBy(i => i.Date).FirstOrDefault());
                    car.TankStatuses.Add(context.TankStatuses.Include("Fueling").Include("Fueling.Purchase").Include("Fueling.Purchase.FuelStation").Where(i => i.CarId == Id).OrderBy(i => i.Date).FirstOrDefault());
                    car.Purchases.Add(context.Purchases.Include("Fueling").Include("Fueling.TankStatus").Include("FuelStation").Where(i => i.CarId == Id).OrderBy(i => i.Date).FirstOrDefault());
                    car.Purchases.Add(context.Purchases.Include("Fueling").Include("Fueling.TankStatus").Include("FuelStation").Where(i => i.CarId == Id).Where(i => i.Fueling != null).OrderBy(i => i.Date).FirstOrDefault());
                    return car.EntityToModel();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured in getting CarAttributes with Id: {0}!", Id), ex);
            }
        }
    }
}
