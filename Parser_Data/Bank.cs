using System.Collections.Generic;

namespace parser.Data
{
    public class Bank
    {
        private bank? _name = bank.Undefined;
        private ushort? _bankID;

        public enum bank
        {
            Undefined =0,
            TatraBanka = 1,
            Zuno = 2,
            PostovaBanka = 3
        }

        private List<Payment> _payments = new List<Payment>(); 

        #region Properties

        public bank? Name {
            get { return _name; }
        }

        public ushort? BankID
        {
            get { return _bankID; }
            set
            {
                _bankID = value;
                switch (value)
                {
                    case 1100:
                        _name = bank.TatraBanka;
                        break;
                }
            }
        }

        //public List<Payment> Payments
        //{
        //    get { return _payments; }
        //    set { _payments = value; }
        //}

        public BankAccount Account { get; set; }

        #endregion
    }
}
