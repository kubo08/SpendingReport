namespace SpendingReport.Models.Cars
{
    public class Fueling
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public double FuelPrice { get; set; }

        public TankStatus TankStatus { get; set; }
    }
}