using System;

namespace SpendingReport.Models.Cars
{
    public class Trip
    {
        public int? DistanceStart { get; set; }

        public int? DistanceEnd { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime Date { get; set; }
    }
}