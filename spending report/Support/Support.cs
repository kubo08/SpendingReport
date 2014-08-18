using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpendingReportEntity.Converters;
using XMLParser.Data;

namespace Support
{
    public static class Support
    {

        public static IEnumerable<Payment> GetTransactions()
        {
            var transactions = EntityHelpers.GetTransactions();

            return TransactionConverter.EntityToModel(transactions);
        } 
    }
}