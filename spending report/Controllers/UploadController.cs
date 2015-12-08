using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using spending_report.Helpers;
using spending_report.Models;
using Support;
using XMLParser.Data;
using XMLParser;
using PagedList.Mvc;
using PagedList;
using spending_report.remote.ParsingService;
using data = XMLParser.Data;

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
                using (var svc = new ParsingServiceClient())
                {
                    import = svc.SaveData(parser.GetBankAccountWithNewPayments(path), 1);
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

            Session["import"] = import;


            BankAccountImportedPayments bankImportedPayments = new BankAccountImportedPayments
            {
                Transactions = import.Account.Payments.ToPagedList(1, PAGE_SIZE),
                Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGE_SIZE
                },
                Account = new data.BankAccount
                {
                    AccountID = import.Account.AccountID,
                    Bank = new data.Bank
                    {
                        BankID = import.Account.Bank.BankID
                    },
                    IBan = import.Account.IBan
                },
                From = import.From,
                To = import.To
            };
            bankImportedPayments.Pager.ItemsCount = bankImportedPayments.Transactions.Count;


            //bankImportedPayments.TransactionImport.Transactions =
            //    bankImportedPayments.TransactionImport.Transactions.ToPagedList(page,PAGE_SIZE);
            return View("UploadDocument", bankImportedPayments);
        }

        [HttpPost]
        public ActionResult Filter(BankAccountImportedPayments model)
        {
            var import = (Import)Session["import"];
            BankAccountImportedPayments bankImportedPayments = new BankAccountImportedPayments
            {
                //Transactions = import.Account.Payments.ToPagedList(1, PAGE_SIZE),
                Pager = new Pager
                {
                    CurrentPageIndex = 1,
                    PageSize = PAGE_SIZE
                },
                Account = new data.BankAccount
                {
                    AccountID = import.Account.AccountID,
                    Bank = new data.Bank
                    {
                        BankID = import.Account.Bank.BankID
                    },
                    IBan = import.Account.IBan
                },
                From = import.From,
                To = import.To
            };
            if (model.OnlyImported)
            {
                bankImportedPayments.Transactions = import.Account.Payments.Where(a => a.Imported).ToPagedList(1, PAGE_SIZE);
            }
            else
            {
                bankImportedPayments.Transactions = import.Account.Payments.ToPagedList(1, PAGE_SIZE);
            }
            bankImportedPayments.Pager.ItemsCount = bankImportedPayments.Transactions.Count;

            return View("UploadDocument", bankImportedPayments);
        }

        [HttpGet]
        public ActionResult Upload(int Page, BankAccountImportedPayments model)
        {
            var import = (Import)Session["import"];
            BankAccountImportedPayments bankImportedPayments = new BankAccountImportedPayments
            {
                Transactions = import.Account.Payments.ToPagedList(Page, PAGE_SIZE),
                Pager = new Pager
                {
                    CurrentPageIndex = Page,
                    PageSize = PAGE_SIZE
                },
                Account = new data.BankAccount
                {
                    AccountID = import.Account.AccountID,
                    Bank = new data.Bank
                    {
                        BankID = import.Account.Bank.BankID
                    },
                    IBan = import.Account.IBan
                },
                From = import.From,
                To = import.To
            };
            bankImportedPayments.Pager.ItemsCount = bankImportedPayments.Transactions.Count;


            return View("UploadDocument", bankImportedPayments);
        }
    }

}