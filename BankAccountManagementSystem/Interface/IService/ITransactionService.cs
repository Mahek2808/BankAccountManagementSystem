using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Interface.IService
{
    public interface ITransactionService
    {
        Task<List<BankTransactionResponse>> GetBankTransactions();
        Task<BankTransactionResponse> GetBankTransactionById(Guid id);
        Task<BankTransactionResponse> GetBankTransactionByIdAndBankAccount(Guid id, Guid bankAccountId);
        Task<List<BankTransactionResponse>> CreateBankTransaction(List<BankAccountResponse> bankAccounts);
        Task UpdateBankTransaction(Guid id, BankTransactionResponse bankTransaction);
        Task DeleteBankTransaction(Guid id);
    }
}
