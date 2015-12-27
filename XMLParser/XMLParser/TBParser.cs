using System.IO;
using Parser;
using Parser.XMLParser;
using XmlObjects;
using parser.Converters;
using parser.Data;

namespace parser
{
    public class TBParser : BankParserBase<OFX>, IBankParser
    {
        public TBParser(Stream stream)
            : base(stream)
        {
        }

        public Import GetPayments()
        {
            Deserialize();
            var data = TBConverter.ObcectToModel(_report);
            return data;
        }


    }
}