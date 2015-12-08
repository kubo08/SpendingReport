using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpendingReport.Models
{
    public class BankAccount
    {
        public string BankName { get; set; }

        public long AccountNumber { get; set; }

        public long BankCode { get; set; }
    }
}