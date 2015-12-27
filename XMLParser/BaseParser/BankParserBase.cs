using System.IO;
using parser;
using parser.Data;
using XmlObjects;

namespace Parser.XMLParser
{
    public class BankParserBase<T> where T : class
    {
        protected T _report;
        protected Stream stream;

        public BankParserBase(Stream stream)
        {
            this.stream = stream;
        }

        protected void Deserialize()
        {
            stream.Seek(0, SeekOrigin.Begin);
            _report = (T)Deserializer.Manager.Deserialize<T>(stream);
        }

    }
}
