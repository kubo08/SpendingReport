using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLParser.Data
{
    public class ImportedPayment : Payment
    {
        private bool _imported;

        public bool Imported
        {
            get { return _imported; }
            set { _imported = value; }
        }

        public ImportedPayment(bool isImported)
            : base()
        {
            _imported = isImported;
        }

        public ImportedPayment()
            : base()
        { }
    }
}
