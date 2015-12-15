using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpendingReport.Models
{
    public abstract class Filter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        //todo:zmenit na enum
        public int TransactionType { get; set; }
        public int Amount { get; set; }
        public string Purpose { get; set; }
    }
}