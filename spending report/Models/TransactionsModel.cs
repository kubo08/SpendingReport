using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using spending_report.remote.TransactionsOperationsService;
using XMLParser.Data;

namespace spending_report.Models
{
    public class TransactionsModel
    {
        public Pager Pager { get; set; }

        public IPagedList<Transaction> TransactionsList { get; set; }
    }
}