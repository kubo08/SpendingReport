using PagedList;
using SpendingReport.Models;
using SpendingReport.Helpers;

namespace SpendingReport.ViewModels
{
    public class TransactionsListModel
    {
        public Pager Pager { get; set; }

        public IPagedList<Transaction> TransactionsList { get; set; }
    }
}