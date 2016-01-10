using System;

namespace SpendingReport.Models.Cars
{
    public class Purchase
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public FuelStation Station { get; set; }

        public Fueling Fueling { get; set; }
    }
}