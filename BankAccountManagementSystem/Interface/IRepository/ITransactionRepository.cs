using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface.IRepository
{
    public interface ITransactionRepository
    {
        Task<List<BankTransaction>> GetBankTransactions();
        Task<BankTransaction> GetBankTransactionById(Guid id);
        Task<BankTransaction> GetBankTransactionByIdAndBankAccount(Guid id, Guid bankAccountId);
        Task CreateBankTransaction(List<BankTransaction> bankTransaction);
        Task UpdateBankTransaction(Guid id, BankTransaction bankTransaction);
        Task DeleteBankTransaction(Guid id);
    }
}
