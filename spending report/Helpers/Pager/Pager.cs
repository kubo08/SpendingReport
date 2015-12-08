using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spending_report.Helpers
{
    public class Pager
    {
        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int ItemsCount { get; set; }
    }


}