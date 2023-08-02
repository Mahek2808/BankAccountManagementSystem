using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface
{
    public interface IBankAccount
    {
        Task CreateDummyDataForBankAccount();
        Task<List<BankAccount>> GetAllBankAccounts();

    }
}
