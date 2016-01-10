using System.Collections.Generic;

namespace SpendingReport.Service.Models.Cars
{
    public class Car
    {
        public CarAttributes CarDetails { get; set; }

        public IList<Purchase> Purchases { get; set; }

        public IList<Trip> Trips { get; set; }

        public IList<TankStatus> TankStatuses { get; set; }
    }
}
