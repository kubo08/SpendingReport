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
    
    public partial class Fueling
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public double FuelPrice { get; set; }
    
        public virtual Purchase Purchase { get; set; }
        public virtual TankStatus TankStatus { get; set; }
    }
}
