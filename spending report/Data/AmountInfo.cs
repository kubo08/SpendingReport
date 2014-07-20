//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Web;

//namespace spending_report.Data
//{
//    public enum AmountType
//    {
//        Credit,
//        Debit
//    }

//    public class AmountInfo
//    {
//        #region Properties

//        public AmountType Type { get; set; }
//        public decimal Amount { get; set; }
//        public string Currency { get; set; }

//        #endregion

//        #region Constructors

//        public AmountInfo()
//        {
//        }

//        public AmountInfo(string amountwithCurrency, string separator, AmountType? type)
//        {
//            CultureInfo ci = (CultureInfo) CultureInfo.InvariantCulture.Clone();
//            ci.NumberFormat.CurrencyDecimalSeparator = separator;
//            var numAmount = decimal.Parse(amountwithCurrency.Substring(0, amountwithCurrency.Length - 3).Trim(), ci);
//            if (type != null)
//            {
//                Type = type.Value;
//            }
//            Amount = Math.Abs(numAmount);
//            Currency = amountwithCurrency.Substring(amountwithCurrency.Length - 3);
//        }

//        public AmountInfo(string amountwithCurrency, string separator)
//        {
//            CultureInfo ci = (CultureInfo) CultureInfo.InvariantCulture.Clone();
//            ci.NumberFormat.CurrencyDecimalSeparator = separator;
//            var numAmount = decimal.Parse(amountwithCurrency.Substring(0, amountwithCurrency.Length - 3).Trim(), ci);
//            Type = numAmount >= 0 ? AmountType.Credit : AmountType.Debit;
//            Amount = Math.Abs(numAmount);
//            Currency = amountwithCurrency.Substring(amountwithCurrency.Length - 3);
//        }

//        public AmountInfo(string amount, string currency, string separator) : this(amount, currency, separator, null)
//        {
//        }

//        public AmountInfo(decimal? amount, string currency) : this(amount.ToString(), currency, ".", null)
//        {
//        }

//        public AmountInfo(string amount, string currency, string separator, AmountType? type)
//        {
//            CultureInfo ci = (CultureInfo) CultureInfo.InvariantCulture.Clone();
//            ci.NumberFormat.CurrencyDecimalSeparator = separator;
//            var numAmount = decimal.Parse(amount.Trim(), ci);
//            if (type != null)
//            {
//                Type = type.Value;
//            }
//            else
//            {
//                Type = numAmount >= 0 ? AmountType.Credit : AmountType.Debit;
//            }
//            {

//            }
//            Amount = Math.Abs(numAmount);
//            Currency = currency;
//        }

//        public AmountInfo(decimal? amount, string currency, AmountType? type)
//            : this(amount.ToString(), currency, ".", type)
//        {
//        }

//        #endregion

//    }
//}