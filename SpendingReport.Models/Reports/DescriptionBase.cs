using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpendingReport.Models
{
    public abstract class DescriptionBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
