using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Interface.IService
{
    public interface IAccountTypeService
    {
        Task<List<AccountTypeResponse>> GetAccountType();
        Task<AccountTypeResponse> GetAccountTypeById(Guid id);
        Task UpdateAccountType(Guid id, AccountTypeResponse accountType);
        Task DeleteAccountType(Guid id);
    }
}
