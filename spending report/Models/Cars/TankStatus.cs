using System;

namespace SpendingReport.Models.Cars
{
    public class TankStatus
    {
        public int Id { get; set; }

        public bool IsEmpty { get; set; }

        public int TotalDistance { get; set; }

        public DateTime Date { get; set; }

        public int? Percentage { get; set; }
    }
}