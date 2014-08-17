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
using XMLParser;
using XMLParser.Data;
using PagedList.Mvc;
using PagedList;

namespace spending_report.Controllers
{
    public class UploadController : Controller
    {
        private const int PAGE_SIZE = 10;

        [HttpPost]
        public ActionResult Upload(int page=1)
        {
            var path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));
            
            Parser parser = new Parser(path);
            BankAccountPayments accountPayments = new BankAccountPayments
            {
                Account = parser.GetBankAccountWithNewPayments(),
                pager = new Pager
                {
                    CurrentPageIndex = page,
                    PageSize = PAGE_SIZE
                }
            };
            accountPayments.pager.ItemsCount = accountPayments.Account.Payments.Count;
            ViewData["count"] = EntityHelpers.SaveData(accountPayments.Account,1);      //todo: tahat pouzivatela, teraz sa pouziva natvrdo id: 1

            //accountPayments.Account.Payments =
            //    accountPayments.Account.Payments.Skip(page - 1 * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return View("UploadDocument", accountPayments.Account.Payments.ToPagedList());
        }

        
    }

}