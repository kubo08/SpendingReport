using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpendingReport.ViewModels
{
    public class TransactionFilterViewModel
    {
        public IList<SelectListItem> CategoryItems { get; set; }

        public string TransactionCategory { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}