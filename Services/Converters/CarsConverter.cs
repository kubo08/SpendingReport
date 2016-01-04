using System.Collections.Generic;
using System.Linq;
using SpendingReport.Models.Cars;

namespace Services.Converters
{
    public static class CarsConverter
    {
        public static IList<Car> EntityToModel(this IList<SpendingReportEntity4.Car> cars)
        {
            var listCars = new List<Car>();
            foreach (var car in cars)
            {
                listCars.Add(EntityToModel(car));
            }
            return listCars;
        }

        public static Car EntityToModel(this SpendingReportEntity4.Car car)
        {
            var carModel = new Car
            {
                Id = car.Id,
                Name = car.Name,
                TankSize = car.TankSize,
                Description = car.Description,
                Color = car.Color,
                Purchases = new List<Purchase>(),
                TankStatuses = new List<TankStatus>(),
                Trips = new List<Trip>()
            };
            foreach (var tankStatus in car.TankStatuses)
            {
                if (tankStatus == null)
                    continue;

                var statusModel = new TankStatus
                {
                    Id = tankStatus.Id,
                    Date = tankStatus.Date,
                    IsEmpty = tankStatus.Empty,
                    Percentage = tankStatus.Percentage,
                    TotalDistance = tankStatus.TotalDistance
                };
                carModel.TankStatuses.Add(statusModel);
            }
            foreach (var purchase in car.Purchases)
            {
                if (purchase == null)
                    continue;
                var purchaseModel = new Purchase
                {
                    Date = purchase.Date,
                    Description = purchase.Description,
                    Name = purchase.Name,
                    Price = purchase.Price
                };
                if (purchase.FuelStation != null)
                {
                    purchaseModel.Station = new FuelStation
                    {
                        Address = purchase.FuelStation.Address,
                        Description = purchase.FuelStation.Description,
                        Name = purchase.FuelStation.Name
                    };
                }
                if (purchase.Fueling != null)
                {
                    purchaseModel.Fueling = new Fueling
                    {
                        Id = purchase.Fueling.Id,
                        FuelPrice = purchase.Fueling.FuelPrice,
                        TankStatus = carModel.TankStatuses.SingleOrDefault(i => i.Id == purchase.Fueling.TankStatus.Id),
                        Value = purchase.Fueling.Value
                    };
                }
                carModel.Purchases.Add(purchaseModel);
            }
            foreach (var trip in car.Trips)
            {
                if (trip == null)
                    continue;
                var tripModel = new Trip
                {
                    Date = trip.Date,
                    DistanceEnd = trip.DistanceEnd,
                    DistanceStart = trip.DistanceStart,
                    From = trip.From,
                    To = trip.To
                };
                carModel.Trips.Add(tripModel);
            }
            return carModel;
        }
    }
}