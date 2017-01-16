using System.IO;
using parser;
using parser.Data;

namespace Parser.BaseParser
{
    public abstract class ParserBase
    {
        protected Stream stream;

        protected readonly IBankParser _parser;

        protected ParserBase(Stream stream)
        {
            this.stream = stream;
            _parser = GetParser();
        }

        public abstract IBankParser GetParser();

        public abstract Import GetData();
    }
}
