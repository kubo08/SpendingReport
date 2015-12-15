using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SpendingReport.Helpers;
using XMLParser.Data;
using data = XMLParser.Data;

namespace SpendingReport.Models
{
    public class BankAccountImportedPayments
    {
        private data.BankAccount _account;

        public data.BankAccount Account
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