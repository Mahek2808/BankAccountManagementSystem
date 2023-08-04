using BankAccountManagementSystem.Model;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Interface.IService
{
    public interface IBankAccountService
    {
        Task<List<BankAccountResponse>> GetBankAccounts();
        Task<BankAccountResponse> GetBankAccountById(Guid id);
        Task<List<BankAccountResponse>> CreateBankAccount();
        Task UpdateBankAccount(Guid id, BankAccountResponse bankAccount);
        Task DeleteBankAccount(Guid id);
    }
}
