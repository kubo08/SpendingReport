using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpendingReport.Models
{
    public class TransactionAmount
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string TransactionType { get; set; }

        public string PaymentType { get; set; }
    }
}
