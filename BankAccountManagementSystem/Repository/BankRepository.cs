using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly ContextClass _ContextClass;
        public BankRepository(ContextClass contextClass)
        {
            _ContextClass = contextClass;
        }

        public async Task<List<BankAccount>> GetBankAccounts()
        {
            return await _ContextClass.BankAccountsDetails.ToListAsync(); 
        }

        public async Task<BankAccount> GetBankAccountById(Guid id)
        {
            return await _ContextClass.BankAccountsDetails.FirstOrDefaultAsync(x => x.Id == id);        
        }

        public async Task CreateDummyBankAccount(List<BankAccount> bankAccount)
        {
            bankAccount.Select(x => x.Id = new Guid());
            await _ContextClass.BankAccountsDetails.AddRangeAsync(bankAccount);
            await _ContextClass.SaveChangesAsync();
        }

        public async Task UpdateBankAccount(Guid id, BankAccount bankAccount)
        {
            var existingAccount = await GetBankAccountById(id);
            if (existingAccount != null)
            {
                existingAccount.FirstName = bankAccount.FirstName;
                existingAccount.MiddleName = bankAccount.MiddleName;
                existingAccount.LastName = bankAccount.LastName;
                existingAccount.AccountNumber = bankAccount.AccountNumber;
                existingAccount.AccountOpeningDate = bankAccount.AccountOpeningDate;
                existingAccount.AccountClosingDate = bankAccount.AccountClosingDate;
                existingAccount.AccountType_Id = bankAccount.AccountType_Id;
            }
        }
        public async Task DeleteBankAccount(Guid id)
        {
            var existingAccount = await GetBankAccountById(id);
            if (existingAccount != null)
            {
                _ContextClass.Remove(existingAccount);
            }
        }
    }
}

