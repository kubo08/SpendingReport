using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Services.Converters;
using Services.Helpers;
using SpendingReportEntity4;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriveService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriveService.svc or DriveService.svc.cs at the Solution Explorer and start debugging.
    public class DriveService : IDriveService
    {
        public void AddNewCar(int userId, SpendingReport.Models.Cars.Car car)
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
                        Name = car.Name,
                        TankSize = car.TankSize
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

        public IList<SpendingReport.Models.Cars.Car> GetCarsByUserId(int userId)
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

        public SpendingReport.Models.Cars.Car GetCarById(int Id)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var car = context.Cars.Include("Trips").Include("TankStatuses").Include("Purchases").Include("Fuelings").Include("FuelStations").SingleOrDefault(i => i.Id == Id);
                    return car.EntityToModel();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured in getting car with Id: {0}!", Id), ex);
            }
        }
    }
}
