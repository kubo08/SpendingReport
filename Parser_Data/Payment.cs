using System;
using System.Collections.Generic;
using System.Linq;

namespace parser.Data
{
    public enum TypeOfPayment
    {
        CardPayment,
        ATMWithdrawall,
        CashPayment,
    }

    public class Payment
    {
        #region Properties

        public AmountInfo TransactionAmount { get; set; }

        public BankAccount BankAccount { get; set; }

        public string Description { get; set; }

        public DateTime? DatePosted { get; set; }

        public DateTime? DateAvailable { get; set; }

        public string TransactionName { get; set; }

        public string Reference
        {
            get { return String.Format("/VS{0}/SS{1}/KS{2}", VariableSymbol, SpecificSymbol, ConstantSymbol); }

            set
            {
                if (String.IsNullOrEmpty(value)) return;
                string[] symbols = value.Split('/').Where(x => !String.IsNullOrEmpty(x)).ToArray();
                if (symbols[0].Length > 2)
                    VariableSymbol = long.Parse(symbols[0].Substring(2));
                if (symbols[1].Length > 2)
                    SpecificSymbol = long.Parse(symbols[1].Substring(2));
                if (symbols[2].Length > 2)
                    ConstantSymbol = short.Parse(symbols[2].Substring(2));
            }
        }

        public long VariableSymbol { get; set; }

        public short ConstantSymbol { get; set; }

        public long SpecificSymbol { get; set; }

        public TypeOfPayment? PaymentType { get; set; }

        public List<string> Purpose { get; set; }

        #endregion

        public Payment() { }

        public Payment(Payment transaction)
        {

        }
    }
}