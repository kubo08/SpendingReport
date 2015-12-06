using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionsOperationsService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionsOperationsService
    {
        [OperationContract]
        IEnumerable<Transaction> GetTransactionsByUserID(int userId);


    }

    [DataContract]
    public class Transaction
    {
        [DataMember]
        public BankAccount BankAccount { get; set; }

        [DataMember]
        public TransactionAmount TransacionAmount { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public string BankName { get; set; }

        [DataMember]
        public long AccountNumber { get; set; }

        [DataMember]
        public long BankCode { get; set; }
    }

    [DataContract]
    public class TransactionAmount
    {
        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public int TransactionType { get; set; }

        [DataMember]
        public int PaymentType { get; set; }
    }
}
