using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLParser.Data;

namespace XMLParser
{
    public interface IParser
    {

        //T ParseReport(string textReport);

        //void ProcessReport(T report);

        //IEnumerable<Payment> GetPaymentsFromReport(string report);

        IEnumerable<Payment> ParseXML();

        Bank GetBankAccountWithNewPayments();

    }
}
