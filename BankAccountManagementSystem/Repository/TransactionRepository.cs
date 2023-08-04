using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public readonly ContextClass _ContextClass;

        public TransactionRepository(ContextClass contextClass)
        {
            _ContextClass = contextClass;
        }

        public async Task<List<BankTransaction>> GetBankTransactions()
        {
            return await _ContextClass.BankTransactionDetails.ToListAsync();
        }

        public async Task<BankTransaction> GetBankTransactionById(Guid id)
        {
            return await _ContextClass.BankTransactionDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateBankTransaction(List<BankTransaction> bankTransaction)
        {
            var newId = Guid.NewGuid();
            bankTransaction.Select(x => x.Id);
            await _ContextClass.BankTransactionDetails.AddRangeAsync(bankTransaction);
            await _ContextClass.SaveChangesAsync();
        }

        public async Task UpdateBankTransaction(Guid id, BankTransaction bankTransaction)
        {
            var existingTransaction = await GetBankTransactionById(id);
            if (existingTransaction != null)
            {
                existingTransaction.FirstName = bankTransaction.FirstName;
                existingTransaction.MiddleName = bankTransaction.MiddleName;
                existingTransaction.LastName = bankTransaction.LastName;
                existingTransaction.TypeOfTransaction = bankTransaction.TypeOfTransaction;
                existingTransaction.CatagoryOptions = bankTransaction.CatagoryOptions;
                existingTransaction.Amount = bankTransaction.Amount;
                existingTransaction.DateOfTransaction = bankTransaction.DateOfTransaction;
                existingTransaction.Payment_Id = bankTransaction.Payment_Id;
                existingTransaction.BankAccount_Id = bankTransaction.BankAccount_Id;
            }
        }
        public async Task DeleteBankTransaction(Guid id)
        {
            var existingTransaction = await GetBankTransactionById(id);
            if (existingTransaction != null)
            {
                _ContextClass.Remove(existingTransaction);
            }
        }
    }
}
