using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLParser.Data
{
    public class Import
    {
        public BankAccount Account { get; set; }
        //public List<Payment> Transactions { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
