using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpendingReport.Models
{
    public class TransactionCategoriesModel
    {
        public IList<CategoryNameModel> Category { get; set; }
    }
}