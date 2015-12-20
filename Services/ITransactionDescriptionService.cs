using System.Collections.Generic;
using System.ServiceModel;
using SpendingReport.Models;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionDescriptionService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionDescriptionService
    {
        [OperationContract]
        bool AddTransactionCategory(CategoryModel model);

        [OperationContract]
        IEnumerable<TransactionCategoriesModel> GetAllTransactionCategories();

        [OperationContract]
        TransactionCategoriesModel GetTransactionCategoriesById(int id);

        [OperationContract]
        void UpdateAllCategories();
    }
}
