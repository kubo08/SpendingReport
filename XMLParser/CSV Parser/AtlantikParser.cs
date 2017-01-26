using Parser.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using parser.Data;

namespace Parser.CSV_Parser
{
    public class AtlantikParser
    {
        private readonly Stream _stream;

        public AtlantikParser(Stream stream)
        {
            _stream = stream;
        }

        public IList<SavingTransaction> GetData()
        {

            var reader = new StreamReader(_stream);

            var result = new List<SavingTransaction>();

            var i = 0;
            while (!reader.EndOfStream)
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (i < 1 )
                    {
                        i++;
                        continue;
                    }

                    var values = line.Split(';');
                    if (values[9] != "BNP PARIBAS Plan EASY FUTURE 2021" || values[13] != "N")
                    {
                        continue;
                    }

                    try
                    {
                        var transaction = new SavingTransaction
                        {
                            Price=double.Parse(values[19], CultureInfo.InvariantCulture),
                            PayedPrice=Math.Abs(double.Parse(values[20], CultureInfo.InvariantCulture)),
                            Date= DateTime.Parse(values[15]),
                            Amount=double.Parse(values[18], CultureInfo.InvariantCulture)
                        };

                        result.Add(transaction);
                    }
                    catch (Exception ex)
                    {
                        //todo:
                    }
                }
            }

            return result;
        }

    }
}
