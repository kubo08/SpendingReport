namespace SpendingReportEntity2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entry
    {
        public Entry()
        {
            Purposes = new HashSet<Purpos>();
        }

        public int EntryId { get; set; }

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

        public int AmountInfo_Id { get; set; }

        public virtual AmountInfo AmountInfo { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual ICollection<Purpos> Purposes { get; set; }
    }
}
