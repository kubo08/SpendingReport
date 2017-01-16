using System;
using System.IO;
using parser;
using parser.Data;
using Parser.CSV_Parser;


namespace Parser.BaseParser
{
    public class Parser
    {
        private Stream stream;
        private ParserBase parser;
        //get concrete parser type(xml, csv,...)
        public Parser(Stream stream)
        {
            this.stream = stream;
            parser = GetParser();
        }

        private ParserBase GetParser()
        {
            ParserBase parser;
            var file =
                new System.IO.StreamReader(stream);
            var line = file.ReadLine();
            stream.Seek(0, SeekOrigin.Begin);

            if (line.Contains("xml"))
            {
                parser = new parser.XMLParser(stream);
            }
            //csv
            else
            {
                parser = new CSVParser(stream);
            }
            return parser;
        }

        public Import GetData()
        {
            return parser.GetData();
        }
    }
}
