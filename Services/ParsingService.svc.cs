using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SpendingReportEntity;
using XMLParser.Data;
using entity = SpendingReportEntity;
using data = XMLParser.Data;


namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParsingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParsingService.svc or ParsingService.svc.cs at the Solution Explorer and start debugging.
    public class ParsingService : IParsingService
    {
        public Import SaveData(Import bankPayments, int UserId)
        {
            Import ImportWithPocessedTransactions;

            try
            {
                using (var context = new SpendingContext())
                {
                    //if (!bankPayments.Bank.BankID.HasValue)
                    //{
                    //    return -1;
                    //}

                    //entity.Bank bank = context.Banks.FirstOrDefault(t => t.BankCode == bankPayments.Bank.BankID);
                    var currentUser = Helpers.GetUserByID(UserId);
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
                                BankCode = (short)bankPayments.Account.Bank.BankID
                            };
                        currentUser.BankAccounts.Add(SourceAccount);
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
                        Entry newTransaction = new Entry
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
                        var account = context.BankAccounts.FirstOrDefault(t => t.IBAN == transaction.BankAccount.IBan);
                        if (account != null)
                        {
                            newTransaction.DestinationAccountId = account.Id;
                        }
                        else
                        {
                            newTransaction.DestinationAccount = new entity.BankAccount
                            {
                                AccountNumber = (long?)transaction.BankAccount.AccountID,
                                //BankCode = (short?) transaction.BankAccount.BankID,
                                IBAN = transaction.BankAccount.IBan,
                                Bank =
                                    transaction.BankAccount.Bank.BankID.HasValue
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
                        ImportedPayment importedTr = transaction as ImportedPayment;//new ImportedPayment(true);
                        importedTr.Imported = true;

                        //importedTr.VariableSymbol = transaction.VariableSymbol;
                        ImportWithPocessedTransactions.Account.Payments.Add(importedTr);
                        //Payment tran = new Payment();
                        //tran.VariableSymbol = transaction.VariableSymbol;
                        //ImportWithPocessedTransactions.Account.Payments.Add(tran);
                        //break;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return ImportWithPocessedTransactions;
        }

        /// <summary>
        /// Checks if transaction allready exists in the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        private bool IsTransactionExist(SpendingContext context, Payment transaction)
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
        private entity.Type GetTransactionType(SpendingContext context, string type)
        {
            return context.Types.FirstOrDefault(
                item => item.TypeName.ToLower().Trim() == type.ToLower().Trim());
        }

        private entity.Bank GetBank(SpendingContext context, string Name)
        {
            return context.Banks.FirstOrDefault(
                item => item.Name.ToLower().Trim() == Name.ToLower().Trim());
        }

        private entity.Bank GetBank(SpendingContext context, ushort bankCode)
        {
            return context.Banks.FirstOrDefault(
                item => item.BankCode == bankCode);
        }

        public IEnumerable<Entry> GetTransactions()
        {
            using (var context = new SpendingContext())
            {
                return context.Entries.ToList();
            }
        }
    }
}
