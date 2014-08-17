using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMLParser.Data;

namespace spending_report.Models
{
    public class BankAccountPayments
    {
        private BankAccount _account;
        
        public BankAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public Pager pager { get; set; }
    }
}