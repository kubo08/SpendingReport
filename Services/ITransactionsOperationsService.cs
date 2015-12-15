using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using SpendingReport.Models;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionsOperationsService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionsOperationsService
    {
        [OperationContract]
        TransactionsModel GetTransactionsByUserID(int? userId, int skip, int? take);

        [OperationContract]
        TransactionsModel GetAllTransactions();
    }


}
