using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using XMLParser.Data;

namespace spending_report.Models
{
    public class BankPayments
    {
        public BankAccount BankAccount { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public IPagedList<Payment> Transactions { get; set; }

        public Pager Pager { get; set; }
    }
}