//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Xml;
//using System.Xml.Serialization;

//namespace Helpers
//{
//    internal static class ParseHelpers
//    {
//        public static Stream ToStream(this string text)
//        {
//            var stream = new MemoryStream();
//            var writer = new StreamWriter(stream);
//            writer.Write(text);
//            writer.Flush();
//            stream.Position = 0;
//            return stream;
//        }

//        public static T ToXML<T>(this string text) where T : class
//        {
//            var reader = XmlReader.Create(text.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
//            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
//        }
//    }
//}
