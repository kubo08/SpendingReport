using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using XMLParser.Data;

namespace spending_report.Models
{
    public class BankAccountImportedPayments
    {
        private BankAccount _account;

        public BankAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public IPagedList<ImportedPayment> Transactions { get; set; }

        public Pager Pager { get; set; }

        public bool OnlyImported { get; set; }
    }
}