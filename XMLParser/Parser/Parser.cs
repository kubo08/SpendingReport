using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XmlObjects;
using XMLParser.Data;
using System.Xml;
using System.Xml.Serialization;
using Helpers;


namespace XMLParser
{
    //public  class ParserBase<T> where T : class
    //{

    //    #region Properties

    //    public IParser<T> Parser { get; set; }

    //    private T _xml;

    //    #endregion

    //    public ParserBase(string report)
    //    {
    //        var @switch = new Dictionary<Type, int>{
    //        {typeof(OFX),1}
    //    };

    //        _xml = report.ToXML<T>();

    //        int type = @switch[typeof(T)]();

    //        switch (type)
    //        {
    //            case 1:
    //                Parser = new TBParser<T>(_xml);
    //                break;
    //            default:
    //                throw new Exception("Aplication does not support parser for this report");
    //        }
    //    }        
    //}
    public class Parser
    {
        #region Properties

        private IParser _paymentParser;
        //public IParser PaymentsParser { private get; private set; }

        #endregion        

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class and process the xml file.
        /// </summary>
        /// <param name="path">The path.</param>
        public Parser(string path)
        {
            //var @switch = new Dictionary<Type, int>
            //{
            //    {typeof (OFX), 1}
            //};

            //_xml = report.ToXML<T>();

            //int type = @switch[typeof (T)]();

            //switch (type)
            //{
            //    case 1:
            //        Parser = new TBParser<T>(_xml);
            //        break;
            //    default:
            //        throw new Exception("Aplication does not support parser for this report");
            //}
            ReadXmlFile(path);
        }


        /// <summary>
        /// Reads the XML file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void ReadXmlFile(string path)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var root = GetRootNode(xmlDoc);

                Deserialize(path, root);

                //int count = ProcessPayments(overview.STMTRS.BANKTRANLIST);

                //return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Bank GetBankAccountWithNewPayments()
        {
            return _paymentParser.GetBankAccountWithNewPayments();
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
        /// Deserializes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="root">The root.</param>
        /// <exception cref="System.NotImplementedException">Aplication does not support parser for this report</exception>
        private void Deserialize(string path, XmlElement root)
        {
            int type = getType(root.Name);

            switch (type)
            {
                case 1:
                    CreateParser<OFX>(path);

                    break;
                default:
                    throw new NotImplementedException("Aplication does not support parser for this report");
            }

            
        }

        /// <summary>
        /// Creates the parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        private void CreateParser<T>(string path) where T : class
        {
            _paymentParser = Deserializer.Manager.GetParser<OFX>(path);
        }

        /// <summary>
        /// Gets the type of xml root node.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private int getType(string name)
        {
            if (String.Equals(name, typeof(OFX).Name))
            {
                return  1;
            }

            return 0;
        }

        #endregion

    }
}