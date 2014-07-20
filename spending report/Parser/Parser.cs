//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using XmlObjects;
//using spending_report.Data;
//using System.Xml;
//using System.Xml.Serialization;
//using Helpers;


//namespace spending_report.Parser
//{
//    //public  class ParserBase<T> where T : class
//    //{

//    //    #region Properties

//    //    public IParser<T> Parser { get; set; }

//    //    private T _xml;

//    //    #endregion

//    //    public ParserBase(string report)
//    //    {
//    //        var @switch = new Dictionary<Type, int>{
//    //        {typeof(OFX),1}
//    //    };

//    //        _xml = report.ToXML<T>();

//    //        int type = @switch[typeof(T)]();

//    //        switch (type)
//    //        {
//    //            case 1:
//    //                Parser = new TBParser<T>(_xml);
//    //                break;
//    //            default:
//    //                throw new Exception("Aplication does not support parser for this report");
//    //        }
//    //    }        
//    //}
//    public class Parser
//    {
//        #region Properties

         

//        #endregion

//        public Parser(string path)
//        {
//            //var @switch = new Dictionary<Type, int>
//            //{
//            //    {typeof (OFX), 1}
//            //};

//            //_xml = report.ToXML<T>();

//            //int type = @switch[typeof (T)]();

//            //switch (type)
//            //{
//            //    case 1:
//            //        Parser = new TBParser<T>(_xml);
//            //        break;
//            //    default:
//            //        throw new Exception("Aplication does not support parser for this report");
//            //}
//            ReadXmlFile(path);
//        }

//        private XmlElement GetRootNode(XmlDocument xmlDoc)
//        {
//            XmlElement root = xmlDoc.DocumentElement;
//            XmlElement root2 = xmlDoc.OwnerDocument.DocumentElement;

//            return root;
//        }

//        public void ReadXmlFile(string path)
//        {
//            XmlDocument xmlDoc = new XmlDocument();
//            xmlDoc.Load(path);
//            GetRootNode(xmlDoc);
//            //try
//            //{
//            //    System.Xml.Serialization.XmlSerializer reader =
//            //        new System.Xml.Serialization.XmlSerializer(typeof(OFX));
//            //    StreamReader file = new StreamReader(path);

//            //    var overview = (OFX)reader.Deserialize(file);
//            //    file.Dispose();
//            //    File.Delete(path);

//            //    int count = ProcessPayments(overview.STMTRS.BANKTRANLIST);

//            //    return count;
//            //}
//            //catch (Exception ex)
//            //{
//            //    throw ex;
//            //}
//        }

//    }
//}