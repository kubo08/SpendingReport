using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using spending_report.Models;
using Support;
using XMLParser.Data;
using XMLParser;
using PagedList.Mvc;
using PagedList;

namespace spending_report.Controllers
{
    public class UploadController : Controller
    {
        private const int PAGE_SIZE = 10;

        public ActionResult SelectFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            string path = null;
            Import import;

            try
            {
                path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));

                Parser parser = new Parser(path);
                import = EntityHelpers.SaveData(parser.GetBankAccountWithNewPayments(path),1);  //todo: tahat aktualneho pouzivatela

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            finally
            {
                if (path != null) System.IO.File.Delete(path);
            }

            BankAccountPayments bankPayments = new BankAccountPayments
            {
                Transactions = import.Account.Payments.ToPagedList(1,PAGE_SIZE),
                Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGE_SIZE
                }
            };
            bankPayments.Pager.ItemsCount = bankPayments.Transactions.Count;
            Session["import"] = import;            

            //bankPayments.TransactionImport.Transactions =
            //    bankPayments.TransactionImport.Transactions.ToPagedList(page,PAGE_SIZE);
            return View("UploadDocument", bankPayments);
        }

        [HttpGet]
        public ActionResult Upload(int Page)
        {
            var import = (Import)Session["import"];
            BankAccountPayments bankPayments = new BankAccountPayments
            {
                Transactions = import.Account.Payments.ToPagedList(Page, PAGE_SIZE),
                Pager = new Pager
                {
                    CurrentPageIndex = Page,
                    PageSize = PAGE_SIZE
                }
            };
            bankPayments.Pager.ItemsCount = bankPayments.Transactions.Count;


            return View("UploadDocument", bankPayments);
        }
    }

}