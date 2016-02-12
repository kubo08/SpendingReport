using System;

namespace SpendingReport.Models
{
    public class Transaction
    {
        public BankAccount BankAccount { get; set; }

        public TransactionAmount TransacionAmount { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DateAvailable { get; set; }

        public string SpecificSymbol { get; set; }

        public string VariableSymbol { get; set; }

        public string ConstantSymbol { get; set; }
    }
}
