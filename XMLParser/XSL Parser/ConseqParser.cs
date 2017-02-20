using Parser.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Parser.XSL_Parser
{
    public class ConseqParser
    {
        private readonly Stream _stream;

        public ConseqParser(Stream stream)
        {
            _stream = stream;
        }

        public IList<ConseqData> GetData()
        {
            var reader = new StreamReader(_stream);

            var result = new List<ConseqData>();

            var i = 0;
            var item = new ConseqData();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Trim().StartsWith("<tr"))
                {
                    i = 0;
                    item = new ConseqData();
                }
                if (!line.Trim().StartsWith("<td"))
                {
                    continue;
                }
                var split = line.Split(new[] { '<', '>' });
                if (i == 0)
                {
                    item.Date = DateTime.Parse(split[2]);
                }
                if (i == 1)
                {
                    item.Price = Double.Parse(split[2], CultureInfo.InvariantCulture);
                    result.Add(item);
                }
                i++;
            }

            return result;
        }

    }
}
