
//namespace XmlObjects
//{
//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
//    public partial class OFX
//    {

//        private OFXSTMTRS sTMTRSField;

//        /// <remarks/>
//        public OFXSTMTRS STMTRS
//        {
//            get
//            {
//                return this.sTMTRSField;
//            }
//            set
//            {
//                this.sTMTRSField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class OFXSTMTRS
//    {

//        private OFXSTMTRSBANKACCTFROM bANKACCTFROMField;

//        private OFXSTMTRSBANKTRANLIST bANKTRANLISTField;

//        /// <remarks/>
//        public OFXSTMTRSBANKACCTFROM BANKACCTFROM
//        {
//            get
//            {
//                return this.bANKACCTFROMField;
//            }
//            set
//            {
//                this.bANKACCTFROMField = value;
//            }
//        }

//        /// <remarks/>
//        public OFXSTMTRSBANKTRANLIST BANKTRANLIST
//        {
//            get
//            {
//                return this.bANKTRANLISTField;
//            }
//            set
//            {
//                this.bANKTRANLISTField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class OFXSTMTRSBANKACCTFROM
//    {

//        private ushort bANKIDField;

//        private uint aCCTIDField;

//        private string iBANField;

//        /// <remarks/>
//        public ushort BANKID
//        {
//            get
//            {
//                return this.bANKIDField;
//            }
//            set
//            {
//                this.bANKIDField = value;
//            }
//        }

//        /// <remarks/>
//        public uint ACCTID
//        {
//            get
//            {
//                return this.aCCTIDField;
//            }
//            set
//            {
//                this.aCCTIDField = value;
//            }
//        }

//        /// <remarks/>
//        public string IBAN
//        {
//            get
//            {
//                return this.iBANField;
//            }
//            set
//            {
//                this.iBANField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class OFXSTMTRSBANKTRANLIST
//    {

//        private uint dTSTARTField;

//        private uint dTENDField;

//        private OFXSTMTRSBANKTRANLISTSTMTTRN[] sTMTTRNField;

//        /// <remarks/>
//        public uint DTSTART
//        {
//            get
//            {
//                return this.dTSTARTField;
//            }
//            set
//            {
//                this.dTSTARTField = value;
//            }
//        }

//        /// <remarks/>
//        public uint DTEND
//        {
//            get
//            {
//                return this.dTENDField;
//            }
//            set
//            {
//                this.dTENDField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("STMTTRN")]
//        public OFXSTMTRSBANKTRANLISTSTMTTRN[] STMTTRN
//        {
//            get
//            {
//                return this.sTMTTRNField;
//            }
//            set
//            {
//                this.sTMTTRNField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class OFXSTMTRSBANKTRANLISTSTMTTRN
//    {

//        private string tRNTYPEField;

//        private uint dTPOSTEDField;

//        private uint dTAVAILField;

//        private decimal tRNAMTField;

//        private ulong tRNVASYMField;

//        private bool tRNVASYMFieldSpecified;

//        private ulong tRNSPSYMField;

//        private bool tRNSPSYMFieldSpecified;

//        private ushort tRNCOSYMField;

//        private bool tRNCOSYMFieldSpecified;

//        private string rEFERENCE_E2EField;

//        private string nAMEField;

//        private OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO bANKACCTTOField;

//        private string mEMOField;

//        private string cURRENCYField;

//        /// <remarks/>
//        public string TRNTYPE
//        {
//            get
//            {
//                return this.tRNTYPEField;
//            }
//            set
//            {
//                this.tRNTYPEField = value;
//            }
//        }

//        /// <remarks/>
//        public uint DTPOSTED
//        {
//            get
//            {
//                return this.dTPOSTEDField;
//            }
//            set
//            {
//                this.dTPOSTEDField = value;
//            }
//        }

//        /// <remarks/>
//        public uint DTAVAIL
//        {
//            get
//            {
//                return this.dTAVAILField;
//            }
//            set
//            {
//                this.dTAVAILField = value;
//            }
//        }

//        /// <remarks/>
//        public decimal TRNAMT
//        {
//            get
//            {
//                return this.tRNAMTField;
//            }
//            set
//            {
//                this.tRNAMTField = value;
//            }
//        }

//        /// <remarks/>
//        public ulong TRNVASYM
//        {
//            get
//            {
//                return this.tRNVASYMField;
//            }
//            set
//            {
//                this.tRNVASYMField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool TRNVASYMSpecified
//        {
//            get
//            {
//                return this.tRNVASYMFieldSpecified;
//            }
//            set
//            {
//                this.tRNVASYMFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        public ulong TRNSPSYM
//        {
//            get
//            {
//                return this.tRNSPSYMField;
//            }
//            set
//            {
//                this.tRNSPSYMField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool TRNSPSYMSpecified
//        {
//            get
//            {
//                return this.tRNSPSYMFieldSpecified;
//            }
//            set
//            {
//                this.tRNSPSYMFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        public ushort TRNCOSYM
//        {
//            get
//            {
//                return this.tRNCOSYMField;
//            }
//            set
//            {
//                this.tRNCOSYMField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool TRNCOSYMSpecified
//        {
//            get
//            {
//                return this.tRNCOSYMFieldSpecified;
//            }
//            set
//            {
//                this.tRNCOSYMFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        public string REFERENCE_E2E
//        {
//            get
//            {
//                return this.rEFERENCE_E2EField;
//            }
//            set
//            {
//                this.rEFERENCE_E2EField = value;
//            }
//        }

//        /// <remarks/>
//        public string NAME
//        {
//            get
//            {
//                return this.nAMEField;
//            }
//            set
//            {
//                this.nAMEField = value;
//            }
//        }

//        /// <remarks/>
//        public OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO BANKACCTTO
//        {
//            get
//            {
//                return this.bANKACCTTOField;
//            }
//            set
//            {
//                this.bANKACCTTOField = value;
//            }
//        }

//        /// <remarks/>
//        public string MEMO
//        {
//            get
//            {
//                return this.mEMOField;
//            }
//            set
//            {
//                this.mEMOField = value;
//            }
//        }

//        /// <remarks/>
//        public string CURRENCY
//        {
//            get
//            {
//                return this.cURRENCYField;
//            }
//            set
//            {
//                this.cURRENCYField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class OFXSTMTRSBANKTRANLISTSTMTTRNBANKACCTTO
//    {

//        private ushort bANKIDField;

//        private bool bANKIDFieldSpecified;

//        private ulong aCCTIDField;

//        private string iBANField;

//        /// <remarks/>
//        public ushort BANKID
//        {
//            get
//            {
//                return this.bANKIDField;
//            }
//            set
//            {
//                this.bANKIDField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool BANKIDSpecified
//        {
//            get
//            {
//                return this.bANKIDFieldSpecified;
//            }
//            set
//            {
//                this.bANKIDFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        public ulong ACCTID
//        {
//            get
//            {
//                return this.aCCTIDField;
//            }
//            set
//            {
//                this.aCCTIDField = value;
//            }
//        }

//        /// <remarks/>
//        public string IBAN
//        {
//            get
//            {
//                return this.iBANField;
//            }
//            set
//            {
//                this.iBANField = value;
//            }
//        }
//    }
//}