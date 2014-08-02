using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLParser.Data;

namespace spending_report.Models
{
    public class BankPayments
    {
        private Bank _bank;
        
        public Bank Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        public Pager pager { get; set; }
    }
}