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
    
    public partial class Purpose
    {
        public Purpose()
        {
            this.Entries = new HashSet<Entry>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
