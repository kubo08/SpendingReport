using System.Collections.Generic;

namespace SpendingReport.Models.Cars
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TankSize { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public IList<Purchase> Purchases { get; set; }

        public IList<Trip> Trips { get; set; }

        public IList<TankStatus> TankStatuses { get; set; }
    }
}
