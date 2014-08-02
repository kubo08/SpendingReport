using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLParser.Data
{
    public class Bank
    {

        public enum bank
        {
            TatraBanka = 1,
            Zuno = 2,
            PostovaBanka = 3
        }

        private List<Payment> _payments = new List<Payment>(); 

        #region Properties

        public bank? Name { get; set; }

        public ushort? BankID { get; set; }

        public List<Payment> Payments
        {
            get { return _payments; }
            set { _payments = value; }
        }

        public BankAccount Account { get; set; }

        #endregion
    }
}
