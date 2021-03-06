﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpendingReport.Helpers;
using SpendingReport.Models;
using SpendingReport.remote.ParsingService;
using data = parser.Data;
using parser.Data;

namespace SpendingReport.Controllers
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
            //HttpFileCollectionBase file;
            Import import = new Import();

            try
            {
                //path = XMLHelpers.SaveFile(Request.Files, Server.MapPath("~/temp/"));
                var file = Request.Files[0];

                var parser = new Parser.BaseParser.Parser(file.InputStream);
                using (var svc = new ParsingServiceClient())
                {
                    var data = parser.GetData();
                    import = svc.SaveData(data, 1);
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


            var bankImportedPayments = new BankAccountImportedPayments
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