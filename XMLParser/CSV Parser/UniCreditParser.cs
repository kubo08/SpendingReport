using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using parser.Data;

namespace Parser.CSV_Parser
{
    public class UniCreditParser : IBankParser
    {
        private readonly Stream stream;

        public UniCreditParser(Stream stream)
        {
            this.stream = stream;
        }

        public Import GetPayments()
        {
            var import = new Import();

            var reader = new StreamReader(stream);

            var account = new ImportedBankAccount
            {
                IBan = "test",
                AccountID=1,
                Bank=new Bank
                {
                    BankID=1
                }
            };

            var i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (i < 3)
                {
                    i++;
                    continue;
                }

                var values = line.Split(';');
                try
                {
                    var paymennt = new ImportedPayment
                    {
                        BankAccount = new BankAccount {IBan = values[8]},
                        ConstantSymbol = !string.IsNullOrWhiteSpace(values[19]) ? short.Parse(values[19]) : (short)0,
                        VariableSymbol = !string.IsNullOrWhiteSpace(values[20]) ? long.Parse(values[20]) : 0,
                        SpecificSymbol = !string.IsNullOrWhiteSpace(values[21]) ? long.Parse(values[21]): 0,
                        TransactionAmount = new AmountInfo
                        {
                            Amount = Math.Abs(decimal.Parse(values[1])),
                            Currency = values[2],
                            Type = decimal.Parse(values[1]) > 0 ? AmountType.Credit : AmountType.Debit
                        },
                        Description = $"{values[13]} {values[14]} {values[15]} {values[16]} {values[17]}",
                        DatePosted = DateTime.Parse(values[3]),
                        DateAvailable = DateTime.Parse(values[4])
                    };

                    account.Payments.Add(paymennt);
                }
                catch(Exception ex)
                {
                    //todo:
                }
            }

            import.Account = account;

            return import;
        }
    }
}
