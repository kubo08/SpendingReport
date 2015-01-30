namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;

    public partial class Entry
    {
        public Entry()
        {
            Purposes = new HashSet<Purpose>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? DatePosted { get; set; }

        public string Memo { get; set; }

        public DateTime? DateAvailable { get; set; }

        public long? VariableSymbol { get; set; }

        public short? ConstantSymbol { get; set; }

        public long? SpecificSymbol { get; set; }

        public string Reference { get; set; }

        public int? PaymentTypeId { get; set; }

        public int BankId { get; set; }

        public DateTime DateAdded { get; set; }

        public int AmountInfoId { get; set; }

        public int? SourceAccountId { get; set; }

        public int? DestinationAccountId { get; set; }

        public virtual AmountInfo AmountInfo { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual BankAccount SourceAccount { get; set; }

        public virtual BankAccount DestinationAccount { get; set; }

        public virtual ICollection<Purpose> Purposes { get; set; }
    }
}
