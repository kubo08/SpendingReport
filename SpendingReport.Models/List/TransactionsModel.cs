using System.Collections.Generic;

namespace SpendingReport.Models
{
    public class TransactionsModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }

        public int TotalItems { get; set; }
    }
}
