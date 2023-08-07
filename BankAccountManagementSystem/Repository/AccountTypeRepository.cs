using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly ContextClass _ContextClass;
        private readonly List<AccountType> _accounts;

        public AccountTypeRepository(ContextClass contextClass)
        {
            _ContextClass = contextClass;
            _accounts = new List<AccountType>
            {
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = "Liability"
                },
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = "Asset"
                }
            };
        }
        public async Task DeleteAccountType(Guid id)
        {
            var existingMethod = await GetAccountTypeById(id);
            if (existingMethod != null)
            {
                _accounts.Remove(existingMethod);
            }
        }

        public async Task<List<AccountType>> GetAccountType()
        {
            return await _ContextClass.AccountTypesDetails.ToListAsync();
        }

        public async Task<AccountType> GetAccountTypeById(Guid id)
        {
            return await _ContextClass.AccountTypesDetails.FirstOrDefaultAsync(x => x.Id== id);
        }

        public async Task UpdateAccountType(Guid id, AccountType accountType)
        {
            var existingMethod = await GetAccountTypeById(id);
            if (existingMethod != null)
            {
                existingMethod.Name = accountType.Name;
            }
        }
    }
}
