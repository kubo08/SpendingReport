using System;
using SpendingReportEntity4;
using entity = SpendingReportEntity4;
using TransactionDescription = SpendingReport.Models.TransactionDescription;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionDescriptionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionDescriptionService.svc or TransactionDescriptionService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionDescriptionService : ITransactionDescriptionService
    {

        public bool AddTransactionDescription(TransactionDescription model)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var description = new entity.TransactionDescription
                    {
                        Name = model.Name,
                        Description = model.Description
                    };
                    context.TransactionDescriptions.Add(description);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
