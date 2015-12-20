using System.Collections.Generic;
using SpendingReport.Models;

namespace SpendingReport.ViewModels
{
    public class TransactionCategoriesViewModel
    {
        public IEnumerable<TransactionCategoriesModel> Categories { get; set; }
    }
}