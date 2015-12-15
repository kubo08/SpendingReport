using System.Collections.Generic;
using SpendingReport.Models;

namespace SpendingReport.ViewModels
{
    public class TransactionDescriptionsViewModel
    {
        public IEnumerable<TransactionDescriptionsModel> Descriptions { get; set; }
    }
}