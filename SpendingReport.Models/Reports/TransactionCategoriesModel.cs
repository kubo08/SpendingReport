using System.Collections.Generic;

namespace SpendingReport.Models
{
    public class TransactionCategoriesModel : CategoryBase
    {
        public IList<CategoryNameModel> Category { get; set; }
    }
}
