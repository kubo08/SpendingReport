using System;

namespace parser.Data
{
    public class Import
    {
        public ImportedBankAccount Account { get; set; }
        //public List<Payment> Transactions { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
