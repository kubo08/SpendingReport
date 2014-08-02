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
            BankPayments bankPayments = new BankPayments
            {
                Bank = parser.GetBankAccountWithNewPayments(),
                pager = new Pager
                {
                    CurrentPageIndex = page,
                    PageSize = PAGE_SIZE
                }
            };
            bankPayments.pager.ItemsCount = bankPayments.Bank.Payments.Count;
            ViewData["count"] = EntityHelpers.SaveData(bankPayments.Bank);

            bankPayments.Bank.Payments =
                bankPayments.Bank.Payments.Skip(page-1 * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return View("UploadDocument", bankPayments);
        }

        
    }

    public class User
    {
        private List<GroupMembership> _groupMemberships = null;

        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool? Enabled { get; set; }
        public string SchoolCode { get; set; }
        public string EduId { get; set; }
        public string UUID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Guid ObjectGuid { get; set; }
        public string FullName { get { return String.Format("{0} {1}", Surname.ToUpper(), GivenName); } }
        public string Description { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }

        public string State
        {
            get
            {
                if (Enabled.HasValue)
                {
                    return Enabled.Value == true ? "Aktívny" : "Neaktívny";
                }
                return "Nedefinované";
            }
        }

        //parametre pre admin kontakt
        public string AdminName { get; set; }

        public List<GroupMembership> GroupMemberShips
        {
            get { return (_groupMemberships); }
            set { _groupMemberships = value; }
        }

        

    }

    public class GroupMembership
    {
        public UserGroup Group { get; set; }
        public bool IsUserMember { get; set; }
    }

    public class UserGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}