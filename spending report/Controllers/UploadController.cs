using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Support;
using XMLParser;
using XMLParser.Data;

namespace spending_report.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            var path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));
            
            Parser parser = new Parser(path);
            
            Bank bankAccountWithPayments = parser.GetBankAccountWithNewPayments();
            ViewData["count"] = EntityHelpers.SaveData(bankAccountWithPayments);

            //ViewData["count"] = Helpers.ReadXmlFile(path);
            return View("UploadDocument");
        }
    }
}