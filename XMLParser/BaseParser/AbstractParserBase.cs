using parser;
using parser.Data;

namespace Parser.BaseParser
{
    public abstract class ParserBase
    {
        public abstract IBankParser GetParser();

        public abstract Import GetData();
    }
}
