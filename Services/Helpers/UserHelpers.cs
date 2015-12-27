using System;
using System.Linq;
using SpendingReportEntity4;
using User = SpendingReportEntity4.User;

namespace Services.Helpers
{
    public static class UserHelpers
    {
        public static User GetUserByID(int UserId)
        {
            //todo:otestovat static
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var currentUser = context.Users.Include("BankAccounts").FirstOrDefault(t => t.Id == UserId);
                    if (currentUser == null)
                        throw new Exception("Používateľ nebol nájdený!");
                    return currentUser;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}