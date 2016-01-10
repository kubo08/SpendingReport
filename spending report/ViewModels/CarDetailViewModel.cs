using SpendingReport.Models.Cars;

namespace SpendingReport.ViewModels.Cars
{
    public class CarDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? TankSize { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public Purchase LastPurchase { get; set; }

        public Trip LastTrip { get; set; }

        public TankStatus LastTankStatus { get; set; }

        public Fueling LastFueling { get; set; }
    }
}