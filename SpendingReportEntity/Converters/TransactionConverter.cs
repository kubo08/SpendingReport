using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLParser.Data;

namespace SpendingReportEntity.Converters
{
    public static class TransactionConverter
    {
        public static IEnumerable<Payment> EntityToModel(IEnumerable<Entry> Transactions)
        {
            var payments = new List<Payment>();
            foreach (var transaction in Transactions)
            {
                
            }
            return payments;
        }
    }
}
