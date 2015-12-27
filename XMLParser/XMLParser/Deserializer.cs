using System.IO;
using System.Xml.Serialization;

namespace parser
{
    class Deserializer
    {
        private static Deserializer _instance;

        public Deserializer() { }

        public static Deserializer Manager
        {
            get { return _instance ?? (_instance = new Deserializer()); }
        }

        public object Deserialize<T>(Stream stream) where T : class
        {
            var reader = new XmlSerializer(typeof(T));

            var overview = (T)reader.Deserialize(stream);

            stream.Dispose();
            return overview;
        }
    }
}
