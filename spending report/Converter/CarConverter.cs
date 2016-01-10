using System.Collections.Generic;
using System.Linq;
using SpendingReport.remote.DriveService;
using SpendingReport.Service.Models.Cars;
using SpendingReport.ViewModels.Cars;
using Cars = SpendingReport.Models.Cars;

namespace SpendingReport.Converter
{
    public static class CarConverter
    {
        public static CarDetailViewModel EntityToModel(this Car car)
        {
            var trip = car.Trips.FirstOrDefault();
            var tankstatus = car.TankStatuses.FirstOrDefault();
            var purchase = car.Purchases.OrderByDescending(i => i.Date).FirstOrDefault();
            var purchaseWithFueling = car.Purchases.FirstOrDefault(i => i.Fueling != null);
            var fueling = purchaseWithFueling != null ? purchaseWithFueling.Fueling : null;

            var carViewModel = new CarDetailViewModel()
            {
                Color = car.CarDetails.Color,
                Description = car.CarDetails.Description,
                Id = car.CarDetails.Id,
                Name = car.CarDetails.Name,
                TankSize = car.CarDetails.TankSize
            };

            if (trip != null)
                carViewModel.LastTrip = new Cars.Trip
                {
                    Date = trip.Date,
                    DistanceEnd = trip.DistanceEnd,
                    DistanceStart = trip.DistanceStart,
                    From = trip.From,
                    To = trip.To
                };

            if (tankstatus != null)
                carViewModel.LastTankStatus = new Cars.TankStatus
                {
                    Date = tankstatus.Date,
                    Id = tankstatus.Id,
                    IsEmpty = tankstatus.IsEmpty,
                    Percentage = tankstatus.Percentage,
                    TotalDistance = tankstatus.TotalDistance
                };

            if (purchase != null)
                carViewModel.LastPurchase = new Cars.Purchase
                {
                    Date = purchase.Date,
                    Description = purchase.Description,
                    Name = purchase.Name,
                    Price = purchase.Price,
                    Station = new Cars.FuelStation
                    {
                        Address = purchase.Station.Address,
                        Description = purchase.Station.Description,
                        Name = purchase.Station.Name
                    }
                };

            if (fueling != null)
                carViewModel.LastFueling = new Cars.Fueling
                {
                    FuelPrice = fueling.FuelPrice,
                    Id = fueling.Id,
                    Value = fueling.Value,
                    TankStatus = new Cars.TankStatus
                    {
                        Date = fueling.TankStatus.Date,
                        Id = fueling.TankStatus.Id,
                        IsEmpty = fueling.TankStatus.IsEmpty,
                        Percentage = fueling.TankStatus.Percentage,
                        TotalDistance = fueling.TankStatus.TotalDistance
                    }
                };

            return carViewModel;
        }

        public static IList<CarDetailViewModel> EntityToModel(this IEnumerable<Car> cars)
        {
            var carsViewModel = new List<CarDetailViewModel>();
            foreach (var car in cars)
            {
                carsViewModel.Add(car.EntityToModel());
            }
            return carsViewModel;
        }
    }
}