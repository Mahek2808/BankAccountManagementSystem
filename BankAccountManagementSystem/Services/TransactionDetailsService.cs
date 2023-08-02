using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Enum;
using BankAccountManagementSystem.Interface;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankAccountManagementSystem.Services
{
    public class TransactionDetailsService : ITransaction
    {
        public readonly ContextClass _context;
        public readonly IConfiguration configuration;
        public TransactionDetailsService(ContextClass context,IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public async Task<List<BankTransaction>> GetAllTransaction()
        {
            try
            {
                var transRecord = _context.BankTransactionDetails.ToList();
                return transRecord;
            }
            catch (Exception ex)
            {
                ex.Source = "Error while getting Transaction Details";
            }
            
        }

        public async Task<BankTransaction> GetBankAccountWithTransactions(Guid transactionId)
        {
            try
            {
                var transactionById = await _context.BankTransactionDetails
               .Include(x => x.BankAccount) // Include the transactions for the bank account
               .FirstOrDefaultAsync(account => account.TransactionId == transactionId);

                return transactionById;
            }
            catch (Exception ex)
            {
                ex.Source = "Error while getting Transaction details by BankAccount Id";
            }
           
        }

        public async Task CreateDummyDataForTransaction(List<BankAccount> bankAccounts)
        {
            try
            {
                foreach (var bankAccount in bankAccounts)
                {
                    var random = new Random();
                    decimal CreditAmount = 0;
                    decimal DebitAmount = 0;
                    string DBTransactionConn = configuration.GetValue<string>("DummyRecord:NumberOfBankTransactions");
                    var transactions = new List<BankTransaction>();
                    for (int j = 0; j < int.Parse(DBTransactionConn); j++)
                    {
                        var randomPaymentMethod = _context.PaymentDetails.OrderBy(x => Guid.NewGuid()).First();
                        var randomCategoryOption = Enum.CatagoryOptionsForBankAccount.GetValues(typeof(CatagoryOptionsForBankAccount)).Cast<CatagoryOptionsForBankAccount>().OrderBy(x => random.Next()).First();
                        var amount = (decimal)random.NextDouble() * 1000; // Random amount up to 1000
                        var transactionType = random.Next(0, 2) == 0 ? TransactionType.TransactionTypeCredit : TransactionType.TransactionTypeDebit;

                        var transaction = new BankTransaction
                        {
                            TransactionId = Guid.NewGuid(),
                            FirstNameOfTransactionPerson = bankAccount.FirstName,
                            MiddleNameOfTransactionPerson = bankAccount.MiddleName,
                            LastNameOfTransactionPerson = bankAccount.LastName,
                            TypeOfTransaction = random.Next(0, 2) == 0 ? TransactionType.TransactionTypeCredit : TransactionType.TransactionTypeDebit,
                            CatagoryOptions = randomCategoryOption,
                            Amount = amount,
                            DateOfTransaction = bankAccount.AccountOpeningDate.AddDays(random.Next(1, 365)), // Random date after the opening date
                            PaymentMethod = randomPaymentMethod,
                            BankAccount = bankAccount
                        };

                        if (transaction.TypeOfTransaction == TransactionType.TransactionTypeCredit)
                        {
                            CreditAmount += transaction.Amount; //(decimal)random.NextDouble() * 1000; // Random amount up to 1000
                        }
                        else if (transaction.Amount < bankAccount.TotalAmountOfBalance)
                        {
                            // Limit the debit amount to the current balance or 100 Rs, whichever is lower.
                            var debitAmount = Math.Min(transaction.Amount, 50);
                            DebitAmount -= debitAmount;
                        }
                        else
                        {
                            var fixtedDebitAmount = 10;
                            DebitAmount -= fixtedDebitAmount;
                        }

                        transactions.Add(transaction);
                        bankAccount.TotalAmountOfBalance += (int)(Math.Abs(CreditAmount) - Math.Abs(DebitAmount));
                        _context.BankTransactionDetails.Add(transaction);

                        if (randomCategoryOption == CatagoryOptionsForBankAccount.Bank_Intrest || randomCategoryOption == CatagoryOptionsForBankAccount.Bank_Charges)
                        {
                            // This is for BankAccountPosting table
                            var posting = new BankAccountPostingDetails
                            {
                                PostingId = Guid.NewGuid(),
                                PostingDetails = transaction
                            };

                            _context.BankAccountPostingDetails.Add(posting);
                        }
                    }
                    bankAccount.TotalAmountOfBalance = (int)(Math.Abs(CreditAmount) - Math.Abs(DebitAmount));
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Source= "Error occuring while doing Transaction";
            }
            
        }

    }

}
