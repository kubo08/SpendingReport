using System;
using System.IO;
using Parser;
using XmlObjects;
using parser.Data;
using System.Xml;
using ParserBase = Parser.BaseParser.ParserBase;


namespace parser
{

    public class XMLParser : ParserBase
    {
        private XmlDocument _report;



        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class and process the xml file.
        /// </summary>
        /// <param name="path">The path.</param>
        public XMLParser(Stream stream) : base(stream)
        {
            //_parser = GetParser();
        }

        public override Import GetData()
        {
            return _parser.GetPayments();
        }

        /// <summary>
        /// Reads the XML file.
        /// </summary>
        /// <param name="path">The path.</param>
        public XmlDocument ReadXmlFile(Stream stream)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);
                return xmlDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Helper Methods

        /// <summary>
        /// Gets the root node.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns></returns>
        private XmlElement GetRootNode(XmlDocument xmlDoc)
        {
            XmlElement root = xmlDoc.DocumentElement;
            //XmlElement root2 = xmlDoc.OwnerDocument.DocumentElement;

            return root;
        }

        /// <summary>
        /// Gets the type of xml root node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private int getType(string name)
        {
            if (String.Equals(name.ToLower().Trim(), typeof(OFX).Name.ToLower().Trim()))
            {
                return 1;
            }

            return 0;
        }

        #endregion

        public override IBankParser GetParser()
        {
            //var @switch = new Dictionary<string, int>
            //{
            //    {typeof (OFX).Name.ToLower().Trim(), 1}
            //};
            _report = ReadXmlFile(stream);
            var root = GetRootNode(_report);

            //_xml = report.ToXML<T>();

            //int type = @switch[typeof(OFX).Name]();
            var type = getType(root.Name.Trim().ToLower());

            switch (type)
            {
                case 1:
                    return new TBParser(stream);
                    break;
                default:
                    throw new NotSupportedException("Aplication does not support parser for this report");
            }
        }
    }
}