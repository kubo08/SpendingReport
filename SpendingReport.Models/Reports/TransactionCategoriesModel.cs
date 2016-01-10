using System.Collections.Generic;

namespace SpendingReport.Service.Models
{
    public class TransactionCategoriesModel : CategoryBase
    {
        public IList<CategoryNameModel> Category { get; set; }
    }
}
