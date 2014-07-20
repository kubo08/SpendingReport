using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using XmlObjects;

namespace XMLParser
{
    class Deserializer
    {
        private static Deserializer _instance;
        
        public Deserializer() { }

        public static Deserializer Manager
        {
            get { return _instance ?? (_instance = new Deserializer()); }
        }

        public IParser GetParser<T>(string path) where T : class 
        {
            var reader = new XmlSerializer(typeof(T));
            var file = new StreamReader(path);

            var parser = DescribeParser<T>(reader, file);

            file.Dispose();
            File.Delete(path);
            return parser;
        }

        private IParser DescribeParser<T>(XmlSerializer reader, StreamReader file)
        {
            if (typeof(T) == typeof(OFX))
            {
                var overview = (OFX) reader.Deserialize(file);

                return new TBParser(overview);
            }

            throw new NotImplementedException("Aplication does not support parser for this report");
        }
    }
}
