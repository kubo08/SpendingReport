using System;
using System.IO;
using Parser.BaseParser;
using parser.Data;

namespace Parser.CSV_Parser
{
    public class CSVParser : ParserBase
    {
        public CSVParser(Stream stream):base(stream)
        {
            
        }

        public override IBankParser GetParser()
        {
            return new UniCreditParser(stream);

            //switch (type)
            //{
            //    case 1:
            //        return new UniCreditParser(stream);
            //        break;
            //    default:
            //        throw new NotSupportedException("Aplication does not support parser for this report");
            //}
        }

        public override Import GetData()
        {
            return _parser.GetPayments();
        }
    }
}
