//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingReportEntity4
{
    using System;
    using System.Collections.Generic;
    
    public partial class SavingTransactions
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double HighestPrice { get; set; }
        public double PayedPrice { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Saving Saving { get; set; }
    }
}
