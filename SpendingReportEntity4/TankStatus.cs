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
    
    public partial class TankStatus
    {
        public int Id { get; set; }
        public int TotalDistance { get; set; }
        public bool Empty { get; set; }
        public int CarId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Percentage { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Fueling Fueling { get; set; }
    }
}
