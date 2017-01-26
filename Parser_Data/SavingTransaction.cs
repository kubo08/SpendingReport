using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Data
{
    public class SavingTransaction
    {
        public double Amount { get; set; }
        public double Price { get; set; }
        public double PayedPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
