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
using entity = SpendingReportEntity4;
using data = parser.Data;


namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParsingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParsingService.svc or ParsingService.svc.cs at the Solution Explorer and start debugging.
    public class ParsingService : IParsingService
    {

        public IList<SavingTransaction> SaveSavingTransactions(IList<SavingTransaction> savingTransactions, string savingName)
        {
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var saving = context.Savings.FirstOrDefault(a => a.Name == savingName);
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        foreach (var transaction in savingTransactions)
                        {
                            var item = new SavingTransactions()
                            {
                                Amount = transaction.Amount,
                                Date = transaction.Date,
                                PayedPrice = transaction.PayedPrice,
                                Price = transaction.Price
                            };
                            saving.SavingTransactions.Add(item);
                            context.SaveChanges();
                        }
                        dbTransaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                //todo:
            }

            return savingTransactions;
        }

        public bool FillHistoricalData(IList<ConseqData> data, string savingName)
        {
            try
            {
                data = data.OrderByDescending(a => a.Date).ToList();
                using (var context = new SpendingReportEntities())
                {
                    var savingTransactions = context.Savings.FirstOrDefault(a => a.Name == savingName)?.SavingTransactions.OrderByDescending(a=>a.Date).ToList();
                    var transactionPosition = 0;
                    var highestPrice = 0.0;
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        foreach (var histoicPrice in data)
                        {
                            if (highestPrice < histoicPrice.Price)
                            {
                                highestPrice = histoicPrice.Price;
                            }
                            if (savingTransactions.ElementAt(transactionPosition).Date.Date >= histoicPrice.Date.Date)
                            {
                                savingTransactions.ElementAt(transactionPosition).HighestPrice = highestPrice;
                                transactionPosition++;
                                if (savingTransactions.Count <= transactionPosition)
                                {
                                    break;
                                }
                            }
                        }
                        context.SaveChanges();
                        dbTransaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                //todo:
                return false;
            }
            return true;
        }

        public IList<SavingList> Getsavings()
        {
            var list = new List<SavingList>();
            try
            {
                using (var context = new SpendingReportEntities())
                {
                    list = context.Savings.Select(a => new SavingList {Id = a.Id, Name = a.Name}).ToList();
                }
            }
            catch(Exception ex)
            {
                //todo:
            }
            return list;
        }

        public SavingDetail GetSavingDetail(int SavingId)
        {
            var savingDetail = new SavingDetail();

            try
            {
                using (var context = new SpendingReportEntities())
                {
                    var saving = context.Savings.FirstOrDefault(a => a.Id == SavingId);
                    savingDetail.AmountIn = saving.SavingTransactions.Select(a => a.PayedPrice).Sum();
                    savingDetail.MyPrice = saving.SavingTransactions.Select(a => a.Amount*a.HighestPrice).Sum();
                }
            }
            catch (Exception ex)
            {
                //todo:
            }

            return savingDetail;
        }


        public
            Import SaveData(Import bankPayments, int UserId)
        {
            Import ImportWithPocessedTransactions;

            try
            {
                using (var context = new SpendingReportEntities())
                {
                    //if (!bankPayments.Bank.BankID.HasValue)
                    //{
                    //    return -1;
                    //}

                    //entity.Bank bank = context.Banks.FirstOrDefault(t => t.BankCode == bankPayments.Bank.BankID);
                    var currentUser = Helpers.UserHelpers.GetUserByID(UserId);
                    entity.BankAccount SourceAccount;
                    SourceAccount = currentUser.BankAccounts.FirstOrDefault(t => t.IBAN == bankPayments.Account.IBan);
                    if (SourceAccount == null)
                    {
                        SourceAccount = new entity.BankAccount
                        {
                            IBAN = bankPayments.Account.IBan,
                            AccountNumber = (long)bankPayments.Account.AccountID
                        };
                        SourceAccount.Bank =
                            context.Banks.FirstOrDefault(t => t.BankCode == bankPayments.Account.Bank.BankID) ?? new entity.Bank
                            {
                                BankCode = (short)bankPayments.Account.Bank.BankID,
                                Name=String.Empty
                            };
                        currentUser.BankAccounts.Add(SourceAccount);
                        context.BankAccounts.Add(SourceAccount);
                    }

                    ImportWithPocessedTransactions = new Import
                    {
                        Account = new data.ImportedBankAccount
                        {
                            Bank = bankPayments.Account.Bank,
                            AccountID = bankPayments.Account.AccountID,
                            IBan = bankPayments.Account.IBan,
                            Payments = new List<ImportedPayment>()
                        },//bankPayments.Account,
                        From = bankPayments.From,
                        To = bankPayments.To
                    };

                    //entity.Bank bank = context.Banks.FirstOrDefault(t => t.BankCode == bankPayments.Account.Bank.BankID);
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        foreach (Payment transaction in bankPayments.Account.Payments)
                        {

                            if (IsTransactionExist(context, transaction))
                            {
                                //ImportedPayment tr = new ImportedPayment(false);
                                //tr.VariableSymbol = transaction.VariableSymbol;
                                //ImportWithPocessedTransactions.Account.Payments.Add(tr);
                                ImportedPayment tr = transaction as ImportedPayment;
                                tr.Imported = false;
                                ImportWithPocessedTransactions.Account.Payments.Add(tr);
                                continue;
                            }
                            entity.Entry newTransaction = new entity.Entry
                            {
                                ConstantSymbol = transaction.ConstantSymbol,
                                VariableSymbol = transaction.VariableSymbol,
                                SpecificSymbol = transaction.SpecificSymbol,
                                Reference = transaction.Reference,
                                DateAvailable = transaction.DateAvailable,
                                DatePosted = transaction.DatePosted,
                                Memo = transaction.Description,
                                Name = transaction.TransactionName,
                                DateAdded = DateTime.Now,
                                AmountInfo = new entity.AmountInfo
                                {
                                    Amount = Math.Abs(transaction.TransactionAmount.Amount),
                                    Currency = transaction.TransactionAmount.Currency
                                },
                                //Bank = GetBank(context, transaction.BankName.Localise())
                            };
                            var account =
                                context.BankAccounts.FirstOrDefault(t => t.IBAN == transaction.BankAccount.IBan);
                            if (account != null)
                            {
                                newTransaction.DestinationAccountId = account.Id;
                            }
                            else
                            {
                                newTransaction.DestinationAccount = new entity.BankAccount
                                {
                                    AccountNumber = (long?) transaction.BankAccount.AccountID,
                                    //BankCode = (short?) transaction.BankAccount.BankID,
                                    IBAN = transaction.BankAccount.IBan,
                                    Bank =
                                        (transaction?.BankAccount?.Bank?.BankID.HasValue != null &&
                                         transaction.BankAccount.Bank.BankID.HasValue)
                                            ? GetBank(context, transaction.BankAccount.Bank.BankID.Value)
                                            : null,
                                    UserId = null
                                };
                            }
                            if (transaction.TransactionAmount.Type != AmountType.NotDefined)
                            {
                                newTransaction.AmountInfo.Type = transaction.TransactionAmount.Type == AmountType.Credit
                                    ? GetTransactionType(context, "Credit")
                                    : GetTransactionType(context, "Debit");
                            }
                            else
                            {
                                newTransaction.AmountInfo.Type = transaction.TransactionAmount.Amount < 0
                                    ? GetTransactionType(context, "Debit")
                                    : GetTransactionType(context, "Credit");
                            }
                            SourceAccount.Entries.Add(newTransaction);
                            ImportedPayment importedTr = transaction as ImportedPayment; //new ImportedPayment(true);
                            importedTr.Imported = true;

                            //importedTr.VariableSymbol = transaction.VariableSymbol;
                            ImportWithPocessedTransactions.Account.Payments.Add(importedTr);
                            //Payment tran = new Payment();
                            //tran.VariableSymbol = transaction.VariableSymbol;
                            //ImportWithPocessedTransactions.Account.Payments.Add(tran);
                            //break;
                            context.SaveChanges();
                        }
                        dbTransaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Nastala chyba pri ukladani importu!", e);
            }
            return ImportWithPocessedTransactions;
        }

        /// <summary>
        /// Checks if transaction allready exists in the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        private bool IsTransactionExist(SpendingReportEntities context, Payment transaction)
        {
            var date = transaction.DateAvailable;
            var item =
                context.Entries.Where(
                    t =>
                        t.AmountInfo.Amount == transaction.TransactionAmount.Amount && t.Name == transaction.TransactionName &&
                        t.Memo == transaction.Description &&
                        t.DateAvailable == date);
            return item.Any();
        }

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private entity.Type GetTransactionType(SpendingReportEntities context, string type)
        {
            return context.Types.FirstOrDefault(
                item => item.TypeName.ToLower().Trim() == type.ToLower().Trim());
        }

        private entity.Bank GetBank(SpendingReportEntities context, string Name)
        {
            return context.Banks.FirstOrDefault(
                item => item.Name.ToLower().Trim() == Name.ToLower().Trim());
        }

        private entity.Bank GetBank(SpendingReportEntities context, ushort bankCode)
        {
            return context.Banks.FirstOrDefault(
                item => item.BankCode == bankCode);
        }

        public IEnumerable<Entry> GetTransactions()
        {
            using (var context = new SpendingReportEntities())
            {
                return context.Entries.ToList();
            }
        }

        //public void Update
    }
}
