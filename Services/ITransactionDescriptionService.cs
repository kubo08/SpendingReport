using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SpendingReport.Models;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionDescriptionService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionDescriptionService
    {
        [OperationContract]
        bool AddTransactionDescription(TransactionDescription model);
    }
}
