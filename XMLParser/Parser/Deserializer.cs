using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
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

        public object Deserialize<T>(string path) where T : class 
        {
            var reader = new XmlSerializer(typeof(T));
            var file = new StreamReader(path);
            
            //var parser = DescribeParser<T>(reader, file);
            var overview = (T) reader.Deserialize(file);

            file.Dispose();
            //File.Delete(path);
            return overview;
        }

        private object DescribeParser<T>(XmlSerializer reader, StreamReader file)
        {
            //if (typeof(T) == typeof(OFX))
            //{
            //    var overview = (OFX) reader.Deserialize(file);

                //return new TBParser(overview);
            //}
            var overview = (T) reader.Deserialize(file);

            //throw new NotSupportedException("Aplication does not support parser for this report");
            return overview;
        }
    }
}
