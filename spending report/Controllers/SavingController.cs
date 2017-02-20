using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendingReport.remote.ParsingService;
using Parser.CSV_Parser;
using Parser.XSL_Parser;
using SpendingReport.ViewModels;

namespace SpendingReport.Controllers
{
    public class SavingController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<SavingListViewModel>();
            using (var svc = new ParsingServiceClient())
            {
                var result = svc.Getsavings();
                model = result.Select(a => new SavingListViewModel {Id = a.Id, Name = a.Name}).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int savingId)
        {
            var model = new SavingDetailViewmodel();
            using (var svc = new ParsingServiceClient())
            {
                var result = svc.GetSavingDetail(savingId);
                model.AmountIn = result.AmountIn;
                model.MyPrice = result.MyPrice;
            }

            return View(model);
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

        [HttpPost]
        public ActionResult UploadHistoricalPrices()
        {
            string path = null;

            try
            {
                //path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));
                var file = Request.Files[0];

                var parser = new ConseqParser(file.InputStream);
                using (var svc = new ParsingServiceClient())
                {
                    var data = parser.GetData();
                    svc.FillHistoricalData(data.ToArray(), "Atlantik");
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