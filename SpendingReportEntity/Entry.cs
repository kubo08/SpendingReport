//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingReportEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entry
    {
        public Entry()
        {
            this.Purposes = new HashSet<Purpose>();
        }
    
        public int EntryId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public string Memo { get; set; }
        public int BankAccountId { get; set; }
        public Nullable<System.DateTime> DateAvailable { get; set; }
        public Nullable<long> VariableSymbol { get; set; }
        public Nullable<short> ConstantSymbol { get; set; }
        public Nullable<long> SpecificSymbol { get; set; }
        public string Reference { get; set; }
        public Nullable<int> PaymentTypeId { get; set; }
        public int BankId { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual BankAccount BankAccount { get; set; }
        public virtual AmountInfo AmountInfo { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ICollection<Purpose> Purposes { get; set; }
    }
}