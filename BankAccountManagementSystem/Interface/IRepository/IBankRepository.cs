using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface.IRepository
{
    public interface IBankRepository
    {
        public Task<List<BankAccount>> GetBankAccounts();
        public Task<BankAccount> GetBankAccountById(Guid id);
        public Task CreateDummyBankAccount(List<BankAccount> bankAccount);
        public Task UpdateBankAccount(Guid id, BankAccount bankAccount);
        public Task DeleteBankAccount(Guid id);
    }
}
