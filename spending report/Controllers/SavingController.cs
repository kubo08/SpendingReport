using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendingReport.remote.ParsingService;
using Parser.CSV_Parser;

namespace SpendingReport.Controllers
{
    public class SavingController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            string path = null;

            try
            {
                //path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));
                var file = Request.Files[0];

                var parser = new AtlantikParser(file.InputStream);
                using (var svc = new ParsingServiceClient())
                {
                    var data = parser.GetData();
                    svc.SaveSavingTransactions(data.ToArray(), "Atlantik");
                    //todo: tahat aktualneho pouzivatela
                }

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            finally
            {
                if (path != null) System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }
    }
}