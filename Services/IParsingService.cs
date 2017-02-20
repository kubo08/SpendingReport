using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SpendingReportEntity4;
using parser.Data;
using Parser.Data;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParsingService" in both code and config file together.
    [ServiceContract]
    public interface IParsingService
    {
        [OperationContract]
        IList<SavingList> Getsavings();

        [OperationContract]
        SavingDetail GetSavingDetail(int SavingId);

        [OperationContract]
        IList<SavingTransaction> SaveSavingTransactions(IList<SavingTransaction> savingTransactions, string savingName);

        [OperationContract]
        bool FillHistoricalData(IList<ConseqData> data, string savingName);

        [OperationContract]
        Import SaveData(Import bankPayments, int UserId);

        [OperationContract]
        IEnumerable<Entry> GetTransactions();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
