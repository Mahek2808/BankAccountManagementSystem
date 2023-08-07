using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface.IRepository
{
    public interface IAccountTypeRepository
    {
        Task<List<AccountType>> GetAccountType();
        Task<AccountType> GetAccountTypeById(Guid id);
        Task UpdateAccountType(Guid id, AccountType accountType);
        Task DeleteAccountType(Guid id);
    }
}
